using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PhoneNumberStatus.PhoneNumberStatusSerializer))]
[Serializable]
public readonly record struct PhoneNumberStatus : IStringEnum
{
    public static readonly PhoneNumberStatus Active = new(Values.Active);

    public static readonly PhoneNumberStatus Inactive = new(Values.Inactive);

    public PhoneNumberStatus(string value)
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
    public static PhoneNumberStatus FromCustom(string value)
    {
        return new PhoneNumberStatus(value);
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

    public static bool operator ==(PhoneNumberStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PhoneNumberStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PhoneNumberStatus value) => value.Value;

    public static explicit operator PhoneNumberStatus(string value) => new(value);

    internal class PhoneNumberStatusSerializer : JsonConverter<PhoneNumberStatus>
    {
        public override PhoneNumberStatus Read(
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
            return new PhoneNumberStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneNumberStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneNumberStatus ReadAsPropertyName(
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
            return new PhoneNumberStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneNumberStatus value,
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
    }
}
