using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(SpeakTextCallRequestLegs.SpeakTextCallRequestLegsSerializer))]
[Serializable]
public readonly record struct SpeakTextCallRequestLegs : IStringEnum
{
    public static readonly SpeakTextCallRequestLegs Aleg = new(Values.Aleg);

    public static readonly SpeakTextCallRequestLegs Bleg = new(Values.Bleg);

    public static readonly SpeakTextCallRequestLegs Both = new(Values.Both);

    public SpeakTextCallRequestLegs(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static SpeakTextCallRequestLegs FromCustom(string value)
    {
        return new SpeakTextCallRequestLegs(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(SpeakTextCallRequestLegs value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeakTextCallRequestLegs value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeakTextCallRequestLegs value) => value.Value;

    public static explicit operator SpeakTextCallRequestLegs(string value) => new(value);

    internal class SpeakTextCallRequestLegsSerializer : JsonConverter<SpeakTextCallRequestLegs>
    {
        public override SpeakTextCallRequestLegs Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new SpeakTextCallRequestLegs(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeakTextCallRequestLegs value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeakTextCallRequestLegs ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new SpeakTextCallRequestLegs(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeakTextCallRequestLegs value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Aleg = "aleg";

        public const string Bleg = "bleg";

        public const string Both = "both";
    }
}
