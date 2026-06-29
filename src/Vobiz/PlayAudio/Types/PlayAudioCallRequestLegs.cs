using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PlayAudioCallRequestLegs.PlayAudioCallRequestLegsSerializer))]
[Serializable]
public readonly record struct PlayAudioCallRequestLegs : IStringEnum
{
    public static readonly PlayAudioCallRequestLegs Aleg = new(Values.Aleg);

    public static readonly PlayAudioCallRequestLegs Bleg = new(Values.Bleg);

    public static readonly PlayAudioCallRequestLegs Both = new(Values.Both);

    public PlayAudioCallRequestLegs(string value)
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
    public static PlayAudioCallRequestLegs FromCustom(string value)
    {
        return new PlayAudioCallRequestLegs(value);
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

    public static bool operator ==(PlayAudioCallRequestLegs value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlayAudioCallRequestLegs value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlayAudioCallRequestLegs value) => value.Value;

    public static explicit operator PlayAudioCallRequestLegs(string value) => new(value);

    internal class PlayAudioCallRequestLegsSerializer : JsonConverter<PlayAudioCallRequestLegs>
    {
        public override PlayAudioCallRequestLegs Read(
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
            return new PlayAudioCallRequestLegs(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlayAudioCallRequestLegs value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlayAudioCallRequestLegs ReadAsPropertyName(
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
            return new PlayAudioCallRequestLegs(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlayAudioCallRequestLegs value,
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
        public const string Aleg = "aleg";

        public const string Bleg = "bleg";

        public const string Both = "both";
    }
}
