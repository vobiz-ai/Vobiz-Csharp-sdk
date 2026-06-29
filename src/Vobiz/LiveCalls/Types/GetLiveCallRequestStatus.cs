using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(GetLiveCallRequestStatus.GetLiveCallRequestStatusSerializer))]
[Serializable]
public readonly record struct GetLiveCallRequestStatus : IStringEnum
{
    public static readonly GetLiveCallRequestStatus Live = new(Values.Live);

    public static readonly GetLiveCallRequestStatus Queued = new(Values.Queued);

    public GetLiveCallRequestStatus(string value)
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
    public static GetLiveCallRequestStatus FromCustom(string value)
    {
        return new GetLiveCallRequestStatus(value);
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

    public static bool operator ==(GetLiveCallRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetLiveCallRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetLiveCallRequestStatus value) => value.Value;

    public static explicit operator GetLiveCallRequestStatus(string value) => new(value);

    internal class GetLiveCallRequestStatusSerializer : JsonConverter<GetLiveCallRequestStatus>
    {
        public override GetLiveCallRequestStatus Read(
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
            return new GetLiveCallRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetLiveCallRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetLiveCallRequestStatus ReadAsPropertyName(
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
            return new GetLiveCallRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetLiveCallRequestStatus value,
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
