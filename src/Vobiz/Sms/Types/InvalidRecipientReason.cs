using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(InvalidRecipientReason.InvalidRecipientReasonSerializer))]
[Serializable]
public readonly record struct InvalidRecipientReason : IStringEnum
{
    public static readonly InvalidRecipientReason MissingPhoneNumber = new(
        Values.MissingPhoneNumber
    );

    public static readonly InvalidRecipientReason ContainsLettersOrSymbols = new(
        Values.ContainsLettersOrSymbols
    );

    public static readonly InvalidRecipientReason TooShort = new(Values.TooShort);

    public static readonly InvalidRecipientReason TooLong = new(Values.TooLong);

    public static readonly InvalidRecipientReason NotAValidUsCanadaNumber = new(
        Values.NotAValidUsCanadaNumber
    );

    public static readonly InvalidRecipientReason NotAValidIndianMobileNumber = new(
        Values.NotAValidIndianMobileNumber
    );

    public static readonly InvalidRecipientReason UnsupportedDefaultCountry = new(
        Values.UnsupportedDefaultCountry
    );

    public InvalidRecipientReason(string value)
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
    public static InvalidRecipientReason FromCustom(string value)
    {
        return new InvalidRecipientReason(value);
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

    public static bool operator ==(InvalidRecipientReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvalidRecipientReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvalidRecipientReason value) => value.Value;

    public static explicit operator InvalidRecipientReason(string value) => new(value);

    internal class InvalidRecipientReasonSerializer : JsonConverter<InvalidRecipientReason>
    {
        public override InvalidRecipientReason Read(
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
            return new InvalidRecipientReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InvalidRecipientReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InvalidRecipientReason ReadAsPropertyName(
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
            return new InvalidRecipientReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InvalidRecipientReason value,
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
        public const string MissingPhoneNumber = "missing phone number";

        public const string ContainsLettersOrSymbols = "contains letters or symbols";

        public const string TooShort = "too short";

        public const string TooLong = "too long";

        public const string NotAValidUsCanadaNumber = "not a valid US/Canada number";

        public const string NotAValidIndianMobileNumber = "not a valid Indian mobile number";

        public const string UnsupportedDefaultCountry = "unsupported defaultCountry";
    }
}
