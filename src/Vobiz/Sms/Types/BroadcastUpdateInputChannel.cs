using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BroadcastUpdateInputChannel.BroadcastUpdateInputChannelSerializer))]
[Serializable]
public readonly record struct BroadcastUpdateInputChannel : IStringEnum
{
    public static readonly BroadcastUpdateInputChannel Sms = new(Values.Sms);

    public BroadcastUpdateInputChannel(string value)
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
    public static BroadcastUpdateInputChannel FromCustom(string value)
    {
        return new BroadcastUpdateInputChannel(value);
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

    public static bool operator ==(BroadcastUpdateInputChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BroadcastUpdateInputChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BroadcastUpdateInputChannel value) => value.Value;

    public static explicit operator BroadcastUpdateInputChannel(string value) => new(value);

    internal class BroadcastUpdateInputChannelSerializer
        : JsonConverter<BroadcastUpdateInputChannel>
    {
        public override BroadcastUpdateInputChannel Read(
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
            return new BroadcastUpdateInputChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BroadcastUpdateInputChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BroadcastUpdateInputChannel ReadAsPropertyName(
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
            return new BroadcastUpdateInputChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BroadcastUpdateInputChannel value,
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
    }
}
