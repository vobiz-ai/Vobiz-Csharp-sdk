using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(
    typeof(CreateSubaccountRequestBusinessType.CreateSubaccountRequestBusinessTypeSerializer)
)]
[Serializable]
public readonly record struct CreateSubaccountRequestBusinessType : IStringEnum
{
    public static readonly CreateSubaccountRequestBusinessType Individual = new(Values.Individual);

    public static readonly CreateSubaccountRequestBusinessType Proprietorship = new(
        Values.Proprietorship
    );

    public static readonly CreateSubaccountRequestBusinessType PrivateLimited = new(
        Values.PrivateLimited
    );

    public static readonly CreateSubaccountRequestBusinessType Llp = new(Values.Llp);

    public static readonly CreateSubaccountRequestBusinessType Partnership = new(
        Values.Partnership
    );

    public static readonly CreateSubaccountRequestBusinessType PublicLimited = new(
        Values.PublicLimited
    );

    public static readonly CreateSubaccountRequestBusinessType Trust = new(Values.Trust);

    public static readonly CreateSubaccountRequestBusinessType Society = new(Values.Society);

    public static readonly CreateSubaccountRequestBusinessType Huf = new(Values.Huf);

    public static readonly CreateSubaccountRequestBusinessType Government = new(Values.Government);

    public CreateSubaccountRequestBusinessType(string value)
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
    public static CreateSubaccountRequestBusinessType FromCustom(string value)
    {
        return new CreateSubaccountRequestBusinessType(value);
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

    public static bool operator ==(CreateSubaccountRequestBusinessType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubaccountRequestBusinessType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubaccountRequestBusinessType value) =>
        value.Value;

    public static explicit operator CreateSubaccountRequestBusinessType(string value) => new(value);

    internal class CreateSubaccountRequestBusinessTypeSerializer
        : JsonConverter<CreateSubaccountRequestBusinessType>
    {
        public override CreateSubaccountRequestBusinessType Read(
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
            return new CreateSubaccountRequestBusinessType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubaccountRequestBusinessType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubaccountRequestBusinessType ReadAsPropertyName(
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
            return new CreateSubaccountRequestBusinessType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubaccountRequestBusinessType value,
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
        public const string Individual = "individual";

        public const string Proprietorship = "proprietorship";

        public const string PrivateLimited = "private_limited";

        public const string Llp = "llp";

        public const string Partnership = "partnership";

        public const string PublicLimited = "public_limited";

        public const string Trust = "trust";

        public const string Society = "society";

        public const string Huf = "huf";

        public const string Government = "government";
    }
}
