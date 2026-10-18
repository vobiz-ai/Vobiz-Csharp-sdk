using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CreateWebhookRequest
{
    /// <summary>
    /// The HTTPS URL that receives `POST` deliveries, for example `https://example.com/vobiz/webhooks`. Required; an empty or missing value returns `400` with `url is required`.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Shared secret used to compute `X-Webhook-Signature` on every delivery. Choose a long random value and store it on your server; if you omit it the subscription is created with an empty secret.
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// Event names to deliver to this URL, matched exactly. Defaults to `message.received`, `message.delivered` and `message.failed` when you omit it or send an empty array.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<WebhookEvent>? Events { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
