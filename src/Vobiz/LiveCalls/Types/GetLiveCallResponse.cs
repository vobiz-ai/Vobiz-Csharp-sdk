using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetLiveCallResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for this API request
    /// </summary>
    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    /// <summary>
    /// Current state of the call (e.g. in-progress)
    /// </summary>
    [JsonPropertyName("call_status")]
    public required string CallStatus { get; set; }

    [JsonPropertyName("call_uuid")]
    public required string CallUuid { get; set; }

    [JsonPropertyName("caller_name")]
    public required string CallerName { get; set; }

    [JsonPropertyName("direction")]
    public required string Direction { get; set; }

    [JsonPropertyName("from")]
    public required string From { get; set; }

    [JsonPropertyName("request_uuid")]
    public required string RequestUuid { get; set; }

    [JsonPropertyName("session_start")]
    public required string SessionStart { get; set; }

    [JsonPropertyName("stir_attestation")]
    public required string StirAttestation { get; set; }

    [JsonPropertyName("stir_verification")]
    public required string StirVerification { get; set; }

    [JsonPropertyName("to")]
    public required string To { get; set; }

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
