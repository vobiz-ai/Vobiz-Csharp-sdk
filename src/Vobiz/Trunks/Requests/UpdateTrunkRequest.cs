using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record UpdateTrunkRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string TrunkId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Direction of the trunk — `inbound` or `outbound` only.
    /// </summary>
    [JsonPropertyName("trunk_direction")]
    public UpdateTrunkRequestTrunkDirection? TrunkDirection { get; set; }

    [JsonPropertyName("trunk_status")]
    public UpdateTrunkRequestTrunkStatus? TrunkStatus { get; set; }

    [JsonPropertyName("secure")]
    public bool? Secure { get; set; }

    [JsonPropertyName("trunk_domain")]
    public string? TrunkDomain { get; set; }

    [JsonPropertyName("transport")]
    public UpdateTrunkRequestTransport? Transport { get; set; }

    [JsonPropertyName("inbound_destination")]
    public string? InboundDestination { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("concurrent_calls_limit")]
    public int? ConcurrentCallsLimit { get; set; }

    [JsonPropertyName("cps_limit")]
    public int? CpsLimit { get; set; }

    [JsonPropertyName("credential_uuid")]
    public string? CredentialUuid { get; set; }

    [JsonPropertyName("ipacl_uuid")]
    public string? IpaclUuid { get; set; }

    [JsonPropertyName("primary_uri_uuid")]
    public string? PrimaryUriUuid { get; set; }

    [JsonPropertyName("fallback_uri_uuid")]
    public string? FallbackUriUuid { get; set; }

    [JsonPropertyName("recording")]
    public bool? Recording { get; set; }

    [JsonPropertyName("enable_transcription")]
    public bool? EnableTranscription { get; set; }

    [JsonPropertyName("pii_redaction")]
    public bool? PiiRedaction { get; set; }

    [JsonPropertyName("pii_entity_types")]
    public string? PiiEntityTypes { get; set; }

    /// <summary>
    /// Customer webhook for call-admission events (`CallInitiated` / `Hangup`). Public http/https URL; SSRF-validated. See [Trunk Webhooks](/trunks/webhook).
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    [JsonPropertyName("webhook_method")]
    public UpdateTrunkRequestWebhookMethod? WebhookMethod { get; set; }

    [JsonPropertyName("recording_webhook_enabled")]
    public bool? RecordingWebhookEnabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
