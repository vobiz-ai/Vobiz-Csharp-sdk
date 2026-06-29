using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PartnerTransactionType.PartnerTransactionTypeSerializer))]
[Serializable]
public readonly record struct PartnerTransactionType : IStringEnum
{
    public static readonly PartnerTransactionType Recharge = new(Values.Recharge);

    public static readonly PartnerTransactionType Debit = new(Values.Debit);

    public static readonly PartnerTransactionType Adjustment = new(Values.Adjustment);

    public static readonly PartnerTransactionType Refund = new(Values.Refund);

    public PartnerTransactionType(string value)
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
    public static PartnerTransactionType FromCustom(string value)
    {
        return new PartnerTransactionType(value);
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

    public static bool operator ==(PartnerTransactionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartnerTransactionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartnerTransactionType value) => value.Value;

    public static explicit operator PartnerTransactionType(string value) => new(value);

    internal class PartnerTransactionTypeSerializer : JsonConverter<PartnerTransactionType>
    {
        public override PartnerTransactionType Read(
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
            return new PartnerTransactionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PartnerTransactionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PartnerTransactionType ReadAsPropertyName(
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
            return new PartnerTransactionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PartnerTransactionType value,
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
        public const string Recharge = "recharge";

        public const string Debit = "debit";

        public const string Adjustment = "adjustment";

        public const string Refund = "refund";
    }
}
