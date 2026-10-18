using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(CampaignCampaignType.CampaignCampaignTypeSerializer))]
[Serializable]
public readonly record struct CampaignCampaignType : IStringEnum
{
    public static readonly CampaignCampaignType TenDigitLongCode = new(Values.TenDigitLongCode);

    public static readonly CampaignCampaignType TollFreeUnifiedNumber = new(
        Values.TollFreeUnifiedNumber
    );

    public static readonly CampaignCampaignType TollFreeNumber = new(Values.TollFreeNumber);

    public static readonly CampaignCampaignType ShortCode = new(Values.ShortCode);

    public static readonly CampaignCampaignType ExternalTenDigitLongCode = new(
        Values.ExternalTenDigitLongCode
    );

    public static readonly CampaignCampaignType Dca2TenDigitLongCode = new(
        Values.Dca2TenDigitLongCode
    );

    public static readonly CampaignCampaignType TollFreeExternallyVerified = new(
        Values.TollFreeExternallyVerified
    );

    public static readonly CampaignCampaignType RcsSenderLaunch = new(Values.RcsSenderLaunch);

    public CampaignCampaignType(string value)
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
    public static CampaignCampaignType FromCustom(string value)
    {
        return new CampaignCampaignType(value);
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

    public static bool operator ==(CampaignCampaignType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CampaignCampaignType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CampaignCampaignType value) => value.Value;

    public static explicit operator CampaignCampaignType(string value) => new(value);

    internal class CampaignCampaignTypeSerializer : JsonConverter<CampaignCampaignType>
    {
        public override CampaignCampaignType Read(
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
            return new CampaignCampaignType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CampaignCampaignType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CampaignCampaignType ReadAsPropertyName(
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
            return new CampaignCampaignType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CampaignCampaignType value,
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

        public const string TollFreeUnifiedNumber = "TOLL_FREE_UNIFIED_NUMBER";

        public const string TollFreeNumber = "TOLL_FREE_NUMBER";

        public const string ShortCode = "SHORT_CODE";

        public const string ExternalTenDigitLongCode = "EXTERNAL_TEN_DIGIT_LONG_CODE";

        public const string Dca2TenDigitLongCode = "DCA2_TEN_DIGIT_LONG_CODE";

        public const string TollFreeExternallyVerified = "TOLL_FREE_EXTERNALLY_VERIFIED";

        public const string RcsSenderLaunch = "RCS_SENDER_LAUNCH";
    }
}
