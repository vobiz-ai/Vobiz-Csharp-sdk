using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(SubAccountKycStatusKycMode.SubAccountKycStatusKycModeSerializer))]
[Serializable]
public readonly record struct SubAccountKycStatusKycMode : IStringEnum
{
    public static readonly SubAccountKycStatusKycMode PersonalUse = new(Values.PersonalUse);

    public static readonly SubAccountKycStatusKycMode CustomerUse = new(Values.CustomerUse);

    public SubAccountKycStatusKycMode(string value)
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
    public static SubAccountKycStatusKycMode FromCustom(string value)
    {
        return new SubAccountKycStatusKycMode(value);
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

    public static bool operator ==(SubAccountKycStatusKycMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubAccountKycStatusKycMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubAccountKycStatusKycMode value) => value.Value;

    public static explicit operator SubAccountKycStatusKycMode(string value) => new(value);

    internal class SubAccountKycStatusKycModeSerializer : JsonConverter<SubAccountKycStatusKycMode>
    {
        public override SubAccountKycStatusKycMode Read(
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
            return new SubAccountKycStatusKycMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubAccountKycStatusKycMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubAccountKycStatusKycMode ReadAsPropertyName(
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
            return new SubAccountKycStatusKycMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubAccountKycStatusKycMode value,
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
        public const string PersonalUse = "personal_use";

        public const string CustomerUse = "customer_use";
    }
}
