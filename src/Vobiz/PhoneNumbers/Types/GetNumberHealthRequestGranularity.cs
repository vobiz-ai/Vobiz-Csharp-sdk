using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(GetNumberHealthRequestGranularity.GetNumberHealthRequestGranularitySerializer)
)]
[Serializable]
public readonly record struct GetNumberHealthRequestGranularity : IStringEnum
{
    public static readonly GetNumberHealthRequestGranularity Daily = new(Values.Daily);

    public static readonly GetNumberHealthRequestGranularity Hourly = new(Values.Hourly);

    public GetNumberHealthRequestGranularity(string value)
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
    public static GetNumberHealthRequestGranularity FromCustom(string value)
    {
        return new GetNumberHealthRequestGranularity(value);
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

    public static bool operator ==(GetNumberHealthRequestGranularity value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetNumberHealthRequestGranularity value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetNumberHealthRequestGranularity value) => value.Value;

    public static explicit operator GetNumberHealthRequestGranularity(string value) => new(value);

    internal class GetNumberHealthRequestGranularitySerializer
        : JsonConverter<GetNumberHealthRequestGranularity>
    {
        public override GetNumberHealthRequestGranularity Read(
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
            return new GetNumberHealthRequestGranularity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetNumberHealthRequestGranularity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetNumberHealthRequestGranularity ReadAsPropertyName(
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
            return new GetNumberHealthRequestGranularity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetNumberHealthRequestGranularity value,
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
        public const string Daily = "daily";

        public const string Hourly = "hourly";
    }
}
