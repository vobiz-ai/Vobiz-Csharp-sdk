using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(EndpointSipRegistered.EndpointSipRegisteredSerializer))]
[Serializable]
public readonly record struct EndpointSipRegistered : IStringEnum
{
    public static readonly EndpointSipRegistered True = new(Values.True);

    public static readonly EndpointSipRegistered False = new(Values.False);

    public EndpointSipRegistered(string value)
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
    public static EndpointSipRegistered FromCustom(string value)
    {
        return new EndpointSipRegistered(value);
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

    public static bool operator ==(EndpointSipRegistered value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EndpointSipRegistered value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EndpointSipRegistered value) => value.Value;

    public static explicit operator EndpointSipRegistered(string value) => new(value);

    internal class EndpointSipRegisteredSerializer : JsonConverter<EndpointSipRegistered>
    {
        public override EndpointSipRegistered Read(
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
            return new EndpointSipRegistered(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndpointSipRegistered value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EndpointSipRegistered ReadAsPropertyName(
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
            return new EndpointSipRegistered(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EndpointSipRegistered value,
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
        public const string True = "true";

        public const string False = "false";
    }
}
