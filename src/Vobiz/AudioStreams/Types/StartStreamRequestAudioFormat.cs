using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(StartStreamRequestAudioFormat.StartStreamRequestAudioFormatSerializer))]
[Serializable]
public readonly record struct StartStreamRequestAudioFormat : IStringEnum
{
    public static readonly StartStreamRequestAudioFormat Pcm = new(Values.Pcm);

    public static readonly StartStreamRequestAudioFormat Mulaw = new(Values.Mulaw);

    public StartStreamRequestAudioFormat(string value)
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
    public static StartStreamRequestAudioFormat FromCustom(string value)
    {
        return new StartStreamRequestAudioFormat(value);
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

    public static bool operator ==(StartStreamRequestAudioFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StartStreamRequestAudioFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StartStreamRequestAudioFormat value) => value.Value;

    public static explicit operator StartStreamRequestAudioFormat(string value) => new(value);

    internal class StartStreamRequestAudioFormatSerializer
        : JsonConverter<StartStreamRequestAudioFormat>
    {
        public override StartStreamRequestAudioFormat Read(
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
            return new StartStreamRequestAudioFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartStreamRequestAudioFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartStreamRequestAudioFormat ReadAsPropertyName(
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
            return new StartStreamRequestAudioFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartStreamRequestAudioFormat value,
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
        public const string Pcm = "pcm";

        public const string Mulaw = "mulaw";
    }
}
