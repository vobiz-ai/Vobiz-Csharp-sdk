using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(NumberPurchaseStatus.NumberPurchaseStatusSerializer))]
[Serializable]
public readonly record struct NumberPurchaseStatus : IStringEnum
{
    public static readonly NumberPurchaseStatus Pending = new(Values.Pending);

    public static readonly NumberPurchaseStatus Debited = new(Values.Debited);

    public static readonly NumberPurchaseStatus Purchased = new(Values.Purchased);

    public static readonly NumberPurchaseStatus PastDue = new(Values.PastDue);

    public static readonly NumberPurchaseStatus Failed = new(Values.Failed);

    public static readonly NumberPurchaseStatus Refunded = new(Values.Refunded);

    public static readonly NumberPurchaseStatus Released = new(Values.Released);

    public NumberPurchaseStatus(string value)
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
    public static NumberPurchaseStatus FromCustom(string value)
    {
        return new NumberPurchaseStatus(value);
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

    public static bool operator ==(NumberPurchaseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NumberPurchaseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NumberPurchaseStatus value) => value.Value;

    public static explicit operator NumberPurchaseStatus(string value) => new(value);

    internal class NumberPurchaseStatusSerializer : JsonConverter<NumberPurchaseStatus>
    {
        public override NumberPurchaseStatus Read(
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
            return new NumberPurchaseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NumberPurchaseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NumberPurchaseStatus ReadAsPropertyName(
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
            return new NumberPurchaseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NumberPurchaseStatus value,
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

        public const string Debited = "debited";

        public const string Purchased = "purchased";

        public const string PastDue = "past_due";

        public const string Failed = "failed";

        public const string Refunded = "refunded";

        public const string Released = "released";
    }
}
