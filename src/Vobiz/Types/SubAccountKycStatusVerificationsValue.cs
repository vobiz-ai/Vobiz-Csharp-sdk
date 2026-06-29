using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(SubAccountKycStatusVerificationsValue.SubAccountKycStatusVerificationsValueSerializer)
)]
[Serializable]
public readonly record struct SubAccountKycStatusVerificationsValue : IStringEnum
{
    public static readonly SubAccountKycStatusVerificationsValue NotStarted = new(
        Values.NotStarted
    );

    public static readonly SubAccountKycStatusVerificationsValue Pending = new(Values.Pending);

    public static readonly SubAccountKycStatusVerificationsValue Verified = new(Values.Verified);

    public static readonly SubAccountKycStatusVerificationsValue Failed = new(Values.Failed);

    public SubAccountKycStatusVerificationsValue(string value)
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
    public static SubAccountKycStatusVerificationsValue FromCustom(string value)
    {
        return new SubAccountKycStatusVerificationsValue(value);
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

    public static bool operator ==(SubAccountKycStatusVerificationsValue value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubAccountKycStatusVerificationsValue value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubAccountKycStatusVerificationsValue value) =>
        value.Value;

    public static explicit operator SubAccountKycStatusVerificationsValue(string value) =>
        new(value);

    internal class SubAccountKycStatusVerificationsValueSerializer
        : JsonConverter<SubAccountKycStatusVerificationsValue>
    {
        public override SubAccountKycStatusVerificationsValue Read(
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
            return new SubAccountKycStatusVerificationsValue(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubAccountKycStatusVerificationsValue value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubAccountKycStatusVerificationsValue ReadAsPropertyName(
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
            return new SubAccountKycStatusVerificationsValue(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubAccountKycStatusVerificationsValue value,
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
        public const string NotStarted = "not_started";

        public const string Pending = "pending";

        public const string Verified = "verified";

        public const string Failed = "failed";
    }
}
