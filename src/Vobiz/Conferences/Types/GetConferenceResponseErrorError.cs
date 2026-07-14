using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(GetConferenceResponseErrorError.GetConferenceResponseErrorErrorSerializer))]
[Serializable]
public readonly record struct GetConferenceResponseErrorError : IStringEnum
{
    public static readonly GetConferenceResponseErrorError Failed = new(Values.Failed);

    public GetConferenceResponseErrorError(string value)
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
    public static GetConferenceResponseErrorError FromCustom(string value)
    {
        return new GetConferenceResponseErrorError(value);
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

    public static bool operator ==(GetConferenceResponseErrorError value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetConferenceResponseErrorError value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetConferenceResponseErrorError value) => value.Value;

    public static explicit operator GetConferenceResponseErrorError(string value) => new(value);

    internal class GetConferenceResponseErrorErrorSerializer
        : JsonConverter<GetConferenceResponseErrorError>
    {
        public override GetConferenceResponseErrorError Read(
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
            return new GetConferenceResponseErrorError(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetConferenceResponseErrorError value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetConferenceResponseErrorError ReadAsPropertyName(
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
            return new GetConferenceResponseErrorError(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetConferenceResponseErrorError value,
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
        public const string Failed = "failed";
    }
}
