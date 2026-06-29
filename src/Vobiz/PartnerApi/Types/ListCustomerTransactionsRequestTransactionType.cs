using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(ListCustomerTransactionsRequestTransactionType.ListCustomerTransactionsRequestTransactionTypeSerializer)
)]
[Serializable]
public readonly record struct ListCustomerTransactionsRequestTransactionType : IStringEnum
{
    public static readonly ListCustomerTransactionsRequestTransactionType Recharge = new(
        Values.Recharge
    );

    public static readonly ListCustomerTransactionsRequestTransactionType Debit = new(Values.Debit);

    public static readonly ListCustomerTransactionsRequestTransactionType Refund = new(
        Values.Refund
    );

    public static readonly ListCustomerTransactionsRequestTransactionType Transfer = new(
        Values.Transfer
    );

    public ListCustomerTransactionsRequestTransactionType(string value)
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
    public static ListCustomerTransactionsRequestTransactionType FromCustom(string value)
    {
        return new ListCustomerTransactionsRequestTransactionType(value);
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

    public static bool operator ==(
        ListCustomerTransactionsRequestTransactionType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCustomerTransactionsRequestTransactionType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListCustomerTransactionsRequestTransactionType value) =>
        value.Value;

    public static explicit operator ListCustomerTransactionsRequestTransactionType(string value) =>
        new(value);

    internal class ListCustomerTransactionsRequestTransactionTypeSerializer
        : JsonConverter<ListCustomerTransactionsRequestTransactionType>
    {
        public override ListCustomerTransactionsRequestTransactionType Read(
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
            return new ListCustomerTransactionsRequestTransactionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCustomerTransactionsRequestTransactionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCustomerTransactionsRequestTransactionType ReadAsPropertyName(
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
            return new ListCustomerTransactionsRequestTransactionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCustomerTransactionsRequestTransactionType value,
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

        public const string Refund = "refund";

        public const string Transfer = "transfer";
    }
}
