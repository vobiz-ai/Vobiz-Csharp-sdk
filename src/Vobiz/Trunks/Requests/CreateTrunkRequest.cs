using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateTrunkRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Trunk name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Direction of the trunk — **`inbound` or `outbound` only** (a trunk is one direction, not both).
    /// </summary>
    [JsonPropertyName("trunk_direction")]
    public CreateTrunkRequestTrunkDirection? TrunkDirection { get; set; }

    /// <summary>
    /// Trunk status — `enabled` or `disabled` (note: not `active`).
    /// </summary>
    [JsonPropertyName("trunk_status")]
    public CreateTrunkRequestTrunkStatus? TrunkStatus { get; set; }

    [JsonPropertyName("secure")]
    public bool? Secure { get; set; }

    /// <summary>
    /// SIP domain. Auto-generated as `{first8ofUUID}.sip.vobiz.ai` if omitted.
    /// </summary>
    [JsonPropertyName("trunk_domain")]
    public string? TrunkDomain { get; set; }

    [JsonPropertyName("transport")]
    public CreateTrunkRequestTransport? Transport { get; set; }

    [JsonPropertyName("inbound_destination")]
    public string? InboundDestination { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Stored on the trunk. The **enforced** concurrency limit is account-level (account base + channel subscriptions), not this field.
    /// </summary>
    [JsonPropertyName("concurrent_calls_limit")]
    public int? ConcurrentCallsLimit { get; set; }

    /// <summary>
    /// Stored on the trunk. The **enforced** CPS is account-level, not this field.
    /// </summary>
    [JsonPropertyName("cps_limit")]
    public int? CpsLimit { get; set; }

    /// <summary>
    /// Attach an existing SIP credential (username / password / realm) by UUID.
    /// </summary>
    [JsonPropertyName("credential_uuid")]
    public string? CredentialUuid { get; set; }

    /// <summary>
    /// Attach an existing IP access-control list (IP-based auth) by UUID.
    /// </summary>
    [JsonPropertyName("ipacl_uuid")]
    public string? IpaclUuid { get; set; }

    /// <summary>
    /// Primary origination URI UUID.
    /// </summary>
    [JsonPropertyName("primary_uri_uuid")]
    public string? PrimaryUriUuid { get; set; }

    /// <summary>
    /// Fallback origination URI UUID.
    /// </summary>
    [JsonPropertyName("fallback_uri_uuid")]
    public string? FallbackUriUuid { get; set; }

    /// <summary>
    /// Enable call recording.
    /// </summary>
    [JsonPropertyName("recording")]
    public bool? Recording { get; set; }

    /// <summary>
    /// Auto-transcribe recordings when `recording=true`.
    /// </summary>
    [JsonPropertyName("enable_transcription")]
    public bool? EnableTranscription { get; set; }

    /// <summary>
    /// Redact PII from transcriptions.
    /// </summary>
    [JsonPropertyName("pii_redaction")]
    public bool? PiiRedaction { get; set; }

    /// <summary>
    /// Comma-separated list of entity types to redact.
    /// </summary>
    [JsonPropertyName("pii_entity_types")]
    public string? PiiEntityTypes { get; set; }

    /// <summary>
    /// Customer webhook for call-admission events (`CallInitiated` / `Hangup`).
    /// Must be a valid **public** http/https URL. SSRF-validated — localhost,
    /// private (RFC1918), and cloud-metadata (`169.254.169.254`) URLs are
    /// rejected with `invalid webhook_url`. See [Trunk Webhooks](/trunks/webhook).
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// HTTP method for the webhook callback.
    /// </summary>
    [JsonPropertyName("webhook_method")]
    public CreateTrunkRequestWebhookMethod? WebhookMethod { get; set; }

    /// <summary>
    /// Fire a `recording.completed` webhook to `webhook_url` after a recording is saved.
    /// </summary>
    [JsonPropertyName("recording_webhook_enabled")]
    public bool? RecordingWebhookEnabled { get; set; }

    /// <summary>
    /// Deprecated — use `credential_uuid`.
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Deprecated — use `credential_uuid`.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Deprecated — use `ipacl_uuid`.
    /// </summary>
    [JsonPropertyName("ip_whitelist")]
    public IEnumerable<string>? IpWhitelist { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
