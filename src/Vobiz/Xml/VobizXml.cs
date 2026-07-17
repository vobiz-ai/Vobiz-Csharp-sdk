// vobizxml - build VobizXML call-control documents in C# / .NET.
//
// Mirrors Plivo's `plivoxml` (ResponseElement + Add* builders + ToString()) and emits
// XML byte-identical to the Python `vobizxml` package and the Node `@vobiz/sdk` builder.
// Single self-contained file so it compiles cleanly when injected into the `Vobiz`
// NuGet package at publish time (see .github/workflows/publish-csharp.yml). Attribute
// keys are the camelCase VobizXML attribute names directly.
//
//   using Vobiz.Xml;
//
//   var r = new ResponseElement();
//   var g = r.AddGather(new Attrs {
//       { "action", "https://yourapp.com/menu" },
//       { "inputType", "dtmf" },
//       { "numDigits", 1 },
//       { "executionTimeout", 10 },
//   });
//   g.AddSpeak("Press 1 for sales, 2 for support.");
//   r.AddHangup();
//   Console.WriteLine(r.ToString());          // pretty, with XML declaration
//   // r.ToString(pretty: false)              // compact single line for webhooks

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Vobiz.Xml
{
    /// <summary>
    /// An ordered, insertion-preserving collection of XML attributes. Supports C#
    /// collection-initializer syntax (<c>new Attrs { { "key", value } }</c>) so attribute
    /// order is deterministic (a <see cref="Dictionary{TKey,TValue}"/> may reorder).
    /// Values may be <see cref="string"/>, numbers, <see cref="bool"/>, or <c>null</c>
    /// (null entries are skipped at render time).
    /// </summary>
    public sealed class Attrs : IEnumerable<KeyValuePair<string, object?>>
    {
        private readonly List<KeyValuePair<string, object?>> _items = new();

        public void Add(string key, object? value) =>
            _items.Add(new KeyValuePair<string, object?>(key, value));

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>A single VobizXML element: ordered attributes, optional text content, children.</summary>
    public class VobizXmlElement
    {
        public const string XmlDeclaration = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        private const string Indent = "    "; // 4 spaces, matching the xml/*.mdx reference style

        public string Name { get; }
        public string? Content { get; }
        public bool Raw { get; }
        public List<VobizXmlElement> Children { get; } = new();
        public List<KeyValuePair<string, string>> Attributes { get; } = new();

        public VobizXmlElement(string name, string? content = null, Attrs? attrs = null, bool raw = false)
        {
            Name = name;
            Content = content;
            Raw = raw;
            ApplyAttrs(attrs);
        }

        private void ApplyAttrs(Attrs? attrs)
        {
            if (attrs is null) return;
            foreach (var kv in attrs)
            {
                if (kv.Value is null) continue; // skip null/unset attributes
                Attributes.Add(new KeyValuePair<string, string>(kv.Key, AttrValue(kv.Value)));
            }
        }

        /// <summary>Append a child element and return it (so callers can keep nesting).</summary>
        public T Add<T>(T element) where T : VobizXmlElement
        {
            Children.Add(element);
            return element;
        }

        /// <summary>Set/override attributes after construction; returns this for chaining.</summary>
        public VobizXmlElement Set(Attrs attrs)
        {
            ApplyAttrs(attrs);
            return this;
        }

        /// <summary>Render an attribute value: bools -> "true"/"false", numbers culture-invariant.</summary>
        public static string AttrValue(object value)
        {
            if (value is bool b) return b ? "true" : "false";
            if (value is IFormattable f) return f.ToString(null, CultureInfo.InvariantCulture);
            return value.ToString() ?? string.Empty;
        }

        /// <summary>Escape XML text content (&amp;, &lt;, &gt;).</summary>
        public static string Escape(string text) =>
            text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");

        /// <summary>Escape an attribute value (text rules plus double quotes).</summary>
        public static string EscapeAttr(string value) => Escape(value).Replace("\"", "&quot;");

        private string OpenTag()
        {
            var sb = new StringBuilder(Name);
            foreach (var kv in Attributes)
            {
                sb.Append(' ').Append(kv.Key).Append("=\"").Append(EscapeAttr(kv.Value)).Append('"');
            }
            return sb.ToString();
        }

        internal string Render(int level, bool pretty)
        {
            var pad = pretty ? string.Concat(Enumerable_Repeat(Indent, level)) : string.Empty;
            var openTag = OpenTag();

            // Empty element -> self-closing
            if (Children.Count == 0 && Content is null)
            {
                return $"{pad}<{openTag}/>";
            }

            // Text-content element -> single line
            if (Children.Count == 0)
            {
                var body = Raw ? Content! : Escape(Content!);
                return $"{pad}<{openTag}>{body}</{Name}>";
            }

            // Container element -> children indented (text content, if any, is ignored)
            if (pretty)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < Children.Count; i++)
                {
                    if (i > 0) sb.Append('\n');
                    sb.Append(Children[i].Render(level + 1, true));
                }
                return $"{pad}<{openTag}>\n{sb}\n{pad}</{Name}>";
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var c in Children) sb.Append(c.Render(level + 1, false));
                return $"<{openTag}>{sb}</{Name}>";
            }
        }

        // Tiny local helper to avoid pulling System.Linq into the netstandard2.0 target set.
        private static IEnumerable<string> Enumerable_Repeat(string value, int count)
        {
            for (int i = 0; i < count; i++) yield return value;
        }

        /// <summary>Serialize to a VobizXML document string (with the XML declaration), pretty-printed.</summary>
        public override string ToString() => ToString(true);

        /// <summary>Serialize to a VobizXML document string. <paramref name="pretty"/> = false emits a compact single line.</summary>
        public string ToString(bool pretty)
        {
            var body = Render(0, pretty);
            return XmlDeclaration + (pretty ? "\n" : string.Empty) + body;
        }

        /// <summary>Convenience alias for <see cref="ToString(bool)"/>.</summary>
        public string ToXml(bool pretty = true) => ToString(pretty);
    }

    // --- Leaf / content elements ---------------------------------------------------

    /// <summary>&lt;Speak&gt; text-to-speech. Pass <c>ssml</c> to inject raw SSML unescaped.</summary>
    public sealed class SpeakElement : VobizXmlElement
    {
        public SpeakElement(string? content = null, Attrs? attrs = null, string? ssml = null)
            : base("Speak", ssml ?? content, attrs, raw: ssml is not null) { }
    }

    /// <summary>&lt;Play&gt; a remote MP3/WAV URL (text content).</summary>
    public sealed class PlayElement : VobizXmlElement
    {
        public PlayElement(string? url = null, Attrs? attrs = null) : base("Play", url, attrs) { }
    }

    /// <summary>&lt;Wait/&gt; silent pause (self-closing).</summary>
    public sealed class WaitElement : VobizXmlElement
    {
        public WaitElement(Attrs? attrs = null) : base("Wait", null, attrs) { }
    }

    /// <summary>&lt;Number&gt; a PSTN number to dial (nested in &lt;Dial&gt;).</summary>
    public sealed class NumberElement : VobizXmlElement
    {
        public NumberElement(string? number = null, Attrs? attrs = null) : base("Number", number, attrs) { }
    }

    /// <summary>&lt;User&gt; a SIP endpoint to dial (nested in &lt;Dial&gt;).</summary>
    public sealed class UserElement : VobizXmlElement
    {
        public UserElement(string? sipUri = null, Attrs? attrs = null) : base("User", sipUri, attrs) { }
    }

    /// <summary>&lt;Record/&gt; record the call/leg (self-closing; <c>action</c> typically required).</summary>
    public sealed class RecordElement : VobizXmlElement
    {
        public RecordElement(Attrs? attrs = null) : base("Record", null, attrs) { }
    }

    /// <summary>&lt;Conference&gt; join a room (room name is the text content).</summary>
    public sealed class ConferenceElement : VobizXmlElement
    {
        public ConferenceElement(string? room = null, Attrs? attrs = null) : base("Conference", room, attrs) { }
    }

    /// <summary>&lt;DTMF&gt; send digits on a live call (digits are the text content).</summary>
    public sealed class DtmfElement : VobizXmlElement
    {
        public DtmfElement(string? digits = null, Attrs? attrs = null) : base("DTMF", digits, attrs) { }
    }

    /// <summary>&lt;Redirect&gt; transfer flow control to a URL (text content).</summary>
    public sealed class RedirectElement : VobizXmlElement
    {
        public RedirectElement(string? url = null, Attrs? attrs = null) : base("Redirect", url, attrs) { }
    }

    /// <summary>&lt;Hangup/&gt; end/reject the call (self-closing).</summary>
    public sealed class HangupElement : VobizXmlElement
    {
        public HangupElement(Attrs? attrs = null) : base("Hangup", null, attrs) { }
    }

    /// <summary>&lt;Stream&gt; fork audio to a WebSocket (wss URL is the text content).</summary>
    public sealed class StreamElement : VobizXmlElement
    {
        public StreamElement(string? url = null, Attrs? attrs = null) : base("Stream", url, attrs) { }
    }

    // --- Container elements --------------------------------------------------------

    /// <summary>&lt;Gather&gt; collect DTMF/speech input. Nest Speak/Play prompts inside.</summary>
    public sealed class GatherElement : VobizXmlElement
    {
        public GatherElement(Attrs? attrs = null) : base("Gather", null, attrs) { }

        public SpeakElement AddSpeak(string? content = null, Attrs? attrs = null, string? ssml = null) =>
            Add(new SpeakElement(content, attrs, ssml));

        public PlayElement AddPlay(string? url = null, Attrs? attrs = null) =>
            Add(new PlayElement(url, attrs));
    }

    /// <summary>&lt;PreAnswer&gt; early-media block. Nest Speak/Play/Wait inside.</summary>
    public sealed class PreAnswerElement : VobizXmlElement
    {
        public PreAnswerElement() : base("PreAnswer") { }

        public SpeakElement AddSpeak(string? content = null, Attrs? attrs = null, string? ssml = null) =>
            Add(new SpeakElement(content, attrs, ssml));

        public PlayElement AddPlay(string? url = null, Attrs? attrs = null) =>
            Add(new PlayElement(url, attrs));

        public WaitElement AddWait(Attrs? attrs = null) =>
            Add(new WaitElement(attrs));
    }

    /// <summary>&lt;Dial&gt; bridge the caller to Number/User endpoints; may nest Record.</summary>
    public sealed class DialElement : VobizXmlElement
    {
        public DialElement(string? number = null, Attrs? attrs = null) : base("Dial", number, attrs) { }

        public NumberElement AddNumber(string? number = null, Attrs? attrs = null) =>
            Add(new NumberElement(number, attrs));

        public UserElement AddUser(string? sipUri = null, Attrs? attrs = null) =>
            Add(new UserElement(sipUri, attrs));

        public RecordElement AddRecord(Attrs? attrs = null) =>
            Add(new RecordElement(attrs));
    }

    /// <summary>&lt;Response&gt; root container. Use the Add* helpers to build the document.</summary>
    public sealed class ResponseElement : VobizXmlElement
    {
        public ResponseElement() : base("Response") { }

        public SpeakElement AddSpeak(string? content = null, Attrs? attrs = null, string? ssml = null) =>
            Add(new SpeakElement(content, attrs, ssml));

        public PlayElement AddPlay(string? url = null, Attrs? attrs = null) =>
            Add(new PlayElement(url, attrs));

        public WaitElement AddWait(Attrs? attrs = null) =>
            Add(new WaitElement(attrs));

        public GatherElement AddGather(Attrs? attrs = null) =>
            Add(new GatherElement(attrs));

        // Plivo-parity aliases: GetDigits/GetInput both emit <Gather>.
        public GatherElement AddGetDigits(Attrs? attrs = null) => AddGather(attrs);

        public GatherElement AddGetInput(Attrs? attrs = null) => AddGather(attrs);

        public DialElement AddDial(string? number = null, Attrs? attrs = null) =>
            Add(new DialElement(number, attrs));

        public RecordElement AddRecord(Attrs? attrs = null) =>
            Add(new RecordElement(attrs));

        public ConferenceElement AddConference(string? room = null, Attrs? attrs = null) =>
            Add(new ConferenceElement(room, attrs));

        public DtmfElement AddDtmf(string? digits = null, Attrs? attrs = null) =>
            Add(new DtmfElement(digits, attrs));

        public RedirectElement AddRedirect(string? url = null, Attrs? attrs = null) =>
            Add(new RedirectElement(url, attrs));

        public HangupElement AddHangup(Attrs? attrs = null) =>
            Add(new HangupElement(attrs));

        public PreAnswerElement AddPreAnswer() =>
            Add(new PreAnswerElement());

        public StreamElement AddStream(string? url = null, Attrs? attrs = null) =>
            Add(new StreamElement(url, attrs));
    }
}
