using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(MockSubaccountDigilockerVerifyRequestAccessRequestId.MockSubaccountDigilockerVerifyRequestAccessRequestIdSerializer)
)]
[Serializable]
public readonly record struct MockSubaccountDigilockerVerifyRequestAccessRequestId : IStringEnum
{
    public static readonly MockSubaccountDigilockerVerifyRequestAccessRequestId MockArSuccess = new(
        Values.MockArSuccess
    );

    public static readonly MockSubaccountDigilockerVerifyRequestAccessRequestId MockArFail = new(
        Values.MockArFail
    );

    public MockSubaccountDigilockerVerifyRequestAccessRequestId(string value)
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
    public static MockSubaccountDigilockerVerifyRequestAccessRequestId FromCustom(string value)
    {
        return new MockSubaccountDigilockerVerifyRequestAccessRequestId(value);
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
        MockSubaccountDigilockerVerifyRequestAccessRequestId value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        MockSubaccountDigilockerVerifyRequestAccessRequestId value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        MockSubaccountDigilockerVerifyRequestAccessRequestId value
    ) => value.Value;

    public static explicit operator MockSubaccountDigilockerVerifyRequestAccessRequestId(
        string value
    ) => new(value);

    internal class MockSubaccountDigilockerVerifyRequestAccessRequestIdSerializer
        : JsonConverter<MockSubaccountDigilockerVerifyRequestAccessRequestId>
    {
        public override MockSubaccountDigilockerVerifyRequestAccessRequestId Read(
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
            return new MockSubaccountDigilockerVerifyRequestAccessRequestId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MockSubaccountDigilockerVerifyRequestAccessRequestId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MockSubaccountDigilockerVerifyRequestAccessRequestId ReadAsPropertyName(
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
            return new MockSubaccountDigilockerVerifyRequestAccessRequestId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MockSubaccountDigilockerVerifyRequestAccessRequestId value,
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
        public const string MockArSuccess = "MOCK_AR_SUCCESS";

        public const string MockArFail = "MOCK_AR_FAIL";
    }
}
