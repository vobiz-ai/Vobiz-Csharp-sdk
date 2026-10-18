using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(
    typeof(CreateCampaignRequestCampaignType.CreateCampaignRequestCampaignTypeSerializer)
)]
[Serializable]
public readonly record struct CreateCampaignRequestCampaignType : IStringEnum
{
    public static readonly CreateCampaignRequestCampaignType TenDigitLongCode = new(
        Values.TenDigitLongCode
    );

    public static readonly CreateCampaignRequestCampaignType ExternalTenDigitLongCode = new(
        Values.ExternalTenDigitLongCode
    );

    public static readonly CreateCampaignRequestCampaignType Dca2TenDigitLongCode = new(
        Values.Dca2TenDigitLongCode
    );

    public static readonly CreateCampaignRequestCampaignType ShortCode = new(Values.ShortCode);

    public static readonly CreateCampaignRequestCampaignType RcsSenderLaunch = new(
        Values.RcsSenderLaunch
    );

    public CreateCampaignRequestCampaignType(string value)
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
    public static CreateCampaignRequestCampaignType FromCustom(string value)
    {
        return new CreateCampaignRequestCampaignType(value);
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

    public static bool operator ==(CreateCampaignRequestCampaignType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateCampaignRequestCampaignType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateCampaignRequestCampaignType value) => value.Value;

    public static explicit operator CreateCampaignRequestCampaignType(string value) => new(value);

    internal class CreateCampaignRequestCampaignTypeSerializer
        : JsonConverter<CreateCampaignRequestCampaignType>
    {
        public override CreateCampaignRequestCampaignType Read(
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
            return new CreateCampaignRequestCampaignType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateCampaignRequestCampaignType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateCampaignRequestCampaignType ReadAsPropertyName(
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
            return new CreateCampaignRequestCampaignType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateCampaignRequestCampaignType value,
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
        public const string TenDigitLongCode = "TEN_DIGIT_LONG_CODE";

        public const string ExternalTenDigitLongCode = "EXTERNAL_TEN_DIGIT_LONG_CODE";

        public const string Dca2TenDigitLongCode = "DCA2_TEN_DIGIT_LONG_CODE";

        public const string ShortCode = "SHORT_CODE";

        public const string RcsSenderLaunch = "RCS_SENDER_LAUNCH";
    }
}
