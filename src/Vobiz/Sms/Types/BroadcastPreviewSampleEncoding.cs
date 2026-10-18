using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BroadcastPreviewSampleEncoding.BroadcastPreviewSampleEncodingSerializer))]
[Serializable]
public readonly record struct BroadcastPreviewSampleEncoding : IStringEnum
{
    public static readonly BroadcastPreviewSampleEncoding Gsm7 = new(Values.Gsm7);

    public static readonly BroadcastPreviewSampleEncoding Ucs2 = new(Values.Ucs2);

    public BroadcastPreviewSampleEncoding(string value)
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
    public static BroadcastPreviewSampleEncoding FromCustom(string value)
    {
        return new BroadcastPreviewSampleEncoding(value);
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

    public static bool operator ==(BroadcastPreviewSampleEncoding value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BroadcastPreviewSampleEncoding value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BroadcastPreviewSampleEncoding value) => value.Value;

    public static explicit operator BroadcastPreviewSampleEncoding(string value) => new(value);

    internal class BroadcastPreviewSampleEncodingSerializer
        : JsonConverter<BroadcastPreviewSampleEncoding>
    {
        public override BroadcastPreviewSampleEncoding Read(
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
            return new BroadcastPreviewSampleEncoding(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BroadcastPreviewSampleEncoding value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BroadcastPreviewSampleEncoding ReadAsPropertyName(
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
            return new BroadcastPreviewSampleEncoding(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BroadcastPreviewSampleEncoding value,
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
        public const string Gsm7 = "GSM-7";

        public const string Ucs2 = "UCS-2";
    }
}
