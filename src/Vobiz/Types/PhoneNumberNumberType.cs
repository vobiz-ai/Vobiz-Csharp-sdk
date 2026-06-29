using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(PhoneNumberNumberType.PhoneNumberNumberTypeSerializer))]
[Serializable]
public readonly record struct PhoneNumberNumberType : IStringEnum
{
    public static readonly PhoneNumberNumberType Mobile = new(Values.Mobile);

    public static readonly PhoneNumberNumberType Landline = new(Values.Landline);

    public static readonly PhoneNumberNumberType TollFree = new(Values.TollFree);

    public PhoneNumberNumberType(string value)
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
    public static PhoneNumberNumberType FromCustom(string value)
    {
        return new PhoneNumberNumberType(value);
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

    public static bool operator ==(PhoneNumberNumberType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PhoneNumberNumberType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PhoneNumberNumberType value) => value.Value;

    public static explicit operator PhoneNumberNumberType(string value) => new(value);

    internal class PhoneNumberNumberTypeSerializer : JsonConverter<PhoneNumberNumberType>
    {
        public override PhoneNumberNumberType Read(
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
            return new PhoneNumberNumberType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneNumberNumberType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneNumberNumberType ReadAsPropertyName(
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
            return new PhoneNumberNumberType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneNumberNumberType value,
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
        public const string Mobile = "mobile";

        public const string Landline = "landline";

        public const string TollFree = "toll_free";
    }
}
