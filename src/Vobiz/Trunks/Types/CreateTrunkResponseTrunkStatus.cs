using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(CreateTrunkResponseTrunkStatus.CreateTrunkResponseTrunkStatusSerializer))]
[Serializable]
public readonly record struct CreateTrunkResponseTrunkStatus : IStringEnum
{
    public static readonly CreateTrunkResponseTrunkStatus Active = new(Values.Active);

    public static readonly CreateTrunkResponseTrunkStatus Suspended = new(Values.Suspended);

    public CreateTrunkResponseTrunkStatus(string value)
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
    public static CreateTrunkResponseTrunkStatus FromCustom(string value)
    {
        return new CreateTrunkResponseTrunkStatus(value);
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

    public static bool operator ==(CreateTrunkResponseTrunkStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTrunkResponseTrunkStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTrunkResponseTrunkStatus value) => value.Value;

    public static explicit operator CreateTrunkResponseTrunkStatus(string value) => new(value);

    internal class CreateTrunkResponseTrunkStatusSerializer
        : JsonConverter<CreateTrunkResponseTrunkStatus>
    {
        public override CreateTrunkResponseTrunkStatus Read(
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
            return new CreateTrunkResponseTrunkStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTrunkResponseTrunkStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTrunkResponseTrunkStatus ReadAsPropertyName(
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
            return new CreateTrunkResponseTrunkStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTrunkResponseTrunkStatus value,
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
