using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(SendDtmfRequestLeg.SendDtmfRequestLegSerializer))]
[Serializable]
public readonly record struct SendDtmfRequestLeg : IStringEnum
{
    public static readonly SendDtmfRequestLeg Aleg = new(Values.Aleg);

    public static readonly SendDtmfRequestLeg Bleg = new(Values.Bleg);

    public static readonly SendDtmfRequestLeg Both = new(Values.Both);

    public SendDtmfRequestLeg(string value)
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
    public static SendDtmfRequestLeg FromCustom(string value)
    {
        return new SendDtmfRequestLeg(value);
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

    public static bool operator ==(SendDtmfRequestLeg value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SendDtmfRequestLeg value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SendDtmfRequestLeg value) => value.Value;

    public static explicit operator SendDtmfRequestLeg(string value) => new(value);

    internal class SendDtmfRequestLegSerializer : JsonConverter<SendDtmfRequestLeg>
    {
        public override SendDtmfRequestLeg Read(
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
            return new SendDtmfRequestLeg(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendDtmfRequestLeg value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SendDtmfRequestLeg ReadAsPropertyName(
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
            return new SendDtmfRequestLeg(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendDtmfRequestLeg value,
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
        public const string Aleg = "aleg";

        public const string Bleg = "bleg";

        public const string Both = "both";
    }
}
