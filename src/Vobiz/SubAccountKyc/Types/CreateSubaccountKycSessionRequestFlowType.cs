using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(CreateSubaccountKycSessionRequestFlowType.CreateSubaccountKycSessionRequestFlowTypeSerializer)
)]
[Serializable]
public readonly record struct CreateSubaccountKycSessionRequestFlowType : IStringEnum
{
    public static readonly CreateSubaccountKycSessionRequestFlowType Email = new(Values.Email);

    public static readonly CreateSubaccountKycSessionRequestFlowType Redirect = new(
        Values.Redirect
    );

    public CreateSubaccountKycSessionRequestFlowType(string value)
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
    public static CreateSubaccountKycSessionRequestFlowType FromCustom(string value)
    {
        return new CreateSubaccountKycSessionRequestFlowType(value);
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
        CreateSubaccountKycSessionRequestFlowType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubaccountKycSessionRequestFlowType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubaccountKycSessionRequestFlowType value) =>
        value.Value;

    public static explicit operator CreateSubaccountKycSessionRequestFlowType(string value) =>
        new(value);

    internal class CreateSubaccountKycSessionRequestFlowTypeSerializer
        : JsonConverter<CreateSubaccountKycSessionRequestFlowType>
    {
        public override CreateSubaccountKycSessionRequestFlowType Read(
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
            return new CreateSubaccountKycSessionRequestFlowType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubaccountKycSessionRequestFlowType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubaccountKycSessionRequestFlowType ReadAsPropertyName(
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
            return new CreateSubaccountKycSessionRequestFlowType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubaccountKycSessionRequestFlowType value,
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
        public const string Email = "email";

        public const string Redirect = "redirect";
    }
}
