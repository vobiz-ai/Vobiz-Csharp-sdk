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

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("trunk_type")]
    public required string TrunkType { get; set; }

    [JsonPropertyName("max_concurrent_calls")]
    public required int MaxConcurrentCalls { get; set; }

    /// <summary>
    /// HTTPS URL to receive real-time call-event webhooks (`CallInitiated`
    /// and `Hangup`) for this trunk. Max 500 characters; private, localhost,
    /// and cloud-metadata IPs are blocked. See [Trunk Webhooks](/trunks/webhook).
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// HTTP method for the webhook callback. Defaults to `POST`.
    /// </summary>
    [JsonPropertyName("webhook_method")]
    public CreateTrunkRequestWebhookMethod? WebhookMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
