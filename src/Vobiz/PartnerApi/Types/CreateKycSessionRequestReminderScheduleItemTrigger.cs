using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(CreateKycSessionRequestReminderScheduleItemTrigger.CreateKycSessionRequestReminderScheduleItemTriggerSerializer)
)]
[Serializable]
public readonly record struct CreateKycSessionRequestReminderScheduleItemTrigger : IStringEnum
{
    public static readonly CreateKycSessionRequestReminderScheduleItemTrigger DaysBeforeExpiry =
        new(Values.DaysBeforeExpiry);

    public CreateKycSessionRequestReminderScheduleItemTrigger(string value)
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
    public static CreateKycSessionRequestReminderScheduleItemTrigger FromCustom(string value)
    {
        return new CreateKycSessionRequestReminderScheduleItemTrigger(value);
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
        CreateKycSessionRequestReminderScheduleItemTrigger value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateKycSessionRequestReminderScheduleItemTrigger value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateKycSessionRequestReminderScheduleItemTrigger value
    ) => value.Value;

    public static explicit operator CreateKycSessionRequestReminderScheduleItemTrigger(
        string value
    ) => new(value);

    internal class CreateKycSessionRequestReminderScheduleItemTriggerSerializer
        : JsonConverter<CreateKycSessionRequestReminderScheduleItemTrigger>
    {
        public override CreateKycSessionRequestReminderScheduleItemTrigger Read(
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
            return new CreateKycSessionRequestReminderScheduleItemTrigger(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateKycSessionRequestReminderScheduleItemTrigger value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateKycSessionRequestReminderScheduleItemTrigger ReadAsPropertyName(
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
            return new CreateKycSessionRequestReminderScheduleItemTrigger(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateKycSessionRequestReminderScheduleItemTrigger value,
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
        public const string DaysBeforeExpiry = "days_before_expiry";
    }
}
