using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(MessageChannel.MessageChannelSerializer))]
[Serializable]
public readonly record struct MessageChannel : IStringEnum
{
    public static readonly MessageChannel Sms = new(Values.Sms);

    public static readonly MessageChannel Mms = new(Values.Mms);

    public static readonly MessageChannel Rcs = new(Values.Rcs);

    public MessageChannel(string value)
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
    public static MessageChannel FromCustom(string value)
    {
        return new MessageChannel(value);
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

    public static bool operator ==(MessageChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageChannel value) => value.Value;

    public static explicit operator MessageChannel(string value) => new(value);

    internal class MessageChannelSerializer : JsonConverter<MessageChannel>
    {
        public override MessageChannel Read(
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
            return new MessageChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MessageChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MessageChannel ReadAsPropertyName(
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
            return new MessageChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MessageChannel value,
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
        public const string Sms = "sms";

        public const string Mms = "mms";

        public const string Rcs = "rcs";
    }
}
