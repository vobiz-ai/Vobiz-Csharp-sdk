using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ApplicationMessageMethod.ApplicationMessageMethodSerializer))]
[Serializable]
public readonly record struct ApplicationMessageMethod : IStringEnum
{
    public static readonly ApplicationMessageMethod Get = new(Values.Get);

    public static readonly ApplicationMessageMethod Post = new(Values.Post);

    public ApplicationMessageMethod(string value)
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
    public static ApplicationMessageMethod FromCustom(string value)
    {
        return new ApplicationMessageMethod(value);
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

    public static bool operator ==(ApplicationMessageMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ApplicationMessageMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ApplicationMessageMethod value) => value.Value;

    public static explicit operator ApplicationMessageMethod(string value) => new(value);

    internal class ApplicationMessageMethodSerializer : JsonConverter<ApplicationMessageMethod>
    {
        public override ApplicationMessageMethod Read(
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
            return new ApplicationMessageMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApplicationMessageMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApplicationMessageMethod ReadAsPropertyName(
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
            return new ApplicationMessageMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApplicationMessageMethod value,
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
