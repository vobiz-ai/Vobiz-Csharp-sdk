using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(ListMessagesRequestStatus.ListMessagesRequestStatusSerializer))]
[Serializable]
public readonly record struct ListMessagesRequestStatus : IStringEnum
{
    public static readonly ListMessagesRequestStatus Scheduled = new(Values.Scheduled);

    public static readonly ListMessagesRequestStatus Sent = new(Values.Sent);

    public static readonly ListMessagesRequestStatus Delivered = new(Values.Delivered);

    public static readonly ListMessagesRequestStatus Failed = new(Values.Failed);

    public static readonly ListMessagesRequestStatus Received = new(Values.Received);

    public static readonly ListMessagesRequestStatus Unknown = new(Values.Unknown);

    public ListMessagesRequestStatus(string value)
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
    public static ListMessagesRequestStatus FromCustom(string value)
    {
        return new ListMessagesRequestStatus(value);
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

    public static bool operator ==(ListMessagesRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListMessagesRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListMessagesRequestStatus value) => value.Value;

    public static explicit operator ListMessagesRequestStatus(string value) => new(value);

    internal class ListMessagesRequestStatusSerializer : JsonConverter<ListMessagesRequestStatus>
    {
        public override ListMessagesRequestStatus Read(
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
            return new ListMessagesRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListMessagesRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListMessagesRequestStatus ReadAsPropertyName(
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
            return new ListMessagesRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListMessagesRequestStatus value,
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
        public const string Scheduled = "scheduled";

        public const string Sent = "sent";

        public const string Delivered = "delivered";

        public const string Failed = "failed";

        public const string Received = "received";

        public const string Unknown = "unknown";
    }
}
