using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(SubAccountKycStatusOverallStatus.SubAccountKycStatusOverallStatusSerializer))]
[Serializable]
public readonly record struct SubAccountKycStatusOverallStatus : IStringEnum
{
    public static readonly SubAccountKycStatusOverallStatus NotStarted = new(Values.NotStarted);

    public static readonly SubAccountKycStatusOverallStatus Pending = new(Values.Pending);

    public static readonly SubAccountKycStatusOverallStatus Verified = new(Values.Verified);

    public static readonly SubAccountKycStatusOverallStatus Failed = new(Values.Failed);

    public SubAccountKycStatusOverallStatus(string value)
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
    public static SubAccountKycStatusOverallStatus FromCustom(string value)
    {
        return new SubAccountKycStatusOverallStatus(value);
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

    public static bool operator ==(SubAccountKycStatusOverallStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubAccountKycStatusOverallStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubAccountKycStatusOverallStatus value) => value.Value;

    public static explicit operator SubAccountKycStatusOverallStatus(string value) => new(value);

    internal class SubAccountKycStatusOverallStatusSerializer
        : JsonConverter<SubAccountKycStatusOverallStatus>
    {
        public override SubAccountKycStatusOverallStatus Read(
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
            return new SubAccountKycStatusOverallStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubAccountKycStatusOverallStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubAccountKycStatusOverallStatus ReadAsPropertyName(
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
            return new SubAccountKycStatusOverallStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubAccountKycStatusOverallStatus value,
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
