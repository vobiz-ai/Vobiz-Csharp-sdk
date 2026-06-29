using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PartnerCdrDirection.PartnerCdrDirectionSerializer))]
[Serializable]
public readonly record struct PartnerCdrDirection : IStringEnum
{
    public static readonly PartnerCdrDirection Inbound = new(Values.Inbound);

    public static readonly PartnerCdrDirection Outbound = new(Values.Outbound);

    public PartnerCdrDirection(string value)
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
    public static PartnerCdrDirection FromCustom(string value)
    {
        return new PartnerCdrDirection(value);
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

    public static bool operator ==(PartnerCdrDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartnerCdrDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartnerCdrDirection value) => value.Value;

    public static explicit operator PartnerCdrDirection(string value) => new(value);

    internal class PartnerCdrDirectionSerializer : JsonConverter<PartnerCdrDirection>
    {
        public override PartnerCdrDirection Read(
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
            return new PartnerCdrDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PartnerCdrDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PartnerCdrDirection ReadAsPropertyName(
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
            return new PartnerCdrDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PartnerCdrDirection value,
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
        public const string Inbound = "inbound";

        public const string Outbound = "outbound";
    }
}
