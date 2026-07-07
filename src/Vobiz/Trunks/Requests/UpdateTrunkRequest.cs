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
    public required string Name { get; set; }

    [JsonPropertyName("max_concurrent_calls")]
    public required int MaxConcurrentCalls { get; set; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    /// <summary>
    /// HTTPS URL for real-time call-event webhooks (`CallInitiated`, `Hangup`). See [Trunk Webhooks](/trunks/webhook).
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// HTTP method for the webhook callback. Defaults to `POST`.
    /// </summary>
    [JsonPropertyName("webhook_method")]
    public UpdateTrunkRequestWebhookMethod? WebhookMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
