using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(StartStreamRequestAudioTrack.StartStreamRequestAudioTrackSerializer))]
[Serializable]
public readonly record struct StartStreamRequestAudioTrack : IStringEnum
{
    public static readonly StartStreamRequestAudioTrack Inbound = new(Values.Inbound);

    public static readonly StartStreamRequestAudioTrack Outbound = new(Values.Outbound);

    public static readonly StartStreamRequestAudioTrack Both = new(Values.Both);

    public StartStreamRequestAudioTrack(string value)
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
    public static StartStreamRequestAudioTrack FromCustom(string value)
    {
        return new StartStreamRequestAudioTrack(value);
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

    public static bool operator ==(StartStreamRequestAudioTrack value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StartStreamRequestAudioTrack value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StartStreamRequestAudioTrack value) => value.Value;

    public static explicit operator StartStreamRequestAudioTrack(string value) => new(value);

    internal class StartStreamRequestAudioTrackSerializer
        : JsonConverter<StartStreamRequestAudioTrack>
    {
        public override StartStreamRequestAudioTrack Read(
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
            return new StartStreamRequestAudioTrack(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartStreamRequestAudioTrack value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartStreamRequestAudioTrack ReadAsPropertyName(
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
            return new StartStreamRequestAudioTrack(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartStreamRequestAudioTrack value,
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

        public const string Both = "both";
    }
}
