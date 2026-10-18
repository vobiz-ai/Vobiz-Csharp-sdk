using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BrandStage.BrandStageSerializer))]
[Serializable]
public readonly record struct BrandStage : IStringEnum
{
    public static readonly BrandStage Draft = new(Values.Draft);

    public static readonly BrandStage Submitted = new(Values.Submitted);

    public BrandStage(string value)
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
    public static BrandStage FromCustom(string value)
    {
        return new BrandStage(value);
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

    public static bool operator ==(BrandStage value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(BrandStage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandStage value) => value.Value;

    public static explicit operator BrandStage(string value) => new(value);

    internal class BrandStageSerializer : JsonConverter<BrandStage>
    {
        public override BrandStage Read(
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
            return new BrandStage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandStage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandStage ReadAsPropertyName(
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
            return new BrandStage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandStage value,
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
        public const string Draft = "DRAFT";

        public const string Submitted = "SUBMITTED";
    }
}
