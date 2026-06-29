using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(StartConferenceRecordingRequestFileFormat.StartConferenceRecordingRequestFileFormatSerializer)
)]
[Serializable]
public readonly record struct StartConferenceRecordingRequestFileFormat : IStringEnum
{
    public static readonly StartConferenceRecordingRequestFileFormat Mp3 = new(Values.Mp3);

    public static readonly StartConferenceRecordingRequestFileFormat Wav = new(Values.Wav);

    public StartConferenceRecordingRequestFileFormat(string value)
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
    public static StartConferenceRecordingRequestFileFormat FromCustom(string value)
    {
        return new StartConferenceRecordingRequestFileFormat(value);
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

    public static bool operator ==(
        StartConferenceRecordingRequestFileFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        StartConferenceRecordingRequestFileFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(StartConferenceRecordingRequestFileFormat value) =>
        value.Value;

    public static explicit operator StartConferenceRecordingRequestFileFormat(string value) =>
        new(value);

    internal class StartConferenceRecordingRequestFileFormatSerializer
        : JsonConverter<StartConferenceRecordingRequestFileFormat>
    {
        public override StartConferenceRecordingRequestFileFormat Read(
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
            return new StartConferenceRecordingRequestFileFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartConferenceRecordingRequestFileFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartConferenceRecordingRequestFileFormat ReadAsPropertyName(
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
            return new StartConferenceRecordingRequestFileFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartConferenceRecordingRequestFileFormat value,
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
