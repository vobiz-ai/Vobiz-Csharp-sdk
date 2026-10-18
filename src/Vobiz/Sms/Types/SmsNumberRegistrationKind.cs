using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(SmsNumberRegistrationKind.SmsNumberRegistrationKindSerializer))]
[Serializable]
public readonly record struct SmsNumberRegistrationKind : IStringEnum
{
    public static readonly SmsNumberRegistrationKind TenDlc = new(Values.TenDlc);

    public static readonly SmsNumberRegistrationKind TollFree = new(Values.TollFree);

    public static readonly SmsNumberRegistrationKind None = new(Values.None);

    public SmsNumberRegistrationKind(string value)
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
    public static SmsNumberRegistrationKind FromCustom(string value)
    {
        return new SmsNumberRegistrationKind(value);
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

    public static bool operator ==(SmsNumberRegistrationKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmsNumberRegistrationKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmsNumberRegistrationKind value) => value.Value;

    public static explicit operator SmsNumberRegistrationKind(string value) => new(value);

    internal class SmsNumberRegistrationKindSerializer : JsonConverter<SmsNumberRegistrationKind>
    {
        public override SmsNumberRegistrationKind Read(
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
            return new SmsNumberRegistrationKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmsNumberRegistrationKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmsNumberRegistrationKind ReadAsPropertyName(
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
            return new SmsNumberRegistrationKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmsNumberRegistrationKind value,
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
        public const string TenDlc = "10dlc";

        public const string TollFree = "toll_free";

        public const string None = "none";
    }
}
