using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ApplicationSipTransferMethod.ApplicationSipTransferMethodSerializer))]
[Serializable]
public readonly record struct ApplicationSipTransferMethod : IStringEnum
{
    public static readonly ApplicationSipTransferMethod Get = new(Values.Get);

    public static readonly ApplicationSipTransferMethod Post = new(Values.Post);

    public ApplicationSipTransferMethod(string value)
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
    public static ApplicationSipTransferMethod FromCustom(string value)
    {
        return new ApplicationSipTransferMethod(value);
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

    public static bool operator ==(ApplicationSipTransferMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ApplicationSipTransferMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ApplicationSipTransferMethod value) => value.Value;

    public static explicit operator ApplicationSipTransferMethod(string value) => new(value);

    internal class ApplicationSipTransferMethodSerializer
        : JsonConverter<ApplicationSipTransferMethod>
    {
        public override ApplicationSipTransferMethod Read(
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
            return new ApplicationSipTransferMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApplicationSipTransferMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApplicationSipTransferMethod ReadAsPropertyName(
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
            return new ApplicationSipTransferMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApplicationSipTransferMethod value,
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
