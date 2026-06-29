using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PartnerNumberStatus.PartnerNumberStatusSerializer))]
[Serializable]
public readonly record struct PartnerNumberStatus : IStringEnum
{
    public static readonly PartnerNumberStatus Active = new(Values.Active);

    public static readonly PartnerNumberStatus Inactive = new(Values.Inactive);

    public static readonly PartnerNumberStatus Expired = new(Values.Expired);

    public PartnerNumberStatus(string value)
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
    public static PartnerNumberStatus FromCustom(string value)
    {
        return new PartnerNumberStatus(value);
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

    public static bool operator ==(PartnerNumberStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartnerNumberStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartnerNumberStatus value) => value.Value;

    public static explicit operator PartnerNumberStatus(string value) => new(value);

    internal class PartnerNumberStatusSerializer : JsonConverter<PartnerNumberStatus>
    {
        public override PartnerNumberStatus Read(
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
            return new PartnerNumberStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PartnerNumberStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PartnerNumberStatus ReadAsPropertyName(
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
            return new PartnerNumberStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PartnerNumberStatus value,
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

        public const string Inactive = "inactive";

        public const string Expired = "expired";
    }
}
