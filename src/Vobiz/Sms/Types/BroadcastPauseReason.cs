using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BroadcastPauseReason.BroadcastPauseReasonSerializer))]
[Serializable]
public readonly record struct BroadcastPauseReason : IStringEnum
{
    public static readonly BroadcastPauseReason InsufficientBalance = new(
        Values.InsufficientBalance
    );

    public BroadcastPauseReason(string value)
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
    public static BroadcastPauseReason FromCustom(string value)
    {
        return new BroadcastPauseReason(value);
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

    public static bool operator ==(BroadcastPauseReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BroadcastPauseReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BroadcastPauseReason value) => value.Value;

    public static explicit operator BroadcastPauseReason(string value) => new(value);

    internal class BroadcastPauseReasonSerializer : JsonConverter<BroadcastPauseReason>
    {
        public override BroadcastPauseReason Read(
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
            return new BroadcastPauseReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BroadcastPauseReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BroadcastPauseReason ReadAsPropertyName(
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
            return new BroadcastPauseReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BroadcastPauseReason value,
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
        public const string InsufficientBalance = "insufficient_balance";
    }
}
