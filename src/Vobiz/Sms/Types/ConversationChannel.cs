using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(ConversationChannel.ConversationChannelSerializer))]
[Serializable]
public readonly record struct ConversationChannel : IStringEnum
{
    public static readonly ConversationChannel Sms = new(Values.Sms);

    public static readonly ConversationChannel Mms = new(Values.Mms);

    public static readonly ConversationChannel Rcs = new(Values.Rcs);

    public ConversationChannel(string value)
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
    public static ConversationChannel FromCustom(string value)
    {
        return new ConversationChannel(value);
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

    public static bool operator ==(ConversationChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationChannel value) => value.Value;

    public static explicit operator ConversationChannel(string value) => new(value);

    internal class ConversationChannelSerializer : JsonConverter<ConversationChannel>
    {
        public override ConversationChannel Read(
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
            return new ConversationChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationChannel ReadAsPropertyName(
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
            return new ConversationChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationChannel value,
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
