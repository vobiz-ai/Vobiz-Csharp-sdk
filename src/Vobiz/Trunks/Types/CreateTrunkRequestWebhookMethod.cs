using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(CreateTrunkRequestWebhookMethod.CreateTrunkRequestWebhookMethodSerializer))]
[Serializable]
public readonly record struct CreateTrunkRequestWebhookMethod : IStringEnum
{
    public static readonly CreateTrunkRequestWebhookMethod Post = new(Values.Post);

    public static readonly CreateTrunkRequestWebhookMethod Get = new(Values.Get);

    public CreateTrunkRequestWebhookMethod(string value)
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
    public static CreateTrunkRequestWebhookMethod FromCustom(string value)
    {
        return new CreateTrunkRequestWebhookMethod(value);
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

    public static bool operator ==(CreateTrunkRequestWebhookMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTrunkRequestWebhookMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTrunkRequestWebhookMethod value) => value.Value;

    public static explicit operator CreateTrunkRequestWebhookMethod(string value) => new(value);

    internal class CreateTrunkRequestWebhookMethodSerializer
        : JsonConverter<CreateTrunkRequestWebhookMethod>
    {
        public override CreateTrunkRequestWebhookMethod Read(
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
            return new CreateTrunkRequestWebhookMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTrunkRequestWebhookMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTrunkRequestWebhookMethod ReadAsPropertyName(
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
            return new CreateTrunkRequestWebhookMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTrunkRequestWebhookMethod value,
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
        public const string Post = "POST";

        public const string Get = "GET";
    }
}
