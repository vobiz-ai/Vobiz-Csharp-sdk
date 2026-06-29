using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(ListKycSessionsRequestStatus.ListKycSessionsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListKycSessionsRequestStatus : IStringEnum
{
    public static readonly ListKycSessionsRequestStatus EmailSent = new(Values.EmailSent);

    public static readonly ListKycSessionsRequestStatus LinkReady = new(Values.LinkReady);

    public static readonly ListKycSessionsRequestStatus Opened = new(Values.Opened);

    public static readonly ListKycSessionsRequestStatus InProgress = new(Values.InProgress);

    public static readonly ListKycSessionsRequestStatus KycCompleted = new(Values.KycCompleted);

    public static readonly ListKycSessionsRequestStatus Revoked = new(Values.Revoked);

    public ListKycSessionsRequestStatus(string value)
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
    public static ListKycSessionsRequestStatus FromCustom(string value)
    {
        return new ListKycSessionsRequestStatus(value);
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

    public static bool operator ==(ListKycSessionsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListKycSessionsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListKycSessionsRequestStatus value) => value.Value;

    public static explicit operator ListKycSessionsRequestStatus(string value) => new(value);

    internal class ListKycSessionsRequestStatusSerializer
        : JsonConverter<ListKycSessionsRequestStatus>
    {
        public override ListKycSessionsRequestStatus Read(
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
            return new ListKycSessionsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListKycSessionsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListKycSessionsRequestStatus ReadAsPropertyName(
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
            return new ListKycSessionsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListKycSessionsRequestStatus value,
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
        public const string EmailSent = "email_sent";

        public const string LinkReady = "link_ready";

        public const string Opened = "opened";

        public const string InProgress = "in_progress";

        public const string KycCompleted = "kyc_completed";

        public const string Revoked = "revoked";
    }
}
