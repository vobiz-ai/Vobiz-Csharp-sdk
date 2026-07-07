using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(CreateTrunkRequestTrunkDirection.CreateTrunkRequestTrunkDirectionSerializer))]
[Serializable]
public readonly record struct CreateTrunkRequestTrunkDirection : IStringEnum
{
    public static readonly CreateTrunkRequestTrunkDirection Inbound = new(Values.Inbound);

    public static readonly CreateTrunkRequestTrunkDirection Outbound = new(Values.Outbound);

    public CreateTrunkRequestTrunkDirection(string value)
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
    public static CreateTrunkRequestTrunkDirection FromCustom(string value)
    {
        return new CreateTrunkRequestTrunkDirection(value);
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

    public static bool operator ==(CreateTrunkRequestTrunkDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTrunkRequestTrunkDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTrunkRequestTrunkDirection value) => value.Value;

    public static explicit operator CreateTrunkRequestTrunkDirection(string value) => new(value);

    internal class CreateTrunkRequestTrunkDirectionSerializer
        : JsonConverter<CreateTrunkRequestTrunkDirection>
    {
        public override CreateTrunkRequestTrunkDirection Read(
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
            return new CreateTrunkRequestTrunkDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTrunkRequestTrunkDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTrunkRequestTrunkDirection ReadAsPropertyName(
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
            return new CreateTrunkRequestTrunkDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTrunkRequestTrunkDirection value,
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
        public const string Inbound = "inbound";

        public const string Outbound = "outbound";
    }
}
