using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(KycVerificationResultVerificationType.KycVerificationResultVerificationTypeSerializer)
)]
[Serializable]
public readonly record struct KycVerificationResultVerificationType : IStringEnum
{
    public static readonly KycVerificationResultVerificationType Pan = new(Values.Pan);

    public static readonly KycVerificationResultVerificationType Gst = new(Values.Gst);

    public static readonly KycVerificationResultVerificationType Cin = new(Values.Cin);

    public static readonly KycVerificationResultVerificationType Aadhaar = new(Values.Aadhaar);

    public KycVerificationResultVerificationType(string value)
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
    public static KycVerificationResultVerificationType FromCustom(string value)
    {
        return new KycVerificationResultVerificationType(value);
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

    public static bool operator ==(KycVerificationResultVerificationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KycVerificationResultVerificationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KycVerificationResultVerificationType value) =>
        value.Value;

    public static explicit operator KycVerificationResultVerificationType(string value) =>
        new(value);

    internal class KycVerificationResultVerificationTypeSerializer
        : JsonConverter<KycVerificationResultVerificationType>
    {
        public override KycVerificationResultVerificationType Read(
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
            return new KycVerificationResultVerificationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KycVerificationResultVerificationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KycVerificationResultVerificationType ReadAsPropertyName(
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
            return new KycVerificationResultVerificationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KycVerificationResultVerificationType value,
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
        public const string Pan = "pan";

        public const string Gst = "gst";

        public const string Cin = "cin";

        public const string Aadhaar = "aadhaar";
    }
}
