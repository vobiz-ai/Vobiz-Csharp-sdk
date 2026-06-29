using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(MockFinalizePendingKycRequestOutcome.MockFinalizePendingKycRequestOutcomeSerializer)
)]
[Serializable]
public readonly record struct MockFinalizePendingKycRequestOutcome : IStringEnum
{
    public static readonly MockFinalizePendingKycRequestOutcome Verified = new(Values.Verified);

    public static readonly MockFinalizePendingKycRequestOutcome Failed = new(Values.Failed);

    public MockFinalizePendingKycRequestOutcome(string value)
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
    public static MockFinalizePendingKycRequestOutcome FromCustom(string value)
    {
        return new MockFinalizePendingKycRequestOutcome(value);
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

    public static bool operator ==(MockFinalizePendingKycRequestOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MockFinalizePendingKycRequestOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MockFinalizePendingKycRequestOutcome value) =>
        value.Value;

    public static explicit operator MockFinalizePendingKycRequestOutcome(string value) =>
        new(value);

    internal class MockFinalizePendingKycRequestOutcomeSerializer
        : JsonConverter<MockFinalizePendingKycRequestOutcome>
    {
        public override MockFinalizePendingKycRequestOutcome Read(
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
            return new MockFinalizePendingKycRequestOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MockFinalizePendingKycRequestOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MockFinalizePendingKycRequestOutcome ReadAsPropertyName(
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
            return new MockFinalizePendingKycRequestOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MockFinalizePendingKycRequestOutcome value,
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
    }
}
