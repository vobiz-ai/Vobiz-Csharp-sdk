using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(SmsNumberChannelsItem.SmsNumberChannelsItemSerializer))]
[Serializable]
public readonly record struct SmsNumberChannelsItem : IStringEnum
{
    public static readonly SmsNumberChannelsItem Sms = new(Values.Sms);

    public static readonly SmsNumberChannelsItem Mms = new(Values.Mms);

    public static readonly SmsNumberChannelsItem Rcs = new(Values.Rcs);

    public SmsNumberChannelsItem(string value)
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
    public static SmsNumberChannelsItem FromCustom(string value)
    {
        return new SmsNumberChannelsItem(value);
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

    public static bool operator ==(SmsNumberChannelsItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmsNumberChannelsItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmsNumberChannelsItem value) => value.Value;

    public static explicit operator SmsNumberChannelsItem(string value) => new(value);

    internal class SmsNumberChannelsItemSerializer : JsonConverter<SmsNumberChannelsItem>
    {
        public override SmsNumberChannelsItem Read(
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
            return new SmsNumberChannelsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmsNumberChannelsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmsNumberChannelsItem ReadAsPropertyName(
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
            return new SmsNumberChannelsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmsNumberChannelsItem value,
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
