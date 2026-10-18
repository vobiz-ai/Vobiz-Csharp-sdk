using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(BrandBrandType.BrandBrandTypeSerializer))]
[Serializable]
public readonly record struct BrandBrandType : IStringEnum
{
    public static readonly BrandBrandType TendlcPrivateCompany = new(Values.TendlcPrivateCompany);

    public static readonly BrandBrandType TendlcPublicCompany = new(Values.TendlcPublicCompany);

    public static readonly BrandBrandType TendlcNonProfit = new(Values.TendlcNonProfit);

    public static readonly BrandBrandType TendlcGovernment = new(Values.TendlcGovernment);

    public static readonly BrandBrandType TollFreeNumber = new(Values.TollFreeNumber);

    public BrandBrandType(string value)
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
    public static BrandBrandType FromCustom(string value)
    {
        return new BrandBrandType(value);
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

    public static bool operator ==(BrandBrandType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrandBrandType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrandBrandType value) => value.Value;

    public static explicit operator BrandBrandType(string value) => new(value);

    internal class BrandBrandTypeSerializer : JsonConverter<BrandBrandType>
    {
        public override BrandBrandType Read(
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
            return new BrandBrandType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandBrandType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BrandBrandType ReadAsPropertyName(
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
            return new BrandBrandType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandBrandType value,
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
        public const string TendlcPrivateCompany = "TENDLC_PRIVATE_COMPANY";

        public const string TendlcPublicCompany = "TENDLC_PUBLIC_COMPANY";

        public const string TendlcNonProfit = "TENDLC_NON_PROFIT";

        public const string TendlcGovernment = "TENDLC_GOVERNMENT";

        public const string TollFreeNumber = "TOLL_FREE_NUMBER";
    }
}
