using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(StartRecordingRequestFileFormat.StartRecordingRequestFileFormatSerializer))]
[Serializable]
public readonly record struct StartRecordingRequestFileFormat : IStringEnum
{
    public static readonly StartRecordingRequestFileFormat Mp3 = new(Values.Mp3);

    public static readonly StartRecordingRequestFileFormat Wav = new(Values.Wav);

    public StartRecordingRequestFileFormat(string value)
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
    public static StartRecordingRequestFileFormat FromCustom(string value)
    {
        return new StartRecordingRequestFileFormat(value);
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

    public static bool operator ==(StartRecordingRequestFileFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StartRecordingRequestFileFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StartRecordingRequestFileFormat value) => value.Value;

    public static explicit operator StartRecordingRequestFileFormat(string value) => new(value);

    internal class StartRecordingRequestFileFormatSerializer
        : JsonConverter<StartRecordingRequestFileFormat>
    {
        public override StartRecordingRequestFileFormat Read(
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
            return new StartRecordingRequestFileFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartRecordingRequestFileFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartRecordingRequestFileFormat ReadAsPropertyName(
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
            return new StartRecordingRequestFileFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartRecordingRequestFileFormat value,
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
        public const string Mp3 = "mp3";

        public const string Wav = "wav";
    }
}
