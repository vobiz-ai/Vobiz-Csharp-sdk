using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ApplicationAnswerMethod.ApplicationAnswerMethodSerializer))]
[Serializable]
public readonly record struct ApplicationAnswerMethod : IStringEnum
{
    public static readonly ApplicationAnswerMethod Get = new(Values.Get);

    public static readonly ApplicationAnswerMethod Post = new(Values.Post);

    public ApplicationAnswerMethod(string value)
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
    public static ApplicationAnswerMethod FromCustom(string value)
    {
        return new ApplicationAnswerMethod(value);
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

    public static bool operator ==(ApplicationAnswerMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ApplicationAnswerMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ApplicationAnswerMethod value) => value.Value;

    public static explicit operator ApplicationAnswerMethod(string value) => new(value);

    internal class ApplicationAnswerMethodSerializer : JsonConverter<ApplicationAnswerMethod>
    {
        public override ApplicationAnswerMethod Read(
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
            return new ApplicationAnswerMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApplicationAnswerMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApplicationAnswerMethod ReadAsPropertyName(
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
            return new ApplicationAnswerMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApplicationAnswerMethod value,
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
        public const string Get = "GET";

        public const string Post = "POST";
    }
}
