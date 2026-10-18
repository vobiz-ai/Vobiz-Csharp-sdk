using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(CreateBrandRequestBrandType.CreateBrandRequestBrandTypeSerializer))]
[Serializable]
public readonly record struct CreateBrandRequestBrandType : IStringEnum
{
    public static readonly CreateBrandRequestBrandType TendlcPrivateCompany = new(
        Values.TendlcPrivateCompany
    );

    public static readonly CreateBrandRequestBrandType TendlcPublicCompany = new(
        Values.TendlcPublicCompany
    );

    public static readonly CreateBrandRequestBrandType TendlcNonProfit = new(
        Values.TendlcNonProfit
    );

    public static readonly CreateBrandRequestBrandType TendlcGovernment = new(
        Values.TendlcGovernment
    );

    public static readonly CreateBrandRequestBrandType TollFreeNumber = new(Values.TollFreeNumber);

    public CreateBrandRequestBrandType(string value)
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
    public static CreateBrandRequestBrandType FromCustom(string value)
    {
        return new CreateBrandRequestBrandType(value);
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

    public static bool operator ==(CreateBrandRequestBrandType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBrandRequestBrandType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBrandRequestBrandType value) => value.Value;

    public static explicit operator CreateBrandRequestBrandType(string value) => new(value);

    internal class CreateBrandRequestBrandTypeSerializer
        : JsonConverter<CreateBrandRequestBrandType>
    {
        public override CreateBrandRequestBrandType Read(
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
            return new CreateBrandRequestBrandType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBrandRequestBrandType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBrandRequestBrandType ReadAsPropertyName(
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
            return new CreateBrandRequestBrandType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBrandRequestBrandType value,
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
