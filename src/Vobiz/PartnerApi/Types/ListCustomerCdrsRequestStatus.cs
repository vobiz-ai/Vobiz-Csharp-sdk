using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ListCustomerCdrsRequestStatus.ListCustomerCdrsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListCustomerCdrsRequestStatus : IStringEnum
{
    public static readonly ListCustomerCdrsRequestStatus Answered = new(Values.Answered);

    public static readonly ListCustomerCdrsRequestStatus Failed = new(Values.Failed);

    public static readonly ListCustomerCdrsRequestStatus Busy = new(Values.Busy);

    public static readonly ListCustomerCdrsRequestStatus NoAnswer = new(Values.NoAnswer);

    public ListCustomerCdrsRequestStatus(string value)
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
    public static ListCustomerCdrsRequestStatus FromCustom(string value)
    {
        return new ListCustomerCdrsRequestStatus(value);
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

    public static bool operator ==(ListCustomerCdrsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCustomerCdrsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCustomerCdrsRequestStatus value) => value.Value;

    public static explicit operator ListCustomerCdrsRequestStatus(string value) => new(value);

    internal class ListCustomerCdrsRequestStatusSerializer
        : JsonConverter<ListCustomerCdrsRequestStatus>
    {
        public override ListCustomerCdrsRequestStatus Read(
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
            return new ListCustomerCdrsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCustomerCdrsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCustomerCdrsRequestStatus ReadAsPropertyName(
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
            return new ListCustomerCdrsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCustomerCdrsRequestStatus value,
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
        public const string Answered = "answered";

        public const string Failed = "failed";

        public const string Busy = "busy";

        public const string NoAnswer = "no_answer";
    }
}
