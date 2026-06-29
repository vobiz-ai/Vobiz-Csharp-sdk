using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(StartRecordingRequestRecordChannelType.StartRecordingRequestRecordChannelTypeSerializer)
)]
[Serializable]
public readonly record struct StartRecordingRequestRecordChannelType : IStringEnum
{
    public static readonly StartRecordingRequestRecordChannelType Mono = new(Values.Mono);

    public static readonly StartRecordingRequestRecordChannelType Stereo = new(Values.Stereo);

    public StartRecordingRequestRecordChannelType(string value)
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
    public static StartRecordingRequestRecordChannelType FromCustom(string value)
    {
        return new StartRecordingRequestRecordChannelType(value);
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

    public static bool operator ==(StartRecordingRequestRecordChannelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StartRecordingRequestRecordChannelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StartRecordingRequestRecordChannelType value) =>
        value.Value;

    public static explicit operator StartRecordingRequestRecordChannelType(string value) =>
        new(value);

    internal class StartRecordingRequestRecordChannelTypeSerializer
        : JsonConverter<StartRecordingRequestRecordChannelType>
    {
        public override StartRecordingRequestRecordChannelType Read(
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
            return new StartRecordingRequestRecordChannelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartRecordingRequestRecordChannelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartRecordingRequestRecordChannelType ReadAsPropertyName(
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
            return new StartRecordingRequestRecordChannelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartRecordingRequestRecordChannelType value,
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
        public const string Mono = "mono";

        public const string Stereo = "stereo";
    }
}
