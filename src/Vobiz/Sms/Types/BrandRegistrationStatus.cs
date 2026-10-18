using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BrandRegistrationStatus.BrandRegistrationStatusSerializer))]
[Serializable]
public readonly record struct BrandRegistrationStatus : IStringEnum
{
    public static readonly BrandRegistrationStatus Active = new(Values.Active);

    public static readonly BrandRegistrationStatus Pending = new(Values.Pending);

    public static readonly BrandRegistrationStatus Pending2Fa = new(Values.Pending2Fa);

    public static readonly BrandRegistrationStatus PendingAppeal = new(Values.PendingAppeal);

    public static readonly BrandRegistrationStatus Rejected = new(Values.Rejected);

    public BrandRegistrationStatus(string value)
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
    public static BrandRegistrationStatus FromCustom(string value)
    {
        return new BrandRegistrationStatus(value);
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

    public static bool operator ==(BrandRegistrationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandRegistrationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandRegistrationStatus value) => value.Value;

    public static explicit operator BrandRegistrationStatus(string value) => new(value);

    internal class BrandRegistrationStatusSerializer : JsonConverter<BrandRegistrationStatus>
    {
        public override BrandRegistrationStatus Read(
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
            return new BrandRegistrationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandRegistrationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandRegistrationStatus ReadAsPropertyName(
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
            return new BrandRegistrationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandRegistrationStatus value,
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
        public const string Active = "ACTIVE";

        public const string Pending = "PENDING";

        public const string Pending2Fa = "PENDING_2FA";

        public const string PendingAppeal = "PENDING_APPEAL";

        public const string Rejected = "REJECTED";
    }
}
