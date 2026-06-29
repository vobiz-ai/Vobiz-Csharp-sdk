using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PartnerCdrStatus.PartnerCdrStatusSerializer))]
[Serializable]
public readonly record struct PartnerCdrStatus : IStringEnum
{
    public static readonly PartnerCdrStatus Answered = new(Values.Answered);

    public static readonly PartnerCdrStatus Busy = new(Values.Busy);

    public static readonly PartnerCdrStatus Failed = new(Values.Failed);

    public static readonly PartnerCdrStatus NoAnswer = new(Values.NoAnswer);

    public static readonly PartnerCdrStatus Cancelled = new(Values.Cancelled);

    public PartnerCdrStatus(string value)
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
    public static PartnerCdrStatus FromCustom(string value)
    {
        return new PartnerCdrStatus(value);
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

    public static bool operator ==(PartnerCdrStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartnerCdrStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartnerCdrStatus value) => value.Value;

    public static explicit operator PartnerCdrStatus(string value) => new(value);

    internal class PartnerCdrStatusSerializer : JsonConverter<PartnerCdrStatus>
    {
        public override PartnerCdrStatus Read(
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
            return new PartnerCdrStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PartnerCdrStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PartnerCdrStatus ReadAsPropertyName(
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
            return new PartnerCdrStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PartnerCdrStatus value,
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
        public const string Answered = "answered";

        public const string Busy = "busy";

        public const string Failed = "failed";

        public const string NoAnswer = "no-answer";

        public const string Cancelled = "cancelled";
    }
}
