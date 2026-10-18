using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(ListRecipientsRequestStatus.ListRecipientsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListRecipientsRequestStatus : IStringEnum
{
    public static readonly ListRecipientsRequestStatus Pending = new(Values.Pending);

    public static readonly ListRecipientsRequestStatus Sending = new(Values.Sending);

    public static readonly ListRecipientsRequestStatus Sent = new(Values.Sent);

    public static readonly ListRecipientsRequestStatus Delivered = new(Values.Delivered);

    public static readonly ListRecipientsRequestStatus Failed = new(Values.Failed);

    public static readonly ListRecipientsRequestStatus OptedOut = new(Values.OptedOut);

    public static readonly ListRecipientsRequestStatus Skipped = new(Values.Skipped);

    public ListRecipientsRequestStatus(string value)
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
    public static ListRecipientsRequestStatus FromCustom(string value)
    {
        return new ListRecipientsRequestStatus(value);
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

    public static bool operator ==(ListRecipientsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListRecipientsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListRecipientsRequestStatus value) => value.Value;

    public static explicit operator ListRecipientsRequestStatus(string value) => new(value);

    internal class ListRecipientsRequestStatusSerializer
        : JsonConverter<ListRecipientsRequestStatus>
    {
        public override ListRecipientsRequestStatus Read(
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
            return new ListRecipientsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListRecipientsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListRecipientsRequestStatus ReadAsPropertyName(
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
            return new ListRecipientsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListRecipientsRequestStatus value,
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

        public const string Sending = "sending";

        public const string Sent = "sent";

        public const string Delivered = "delivered";

        public const string Failed = "failed";

        public const string OptedOut = "opted_out";

        public const string Skipped = "skipped";
    }
}
