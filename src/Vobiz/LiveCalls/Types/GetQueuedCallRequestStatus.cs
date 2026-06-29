using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(GetQueuedCallRequestStatus.GetQueuedCallRequestStatusSerializer))]
[Serializable]
public readonly record struct GetQueuedCallRequestStatus : IStringEnum
{
    public static readonly GetQueuedCallRequestStatus Live = new(Values.Live);

    public static readonly GetQueuedCallRequestStatus Queued = new(Values.Queued);

    public GetQueuedCallRequestStatus(string value)
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
    public static GetQueuedCallRequestStatus FromCustom(string value)
    {
        return new GetQueuedCallRequestStatus(value);
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

    public static bool operator ==(GetQueuedCallRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetQueuedCallRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetQueuedCallRequestStatus value) => value.Value;

    public static explicit operator GetQueuedCallRequestStatus(string value) => new(value);

    internal class GetQueuedCallRequestStatusSerializer : JsonConverter<GetQueuedCallRequestStatus>
    {
        public override GetQueuedCallRequestStatus Read(
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
            return new GetQueuedCallRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetQueuedCallRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetQueuedCallRequestStatus ReadAsPropertyName(
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
            return new GetQueuedCallRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetQueuedCallRequestStatus value,
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
        public const string Live = "live";

        public const string Queued = "queued";
    }
}
