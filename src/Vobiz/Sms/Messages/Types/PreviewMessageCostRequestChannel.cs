using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(PreviewMessageCostRequestChannel.PreviewMessageCostRequestChannelSerializer))]
[Serializable]
public readonly record struct PreviewMessageCostRequestChannel : IStringEnum
{
    public static readonly PreviewMessageCostRequestChannel Sms = new(Values.Sms);

    public static readonly PreviewMessageCostRequestChannel Mms = new(Values.Mms);

    public static readonly PreviewMessageCostRequestChannel Rcs = new(Values.Rcs);

    public PreviewMessageCostRequestChannel(string value)
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
    public static PreviewMessageCostRequestChannel FromCustom(string value)
    {
        return new PreviewMessageCostRequestChannel(value);
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

    public static bool operator ==(PreviewMessageCostRequestChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreviewMessageCostRequestChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreviewMessageCostRequestChannel value) => value.Value;

    public static explicit operator PreviewMessageCostRequestChannel(string value) => new(value);

    internal class PreviewMessageCostRequestChannelSerializer
        : JsonConverter<PreviewMessageCostRequestChannel>
    {
        public override PreviewMessageCostRequestChannel Read(
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
            return new PreviewMessageCostRequestChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewMessageCostRequestChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewMessageCostRequestChannel ReadAsPropertyName(
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
            return new PreviewMessageCostRequestChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewMessageCostRequestChannel value,
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
