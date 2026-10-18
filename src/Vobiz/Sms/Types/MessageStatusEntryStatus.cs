using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(MessageStatusEntryStatus.MessageStatusEntryStatusSerializer))]
[Serializable]
public readonly record struct MessageStatusEntryStatus : IStringEnum
{
    public static readonly MessageStatusEntryStatus Scheduled = new(Values.Scheduled);

    public static readonly MessageStatusEntryStatus Sent = new(Values.Sent);

    public static readonly MessageStatusEntryStatus Delivered = new(Values.Delivered);

    public static readonly MessageStatusEntryStatus Failed = new(Values.Failed);

    public static readonly MessageStatusEntryStatus Received = new(Values.Received);

    public static readonly MessageStatusEntryStatus Unknown = new(Values.Unknown);

    public MessageStatusEntryStatus(string value)
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
    public static MessageStatusEntryStatus FromCustom(string value)
    {
        return new MessageStatusEntryStatus(value);
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

    public static bool operator ==(MessageStatusEntryStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageStatusEntryStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageStatusEntryStatus value) => value.Value;

    public static explicit operator MessageStatusEntryStatus(string value) => new(value);

    internal class MessageStatusEntryStatusSerializer : JsonConverter<MessageStatusEntryStatus>
    {
        public override MessageStatusEntryStatus Read(
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
            return new MessageStatusEntryStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MessageStatusEntryStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MessageStatusEntryStatus ReadAsPropertyName(
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
            return new MessageStatusEntryStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MessageStatusEntryStatus value,
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
