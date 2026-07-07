using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(CreateTrunkRequestTransport.CreateTrunkRequestTransportSerializer))]
[Serializable]
public readonly record struct CreateTrunkRequestTransport : IStringEnum
{
    public static readonly CreateTrunkRequestTransport Udp = new(Values.Udp);

    public static readonly CreateTrunkRequestTransport Tcp = new(Values.Tcp);

    public static readonly CreateTrunkRequestTransport Tls = new(Values.Tls);

    public CreateTrunkRequestTransport(string value)
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
    public static CreateTrunkRequestTransport FromCustom(string value)
    {
        return new CreateTrunkRequestTransport(value);
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

    public static bool operator ==(CreateTrunkRequestTransport value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTrunkRequestTransport value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTrunkRequestTransport value) => value.Value;

    public static explicit operator CreateTrunkRequestTransport(string value) => new(value);

    internal class CreateTrunkRequestTransportSerializer
        : JsonConverter<CreateTrunkRequestTransport>
    {
        public override CreateTrunkRequestTransport Read(
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
            return new CreateTrunkRequestTransport(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTrunkRequestTransport value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTrunkRequestTransport ReadAsPropertyName(
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
            return new CreateTrunkRequestTransport(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTrunkRequestTransport value,
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
        public const string Udp = "udp";

        public const string Tcp = "tcp";

        public const string Tls = "tls";
    }
}
