using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(ListCustomerCdrsRequestCallDirection.ListCustomerCdrsRequestCallDirectionSerializer)
)]
[Serializable]
public readonly record struct ListCustomerCdrsRequestCallDirection : IStringEnum
{
    public static readonly ListCustomerCdrsRequestCallDirection Inbound = new(Values.Inbound);

    public static readonly ListCustomerCdrsRequestCallDirection Outbound = new(Values.Outbound);

    public ListCustomerCdrsRequestCallDirection(string value)
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
    public static ListCustomerCdrsRequestCallDirection FromCustom(string value)
    {
        return new ListCustomerCdrsRequestCallDirection(value);
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

    public static bool operator ==(ListCustomerCdrsRequestCallDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCustomerCdrsRequestCallDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCustomerCdrsRequestCallDirection value) =>
        value.Value;

    public static explicit operator ListCustomerCdrsRequestCallDirection(string value) =>
        new(value);

    internal class ListCustomerCdrsRequestCallDirectionSerializer
        : JsonConverter<ListCustomerCdrsRequestCallDirection>
    {
        public override ListCustomerCdrsRequestCallDirection Read(
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
            return new ListCustomerCdrsRequestCallDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCustomerCdrsRequestCallDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCustomerCdrsRequestCallDirection ReadAsPropertyName(
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
            return new ListCustomerCdrsRequestCallDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCustomerCdrsRequestCallDirection value,
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
