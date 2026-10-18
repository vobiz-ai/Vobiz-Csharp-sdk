using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The body of every error response: a flat object with one `error` string that explains what went wrong. Use the HTTP status code to decide how to handle the error, and log `error` for diagnosis.
/// </summary>
[Serializable]
public record Error : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Human-readable explanation of the error, for example `phoneNumber is required` or `recipient has opted out: +14155550123`. Branch on the HTTP status code rather than on this text.
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error_ { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
