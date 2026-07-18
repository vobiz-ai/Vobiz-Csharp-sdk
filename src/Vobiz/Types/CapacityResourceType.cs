using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(CapacityResourceType.CapacityResourceTypeSerializer))]
[Serializable]
public readonly record struct CapacityResourceType : IStringEnum
{
    public static readonly CapacityResourceType ConcurrentCalls = new(Values.ConcurrentCalls);

    public static readonly CapacityResourceType Cps = new(Values.Cps);

    public CapacityResourceType(string value)
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
    public static CapacityResourceType FromCustom(string value)
    {
        return new CapacityResourceType(value);
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

    public static bool operator ==(CapacityResourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CapacityResourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CapacityResourceType value) => value.Value;

    public static explicit operator CapacityResourceType(string value) => new(value);

    internal class CapacityResourceTypeSerializer : JsonConverter<CapacityResourceType>
    {
        public override CapacityResourceType Read(
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
            return new CapacityResourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CapacityResourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CapacityResourceType ReadAsPropertyName(
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
            return new CapacityResourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CapacityResourceType value,
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
        public const string ConcurrentCalls = "concurrent_calls";

        public const string Cps = "cps";
    }
}
