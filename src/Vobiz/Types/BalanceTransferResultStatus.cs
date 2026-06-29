using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(BalanceTransferResultStatus.BalanceTransferResultStatusSerializer))]
[Serializable]
public readonly record struct BalanceTransferResultStatus : IStringEnum
{
    public static readonly BalanceTransferResultStatus Completed = new(Values.Completed);

    public static readonly BalanceTransferResultStatus Failed = new(Values.Failed);

    public BalanceTransferResultStatus(string value)
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
    public static BalanceTransferResultStatus FromCustom(string value)
    {
        return new BalanceTransferResultStatus(value);
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

    public static bool operator ==(BalanceTransferResultStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BalanceTransferResultStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BalanceTransferResultStatus value) => value.Value;

    public static explicit operator BalanceTransferResultStatus(string value) => new(value);

    internal class BalanceTransferResultStatusSerializer
        : JsonConverter<BalanceTransferResultStatus>
    {
        public override BalanceTransferResultStatus Read(
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
            return new BalanceTransferResultStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BalanceTransferResultStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BalanceTransferResultStatus ReadAsPropertyName(
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
            return new BalanceTransferResultStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BalanceTransferResultStatus value,
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
        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
