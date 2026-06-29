using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ListLiveCallsRequestStatus.ListLiveCallsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListLiveCallsRequestStatus : IStringEnum
{
    public static readonly ListLiveCallsRequestStatus Live = new(Values.Live);

    public static readonly ListLiveCallsRequestStatus Queued = new(Values.Queued);

    public ListLiveCallsRequestStatus(string value)
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
    public static ListLiveCallsRequestStatus FromCustom(string value)
    {
        return new ListLiveCallsRequestStatus(value);
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

    public static bool operator ==(ListLiveCallsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListLiveCallsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListLiveCallsRequestStatus value) => value.Value;

    public static explicit operator ListLiveCallsRequestStatus(string value) => new(value);

    internal class ListLiveCallsRequestStatusSerializer : JsonConverter<ListLiveCallsRequestStatus>
    {
        public override ListLiveCallsRequestStatus Read(
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
            return new ListLiveCallsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListLiveCallsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListLiveCallsRequestStatus ReadAsPropertyName(
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
            return new ListLiveCallsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListLiveCallsRequestStatus value,
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
