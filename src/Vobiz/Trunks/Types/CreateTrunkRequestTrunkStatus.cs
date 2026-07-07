using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(CreateTrunkRequestTrunkStatus.CreateTrunkRequestTrunkStatusSerializer))]
[Serializable]
public readonly record struct CreateTrunkRequestTrunkStatus : IStringEnum
{
    public static readonly CreateTrunkRequestTrunkStatus Enabled = new(Values.Enabled);

    public static readonly CreateTrunkRequestTrunkStatus Disabled = new(Values.Disabled);

    public CreateTrunkRequestTrunkStatus(string value)
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
    public static CreateTrunkRequestTrunkStatus FromCustom(string value)
    {
        return new CreateTrunkRequestTrunkStatus(value);
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

    public static bool operator ==(CreateTrunkRequestTrunkStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTrunkRequestTrunkStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTrunkRequestTrunkStatus value) => value.Value;

    public static explicit operator CreateTrunkRequestTrunkStatus(string value) => new(value);

    internal class CreateTrunkRequestTrunkStatusSerializer
        : JsonConverter<CreateTrunkRequestTrunkStatus>
    {
        public override CreateTrunkRequestTrunkStatus Read(
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
            return new CreateTrunkRequestTrunkStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTrunkRequestTrunkStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTrunkRequestTrunkStatus ReadAsPropertyName(
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
            return new CreateTrunkRequestTrunkStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTrunkRequestTrunkStatus value,
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
