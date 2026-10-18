using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(WebhookEvent.WebhookEventSerializer))]
[Serializable]
public readonly record struct WebhookEvent : IStringEnum
{
    public static readonly WebhookEvent MessageStatus = new(Values.MessageStatus);

    public static readonly WebhookEvent MessageDelivered = new(Values.MessageDelivered);

    public static readonly WebhookEvent MessageFailed = new(Values.MessageFailed);

    public static readonly WebhookEvent MessageReceived = new(Values.MessageReceived);

    public static readonly WebhookEvent BroadcastUpdated = new(Values.BroadcastUpdated);

    public WebhookEvent(string value)
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
    public static WebhookEvent FromCustom(string value)
    {
        return new WebhookEvent(value);
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

    public static bool operator ==(WebhookEvent value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookEvent value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookEvent value) => value.Value;

    public static explicit operator WebhookEvent(string value) => new(value);

    internal class WebhookEventSerializer : JsonConverter<WebhookEvent>
    {
        public override WebhookEvent Read(
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
            return new WebhookEvent(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookEvent ReadAsPropertyName(
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
            return new WebhookEvent(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookEvent value,
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
        public const string MessageStatus = "message.status";

        public const string MessageDelivered = "message.delivered";

        public const string MessageFailed = "message.failed";

        public const string MessageReceived = "message.received";

        public const string BroadcastUpdated = "broadcast.updated";
    }
}
