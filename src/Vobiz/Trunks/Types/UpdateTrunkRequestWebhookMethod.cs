using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(UpdateTrunkRequestWebhookMethod.UpdateTrunkRequestWebhookMethodSerializer))]
[Serializable]
public readonly record struct UpdateTrunkRequestWebhookMethod : IStringEnum
{
    public static readonly UpdateTrunkRequestWebhookMethod Post = new(Values.Post);

    public static readonly UpdateTrunkRequestWebhookMethod Get = new(Values.Get);

    public UpdateTrunkRequestWebhookMethod(string value)
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
    public static UpdateTrunkRequestWebhookMethod FromCustom(string value)
    {
        return new UpdateTrunkRequestWebhookMethod(value);
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

    public static bool operator ==(UpdateTrunkRequestWebhookMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTrunkRequestWebhookMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTrunkRequestWebhookMethod value) => value.Value;

    public static explicit operator UpdateTrunkRequestWebhookMethod(string value) => new(value);

    internal class UpdateTrunkRequestWebhookMethodSerializer
        : JsonConverter<UpdateTrunkRequestWebhookMethod>
    {
        public override UpdateTrunkRequestWebhookMethod Read(
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
            return new UpdateTrunkRequestWebhookMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTrunkRequestWebhookMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTrunkRequestWebhookMethod ReadAsPropertyName(
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
            return new UpdateTrunkRequestWebhookMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTrunkRequestWebhookMethod value,
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
