using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ListTransactionsRequestStatus.ListTransactionsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListTransactionsRequestStatus : IStringEnum
{
    public static readonly ListTransactionsRequestStatus Completed = new(Values.Completed);

    public static readonly ListTransactionsRequestStatus Pending = new(Values.Pending);

    public static readonly ListTransactionsRequestStatus Failed = new(Values.Failed);

    public static readonly ListTransactionsRequestStatus Cancelled = new(Values.Cancelled);

    public ListTransactionsRequestStatus(string value)
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
    public static ListTransactionsRequestStatus FromCustom(string value)
    {
        return new ListTransactionsRequestStatus(value);
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

    public static bool operator ==(ListTransactionsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListTransactionsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListTransactionsRequestStatus value) => value.Value;

    public static explicit operator ListTransactionsRequestStatus(string value) => new(value);

    internal class ListTransactionsRequestStatusSerializer
        : JsonConverter<ListTransactionsRequestStatus>
    {
        public override ListTransactionsRequestStatus Read(
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
            return new ListTransactionsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListTransactionsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListTransactionsRequestStatus ReadAsPropertyName(
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
            return new ListTransactionsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListTransactionsRequestStatus value,
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
        public const string Completed = "completed";

        public const string Pending = "pending";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
