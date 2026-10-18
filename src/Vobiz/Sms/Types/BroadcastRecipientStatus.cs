using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BroadcastRecipientStatus.BroadcastRecipientStatusSerializer))]
[Serializable]
public readonly record struct BroadcastRecipientStatus : IStringEnum
{
    public static readonly BroadcastRecipientStatus Pending = new(Values.Pending);

    public static readonly BroadcastRecipientStatus Sending = new(Values.Sending);

    public static readonly BroadcastRecipientStatus Sent = new(Values.Sent);

    public static readonly BroadcastRecipientStatus Delivered = new(Values.Delivered);

    public static readonly BroadcastRecipientStatus Failed = new(Values.Failed);

    public static readonly BroadcastRecipientStatus OptedOut = new(Values.OptedOut);

    public static readonly BroadcastRecipientStatus Skipped = new(Values.Skipped);

    public BroadcastRecipientStatus(string value)
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
    public static BroadcastRecipientStatus FromCustom(string value)
    {
        return new BroadcastRecipientStatus(value);
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

    public static bool operator ==(BroadcastRecipientStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BroadcastRecipientStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BroadcastRecipientStatus value) => value.Value;

    public static explicit operator BroadcastRecipientStatus(string value) => new(value);

    internal class BroadcastRecipientStatusSerializer : JsonConverter<BroadcastRecipientStatus>
    {
        public override BroadcastRecipientStatus Read(
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
            return new BroadcastRecipientStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BroadcastRecipientStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BroadcastRecipientStatus ReadAsPropertyName(
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
            return new BroadcastRecipientStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BroadcastRecipientStatus value,
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
