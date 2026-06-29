using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListTrunksResponseObjectsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("trunk_id")]
    public required string TrunkId { get; set; }

    [JsonPropertyName("account_id")]
    public required string AccountId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("trunk_domain")]
    public required string TrunkDomain { get; set; }

    [JsonPropertyName("trunk_status")]
    public required string TrunkStatus { get; set; }

    [JsonPropertyName("secure")]
    public required bool Secure { get; set; }

    [JsonPropertyName("trunk_direction")]
    public required string TrunkDirection { get; set; }

    [JsonPropertyName("concurrent_calls_limit")]
    public required int ConcurrentCallsLimit { get; set; }

    [JsonPropertyName("cps_limit")]
    public required int CpsLimit { get; set; }

    [JsonPropertyName("credential_uuid")]
    public string? CredentialUuid { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("transport")]
    public required string Transport { get; set; }

    [JsonPropertyName("recording")]
    public required bool Recording { get; set; }

    [JsonPropertyName("enable_transcription")]
    public required bool EnableTranscription { get; set; }

    [JsonPropertyName("pii_redaction")]
    public required bool PiiRedaction { get; set; }

    [JsonPropertyName("webhook_method")]
    public required string WebhookMethod { get; set; }

    [JsonPropertyName("recording_webhook_enabled")]
    public required bool RecordingWebhookEnabled { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("primary_uri_uuid")]
    public string? PrimaryUriUuid { get; set; }

    [JsonPropertyName("inbound_destination")]
    public string? InboundDestination { get; set; }

    [JsonPropertyName("pii_entity_types")]
    public string? PiiEntityTypes { get; set; }

    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

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
