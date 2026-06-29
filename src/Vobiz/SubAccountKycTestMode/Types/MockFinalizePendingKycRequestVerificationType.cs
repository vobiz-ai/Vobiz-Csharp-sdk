using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(MockFinalizePendingKycRequestVerificationType.MockFinalizePendingKycRequestVerificationTypeSerializer)
)]
[Serializable]
public readonly record struct MockFinalizePendingKycRequestVerificationType : IStringEnum
{
    public static readonly MockFinalizePendingKycRequestVerificationType Pan = new(Values.Pan);

    public static readonly MockFinalizePendingKycRequestVerificationType Aadhaar = new(
        Values.Aadhaar
    );

    public static readonly MockFinalizePendingKycRequestVerificationType Gst = new(Values.Gst);

    public static readonly MockFinalizePendingKycRequestVerificationType Cin = new(Values.Cin);

    public MockFinalizePendingKycRequestVerificationType(string value)
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
    public static MockFinalizePendingKycRequestVerificationType FromCustom(string value)
    {
        return new MockFinalizePendingKycRequestVerificationType(value);
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

    public static bool operator ==(
        MockFinalizePendingKycRequestVerificationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        MockFinalizePendingKycRequestVerificationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(MockFinalizePendingKycRequestVerificationType value) =>
        value.Value;

    public static explicit operator MockFinalizePendingKycRequestVerificationType(string value) =>
        new(value);

    internal class MockFinalizePendingKycRequestVerificationTypeSerializer
        : JsonConverter<MockFinalizePendingKycRequestVerificationType>
    {
        public override MockFinalizePendingKycRequestVerificationType Read(
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
            return new MockFinalizePendingKycRequestVerificationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MockFinalizePendingKycRequestVerificationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MockFinalizePendingKycRequestVerificationType ReadAsPropertyName(
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
            return new MockFinalizePendingKycRequestVerificationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MockFinalizePendingKycRequestVerificationType value,
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

        public const string Aadhaar = "aadhaar";

        public const string Gst = "gst";

        public const string Cin = "cin";
    }
}
