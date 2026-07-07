using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[JsonConverter(typeof(UpdateTrunkRequestTransport.UpdateTrunkRequestTransportSerializer))]
[Serializable]
public readonly record struct UpdateTrunkRequestTransport : IStringEnum
{
    public static readonly UpdateTrunkRequestTransport Udp = new(Values.Udp);

    public static readonly UpdateTrunkRequestTransport Tcp = new(Values.Tcp);

    public static readonly UpdateTrunkRequestTransport Tls = new(Values.Tls);

    public UpdateTrunkRequestTransport(string value)
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
    public static UpdateTrunkRequestTransport FromCustom(string value)
    {
        return new UpdateTrunkRequestTransport(value);
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

    public static bool operator ==(UpdateTrunkRequestTransport value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTrunkRequestTransport value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTrunkRequestTransport value) => value.Value;

    public static explicit operator UpdateTrunkRequestTransport(string value) => new(value);

    internal class UpdateTrunkRequestTransportSerializer
        : JsonConverter<UpdateTrunkRequestTransport>
    {
        public override UpdateTrunkRequestTransport Read(
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
            return new UpdateTrunkRequestTransport(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTrunkRequestTransport value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTrunkRequestTransport ReadAsPropertyName(
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
            return new UpdateTrunkRequestTransport(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTrunkRequestTransport value,
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
