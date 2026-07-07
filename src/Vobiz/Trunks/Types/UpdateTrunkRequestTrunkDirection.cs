using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(UpdateTrunkRequestTrunkDirection.UpdateTrunkRequestTrunkDirectionSerializer))]
[Serializable]
public readonly record struct UpdateTrunkRequestTrunkDirection : IStringEnum
{
    public static readonly UpdateTrunkRequestTrunkDirection Inbound = new(Values.Inbound);

    public static readonly UpdateTrunkRequestTrunkDirection Outbound = new(Values.Outbound);

    public UpdateTrunkRequestTrunkDirection(string value)
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
    public static UpdateTrunkRequestTrunkDirection FromCustom(string value)
    {
        return new UpdateTrunkRequestTrunkDirection(value);
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

    public static bool operator ==(UpdateTrunkRequestTrunkDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTrunkRequestTrunkDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTrunkRequestTrunkDirection value) => value.Value;

    public static explicit operator UpdateTrunkRequestTrunkDirection(string value) => new(value);

    internal class UpdateTrunkRequestTrunkDirectionSerializer
        : JsonConverter<UpdateTrunkRequestTrunkDirection>
    {
        public override UpdateTrunkRequestTrunkDirection Read(
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
            return new UpdateTrunkRequestTrunkDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTrunkRequestTrunkDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTrunkRequestTrunkDirection ReadAsPropertyName(
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
            return new UpdateTrunkRequestTrunkDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTrunkRequestTrunkDirection value,
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
