using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(RetrieveTrunkResponseTrunkStatus.RetrieveTrunkResponseTrunkStatusSerializer))]
[Serializable]
public readonly record struct RetrieveTrunkResponseTrunkStatus : IStringEnum
{
    public static readonly RetrieveTrunkResponseTrunkStatus Active = new(Values.Active);

    public static readonly RetrieveTrunkResponseTrunkStatus Suspended = new(Values.Suspended);

    public RetrieveTrunkResponseTrunkStatus(string value)
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
    public static RetrieveTrunkResponseTrunkStatus FromCustom(string value)
    {
        return new RetrieveTrunkResponseTrunkStatus(value);
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

    public static bool operator ==(RetrieveTrunkResponseTrunkStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RetrieveTrunkResponseTrunkStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RetrieveTrunkResponseTrunkStatus value) => value.Value;

    public static explicit operator RetrieveTrunkResponseTrunkStatus(string value) => new(value);

    internal class RetrieveTrunkResponseTrunkStatusSerializer
        : JsonConverter<RetrieveTrunkResponseTrunkStatus>
    {
        public override RetrieveTrunkResponseTrunkStatus Read(
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
            return new RetrieveTrunkResponseTrunkStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrieveTrunkResponseTrunkStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrieveTrunkResponseTrunkStatus ReadAsPropertyName(
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
            return new RetrieveTrunkResponseTrunkStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrieveTrunkResponseTrunkStatus value,
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
