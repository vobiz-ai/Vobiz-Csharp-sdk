using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(UpdateSubaccountRequestKycMode.UpdateSubaccountRequestKycModeSerializer))]
[Serializable]
public readonly record struct UpdateSubaccountRequestKycMode : IStringEnum
{
    public static readonly UpdateSubaccountRequestKycMode PersonalUse = new(Values.PersonalUse);

    public static readonly UpdateSubaccountRequestKycMode CustomerUse = new(Values.CustomerUse);

    public UpdateSubaccountRequestKycMode(string value)
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
    public static UpdateSubaccountRequestKycMode FromCustom(string value)
    {
        return new UpdateSubaccountRequestKycMode(value);
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

    public static bool operator ==(UpdateSubaccountRequestKycMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateSubaccountRequestKycMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubaccountRequestKycMode value) => value.Value;

    public static explicit operator UpdateSubaccountRequestKycMode(string value) => new(value);

    internal class UpdateSubaccountRequestKycModeSerializer
        : JsonConverter<UpdateSubaccountRequestKycMode>
    {
        public override UpdateSubaccountRequestKycMode Read(
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
            return new UpdateSubaccountRequestKycMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubaccountRequestKycMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubaccountRequestKycMode ReadAsPropertyName(
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
            return new UpdateSubaccountRequestKycMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubaccountRequestKycMode value,
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
