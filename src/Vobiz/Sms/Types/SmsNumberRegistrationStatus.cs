using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(SmsNumberRegistrationStatus.SmsNumberRegistrationStatusSerializer))]
[Serializable]
public readonly record struct SmsNumberRegistrationStatus : IStringEnum
{
    public static readonly SmsNumberRegistrationStatus NotRegistered = new(Values.NotRegistered);

    public static readonly SmsNumberRegistrationStatus Draft = new(Values.Draft);

    public static readonly SmsNumberRegistrationStatus Pending = new(Values.Pending);

    public static readonly SmsNumberRegistrationStatus Approved = new(Values.Approved);

    public static readonly SmsNumberRegistrationStatus Rejected = new(Values.Rejected);

    public static readonly SmsNumberRegistrationStatus NotRequired = new(Values.NotRequired);

    public SmsNumberRegistrationStatus(string value)
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
    public static SmsNumberRegistrationStatus FromCustom(string value)
    {
        return new SmsNumberRegistrationStatus(value);
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

    public static bool operator ==(SmsNumberRegistrationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmsNumberRegistrationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmsNumberRegistrationStatus value) => value.Value;

    public static explicit operator SmsNumberRegistrationStatus(string value) => new(value);

    internal class SmsNumberRegistrationStatusSerializer
        : JsonConverter<SmsNumberRegistrationStatus>
    {
        public override SmsNumberRegistrationStatus Read(
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
            return new SmsNumberRegistrationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmsNumberRegistrationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmsNumberRegistrationStatus ReadAsPropertyName(
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
            return new SmsNumberRegistrationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmsNumberRegistrationStatus value,
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
        public const string NotRegistered = "not_registered";

        public const string Draft = "draft";

        public const string Pending = "pending";

        public const string Approved = "approved";

        public const string Rejected = "rejected";

        public const string NotRequired = "not_required";
    }
}
