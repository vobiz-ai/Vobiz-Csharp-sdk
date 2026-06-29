using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ApplicationFallbackMethod.ApplicationFallbackMethodSerializer))]
[Serializable]
public readonly record struct ApplicationFallbackMethod : IStringEnum
{
    public static readonly ApplicationFallbackMethod Get = new(Values.Get);

    public static readonly ApplicationFallbackMethod Post = new(Values.Post);

    public ApplicationFallbackMethod(string value)
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
    public static ApplicationFallbackMethod FromCustom(string value)
    {
        return new ApplicationFallbackMethod(value);
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

    public static bool operator ==(ApplicationFallbackMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ApplicationFallbackMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ApplicationFallbackMethod value) => value.Value;

    public static explicit operator ApplicationFallbackMethod(string value) => new(value);

    internal class ApplicationFallbackMethodSerializer : JsonConverter<ApplicationFallbackMethod>
    {
        public override ApplicationFallbackMethod Read(
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
            return new ApplicationFallbackMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApplicationFallbackMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApplicationFallbackMethod ReadAsPropertyName(
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
            return new ApplicationFallbackMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApplicationFallbackMethod value,
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
