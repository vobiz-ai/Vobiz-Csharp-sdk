using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[JsonConverter(typeof(RcsSuggestionType.RcsSuggestionTypeSerializer))]
[Serializable]
public readonly record struct RcsSuggestionType : IStringEnum
{
    public static readonly RcsSuggestionType Reply = new(Values.Reply);

    public static readonly RcsSuggestionType OpenUrl = new(Values.OpenUrl);

    public static readonly RcsSuggestionType DialPhone = new(Values.DialPhone);

    public static readonly RcsSuggestionType ShowLocation = new(Values.ShowLocation);

    public static readonly RcsSuggestionType RequestLocation = new(Values.RequestLocation);

    public RcsSuggestionType(string value)
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
    public static RcsSuggestionType FromCustom(string value)
    {
        return new RcsSuggestionType(value);
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

    public static bool operator ==(RcsSuggestionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RcsSuggestionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RcsSuggestionType value) => value.Value;

    public static explicit operator RcsSuggestionType(string value) => new(value);

    internal class RcsSuggestionTypeSerializer : JsonConverter<RcsSuggestionType>
    {
        public override RcsSuggestionType Read(
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
            return new RcsSuggestionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RcsSuggestionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RcsSuggestionType ReadAsPropertyName(
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
            return new RcsSuggestionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RcsSuggestionType value,
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
        public const string Reply = "REPLY";

        public const string OpenUrl = "OPEN_URL";

        public const string DialPhone = "DIAL_PHONE";

        public const string ShowLocation = "SHOW_LOCATION";

        public const string RequestLocation = "REQUEST_LOCATION";
    }
}
