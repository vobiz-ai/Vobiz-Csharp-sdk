using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(MessageDirection.MessageDirectionSerializer))]
[Serializable]
public readonly record struct MessageDirection : IStringEnum
{
    public static readonly MessageDirection Out = new(Values.Out);

    public static readonly MessageDirection In = new(Values.In);

    public MessageDirection(string value)
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
    public static MessageDirection FromCustom(string value)
    {
        return new MessageDirection(value);
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

    public static bool operator ==(MessageDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageDirection value) => value.Value;

    public static explicit operator MessageDirection(string value) => new(value);

    internal class MessageDirectionSerializer : JsonConverter<MessageDirection>
    {
        public override MessageDirection Read(
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
            return new MessageDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MessageDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MessageDirection ReadAsPropertyName(
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
            return new MessageDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MessageDirection value,
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
        public const string Out = "out";

        public const string In = "in";
    }
}
