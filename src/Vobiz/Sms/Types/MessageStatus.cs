using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(MessageStatus.MessageStatusSerializer))]
[Serializable]
public readonly record struct MessageStatus : IStringEnum
{
    public static readonly MessageStatus Scheduled = new(Values.Scheduled);

    public static readonly MessageStatus Sent = new(Values.Sent);

    public static readonly MessageStatus Delivered = new(Values.Delivered);

    public static readonly MessageStatus Failed = new(Values.Failed);

    public static readonly MessageStatus Received = new(Values.Received);

    public static readonly MessageStatus Unknown = new(Values.Unknown);

    public MessageStatus(string value)
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
    public static MessageStatus FromCustom(string value)
    {
        return new MessageStatus(value);
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

    public static bool operator ==(MessageStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageStatus value) => value.Value;

    public static explicit operator MessageStatus(string value) => new(value);

    internal class MessageStatusSerializer : JsonConverter<MessageStatus>
    {
        public override MessageStatus Read(
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
            return new MessageStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MessageStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MessageStatus ReadAsPropertyName(
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
            return new MessageStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MessageStatus value,
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
