using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(UpdateTrunkResponseTrunkStatus.UpdateTrunkResponseTrunkStatusSerializer))]
[Serializable]
public readonly record struct UpdateTrunkResponseTrunkStatus : IStringEnum
{
    public static readonly UpdateTrunkResponseTrunkStatus Active = new(Values.Active);

    public static readonly UpdateTrunkResponseTrunkStatus Suspended = new(Values.Suspended);

    public UpdateTrunkResponseTrunkStatus(string value)
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
    public static UpdateTrunkResponseTrunkStatus FromCustom(string value)
    {
        return new UpdateTrunkResponseTrunkStatus(value);
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

    public static bool operator ==(UpdateTrunkResponseTrunkStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTrunkResponseTrunkStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTrunkResponseTrunkStatus value) => value.Value;

    public static explicit operator UpdateTrunkResponseTrunkStatus(string value) => new(value);

    internal class UpdateTrunkResponseTrunkStatusSerializer
        : JsonConverter<UpdateTrunkResponseTrunkStatus>
    {
        public override UpdateTrunkResponseTrunkStatus Read(
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
            return new UpdateTrunkResponseTrunkStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTrunkResponseTrunkStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTrunkResponseTrunkStatus ReadAsPropertyName(
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
            return new UpdateTrunkResponseTrunkStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTrunkResponseTrunkStatus value,
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
        public const string Active = "active";

        public const string Suspended = "suspended";
    }
}
