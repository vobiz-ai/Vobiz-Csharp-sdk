using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PartnerCustomerStatus.PartnerCustomerStatusSerializer))]
[Serializable]
public readonly record struct PartnerCustomerStatus : IStringEnum
{
    public static readonly PartnerCustomerStatus Active = new(Values.Active);

    public static readonly PartnerCustomerStatus Suspended = new(Values.Suspended);

    public static readonly PartnerCustomerStatus Inactive = new(Values.Inactive);

    public PartnerCustomerStatus(string value)
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
    public static PartnerCustomerStatus FromCustom(string value)
    {
        return new PartnerCustomerStatus(value);
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

    public static bool operator ==(PartnerCustomerStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartnerCustomerStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartnerCustomerStatus value) => value.Value;

    public static explicit operator PartnerCustomerStatus(string value) => new(value);

    internal class PartnerCustomerStatusSerializer : JsonConverter<PartnerCustomerStatus>
    {
        public override PartnerCustomerStatus Read(
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
            return new PartnerCustomerStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PartnerCustomerStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PartnerCustomerStatus ReadAsPropertyName(
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
            return new PartnerCustomerStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PartnerCustomerStatus value,
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
        public const string Active = "active";

        public const string Suspended = "suspended";

        public const string Inactive = "inactive";
    }
}
