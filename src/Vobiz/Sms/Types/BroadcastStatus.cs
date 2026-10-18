using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BroadcastStatus.BroadcastStatusSerializer))]
[Serializable]
public readonly record struct BroadcastStatus : IStringEnum
{
    public static readonly BroadcastStatus Draft = new(Values.Draft);

    public static readonly BroadcastStatus Scheduled = new(Values.Scheduled);

    public static readonly BroadcastStatus Running = new(Values.Running);

    public static readonly BroadcastStatus Paused = new(Values.Paused);

    public static readonly BroadcastStatus Completed = new(Values.Completed);

    public static readonly BroadcastStatus Cancelled = new(Values.Cancelled);

    public static readonly BroadcastStatus Failed = new(Values.Failed);

    public BroadcastStatus(string value)
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
    public static BroadcastStatus FromCustom(string value)
    {
        return new BroadcastStatus(value);
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

    public static bool operator ==(BroadcastStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BroadcastStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BroadcastStatus value) => value.Value;

    public static explicit operator BroadcastStatus(string value) => new(value);

    internal class BroadcastStatusSerializer : JsonConverter<BroadcastStatus>
    {
        public override BroadcastStatus Read(
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
            return new BroadcastStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BroadcastStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BroadcastStatus ReadAsPropertyName(
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
            return new BroadcastStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BroadcastStatus value,
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
        public const string Draft = "draft";

        public const string Scheduled = "scheduled";

        public const string Running = "running";

        public const string Paused = "paused";

        public const string Completed = "completed";

        public const string Cancelled = "cancelled";

        public const string Failed = "failed";
    }
}
