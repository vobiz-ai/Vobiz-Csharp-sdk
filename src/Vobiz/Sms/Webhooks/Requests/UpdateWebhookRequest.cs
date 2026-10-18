using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record UpdateWebhookRequest
{
    /// <summary>
    /// The subscription `id` (UUID) to change.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// New HTTPS URL for deliveries. Replaces the current URL as sent, so always send a full valid URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// New signing secret for `X-Webhook-Signature`. Deliveries are signed with the new value from this point, so update your verifier at the same time.
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// New list of event names to deliver, matched exactly. Replaces the whole list; it is not merged with the current events.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<WebhookEvent>? Events { get; set; }

    /// <summary>
    /// `false` pauses deliveries and keeps the subscription; `true` resumes them.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
