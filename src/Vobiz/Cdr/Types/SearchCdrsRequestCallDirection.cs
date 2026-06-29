using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(SearchCdrsRequestCallDirection.SearchCdrsRequestCallDirectionSerializer))]
[Serializable]
public readonly record struct SearchCdrsRequestCallDirection : IStringEnum
{
    public static readonly SearchCdrsRequestCallDirection Inbound = new(Values.Inbound);

    public static readonly SearchCdrsRequestCallDirection Outbound = new(Values.Outbound);

    public SearchCdrsRequestCallDirection(string value)
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
    public static SearchCdrsRequestCallDirection FromCustom(string value)
    {
        return new SearchCdrsRequestCallDirection(value);
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

    public static bool operator ==(SearchCdrsRequestCallDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchCdrsRequestCallDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchCdrsRequestCallDirection value) => value.Value;

    public static explicit operator SearchCdrsRequestCallDirection(string value) => new(value);

    internal class SearchCdrsRequestCallDirectionSerializer
        : JsonConverter<SearchCdrsRequestCallDirection>
    {
        public override SearchCdrsRequestCallDirection Read(
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
            return new SearchCdrsRequestCallDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SearchCdrsRequestCallDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SearchCdrsRequestCallDirection ReadAsPropertyName(
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
            return new SearchCdrsRequestCallDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SearchCdrsRequestCallDirection value,
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
        public const string Inbound = "inbound";

        public const string Outbound = "outbound";
    }
}
