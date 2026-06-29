using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(TrunkTrunkType.TrunkTrunkTypeSerializer))]
[Serializable]
public readonly record struct TrunkTrunkType : IStringEnum
{
    public static readonly TrunkTrunkType Inbound = new(Values.Inbound);

    public static readonly TrunkTrunkType Outbound = new(Values.Outbound);

    public TrunkTrunkType(string value)
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
    public static TrunkTrunkType FromCustom(string value)
    {
        return new TrunkTrunkType(value);
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

    public static bool operator ==(TrunkTrunkType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TrunkTrunkType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TrunkTrunkType value) => value.Value;

    public static explicit operator TrunkTrunkType(string value) => new(value);

    internal class TrunkTrunkTypeSerializer : JsonConverter<TrunkTrunkType>
    {
        public override TrunkTrunkType Read(
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
            return new TrunkTrunkType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TrunkTrunkType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TrunkTrunkType ReadAsPropertyName(
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
            return new TrunkTrunkType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TrunkTrunkType value,
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
        public const string Inbound = "INBOUND";

        public const string Outbound = "OUTBOUND";
    }
}
