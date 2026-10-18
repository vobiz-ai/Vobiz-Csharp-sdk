using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Error returned when the US 10DLC registry declines or cannot process a request. `error` is a human-readable message you can show or log. When the registry answers with `400`, `404`, `409`, `422` or `429`, the same status is passed through with this body; `502` means the registry did not answer and `503` means it did not accept Vobiz's service credentials.
/// </summary>
[Serializable]
public record TenDlcError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque diagnostic string you can quote to support. Do not parse it.
    /// </summary>
    [JsonPropertyName("providerError")]
    public string? ProviderError { get; set; }

    /// <summary>
    /// Human-readable explanation of the error, for example `phoneNumber is required` or `recipient has opted out: +14155550123`. Branch on the HTTP status code rather than on this text.
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error { get; set; }

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
