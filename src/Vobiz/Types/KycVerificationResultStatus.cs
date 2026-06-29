using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(KycVerificationResultStatus.KycVerificationResultStatusSerializer))]
[Serializable]
public readonly record struct KycVerificationResultStatus : IStringEnum
{
    public static readonly KycVerificationResultStatus Verified = new(Values.Verified);

    public static readonly KycVerificationResultStatus Failed = new(Values.Failed);

    public static readonly KycVerificationResultStatus Pending = new(Values.Pending);

    public KycVerificationResultStatus(string value)
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
    public static KycVerificationResultStatus FromCustom(string value)
    {
        return new KycVerificationResultStatus(value);
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

    public static bool operator ==(KycVerificationResultStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KycVerificationResultStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KycVerificationResultStatus value) => value.Value;

    public static explicit operator KycVerificationResultStatus(string value) => new(value);

    internal class KycVerificationResultStatusSerializer
        : JsonConverter<KycVerificationResultStatus>
    {
        public override KycVerificationResultStatus Read(
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
            return new KycVerificationResultStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KycVerificationResultStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KycVerificationResultStatus ReadAsPropertyName(
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
            return new KycVerificationResultStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KycVerificationResultStatus value,
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
        public const string Verified = "verified";

        public const string Failed = "failed";

        public const string Pending = "pending";
    }
}
