using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(NumberBillingChargeStatus.NumberBillingChargeStatusSerializer))]
[Serializable]
public readonly record struct NumberBillingChargeStatus : IStringEnum
{
    public static readonly NumberBillingChargeStatus Pending = new(Values.Pending);

    public static readonly NumberBillingChargeStatus Paid = new(Values.Paid);

    public static readonly NumberBillingChargeStatus Failed = new(Values.Failed);

    public static readonly NumberBillingChargeStatus Refunded = new(Values.Refunded);

    public NumberBillingChargeStatus(string value)
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
    public static NumberBillingChargeStatus FromCustom(string value)
    {
        return new NumberBillingChargeStatus(value);
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

    public static bool operator ==(NumberBillingChargeStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NumberBillingChargeStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NumberBillingChargeStatus value) => value.Value;

    public static explicit operator NumberBillingChargeStatus(string value) => new(value);

    internal class NumberBillingChargeStatusSerializer : JsonConverter<NumberBillingChargeStatus>
    {
        public override NumberBillingChargeStatus Read(
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
            return new NumberBillingChargeStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NumberBillingChargeStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NumberBillingChargeStatus ReadAsPropertyName(
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
            return new NumberBillingChargeStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NumberBillingChargeStatus value,
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
        public const string Pending = "pending";

        public const string Paid = "paid";

        public const string Failed = "failed";

        public const string Refunded = "refunded";
    }
}
