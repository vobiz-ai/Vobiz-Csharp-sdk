using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BrandVetRequestType.BrandVetRequestTypeSerializer))]
[Serializable]
public readonly record struct BrandVetRequestType : IStringEnum
{
    public static readonly BrandVetRequestType Standard = new(Values.Standard);

    public static readonly BrandVetRequestType Enhanced = new(Values.Enhanced);

    public static readonly BrandVetRequestType Political = new(Values.Political);

    public BrandVetRequestType(string value)
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
    public static BrandVetRequestType FromCustom(string value)
    {
        return new BrandVetRequestType(value);
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

    public static bool operator ==(BrandVetRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandVetRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandVetRequestType value) => value.Value;

    public static explicit operator BrandVetRequestType(string value) => new(value);

    internal class BrandVetRequestTypeSerializer : JsonConverter<BrandVetRequestType>
    {
        public override BrandVetRequestType Read(
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
            return new BrandVetRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandVetRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandVetRequestType ReadAsPropertyName(
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
            return new BrandVetRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandVetRequestType value,
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
        public const string Standard = "STANDARD";

        public const string Enhanced = "ENHANCED";

        public const string Political = "POLITICAL";
    }
}
