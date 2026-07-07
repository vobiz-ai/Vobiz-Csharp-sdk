using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(UpdateTrunkRequestTrunkStatus.UpdateTrunkRequestTrunkStatusSerializer))]
[Serializable]
public readonly record struct UpdateTrunkRequestTrunkStatus : IStringEnum
{
    public static readonly UpdateTrunkRequestTrunkStatus Enabled = new(Values.Enabled);

    public static readonly UpdateTrunkRequestTrunkStatus Disabled = new(Values.Disabled);

    public UpdateTrunkRequestTrunkStatus(string value)
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
    public static UpdateTrunkRequestTrunkStatus FromCustom(string value)
    {
        return new UpdateTrunkRequestTrunkStatus(value);
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

    public static bool operator ==(UpdateTrunkRequestTrunkStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTrunkRequestTrunkStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTrunkRequestTrunkStatus value) => value.Value;

    public static explicit operator UpdateTrunkRequestTrunkStatus(string value) => new(value);

    internal class UpdateTrunkRequestTrunkStatusSerializer
        : JsonConverter<UpdateTrunkRequestTrunkStatus>
    {
        public override UpdateTrunkRequestTrunkStatus Read(
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
            return new UpdateTrunkRequestTrunkStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTrunkRequestTrunkStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTrunkRequestTrunkStatus ReadAsPropertyName(
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
            return new UpdateTrunkRequestTrunkStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTrunkRequestTrunkStatus value,
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
        public const string Enabled = "enabled";

        public const string Disabled = "disabled";
    }
}
