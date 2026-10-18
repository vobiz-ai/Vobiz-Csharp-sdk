using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(SendMessageRequestChannel.SendMessageRequestChannelSerializer))]
[Serializable]
public readonly record struct SendMessageRequestChannel : IStringEnum
{
    public static readonly SendMessageRequestChannel Sms = new(Values.Sms);

    public static readonly SendMessageRequestChannel Mms = new(Values.Mms);

    public static readonly SendMessageRequestChannel Rcs = new(Values.Rcs);

    public SendMessageRequestChannel(string value)
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
    public static SendMessageRequestChannel FromCustom(string value)
    {
        return new SendMessageRequestChannel(value);
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

    public static bool operator ==(SendMessageRequestChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SendMessageRequestChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SendMessageRequestChannel value) => value.Value;

    public static explicit operator SendMessageRequestChannel(string value) => new(value);

    internal class SendMessageRequestChannelSerializer : JsonConverter<SendMessageRequestChannel>
    {
        public override SendMessageRequestChannel Read(
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
            return new SendMessageRequestChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendMessageRequestChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SendMessageRequestChannel ReadAsPropertyName(
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
            return new SendMessageRequestChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendMessageRequestChannel value,
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
