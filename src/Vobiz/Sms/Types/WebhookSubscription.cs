using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A webhook subscription: the URL Vobiz delivers your chosen events to, and the secret used to sign them.
/// </summary>
[Serializable]
public record WebhookSubscription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the subscription (UUID). Use it with `GET`, `PUT` and `DELETE /webhooks/{id}`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Auth ID of the account that owns the subscription, for example `MA_XXXXXXXX`.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// The URL that receives `POST` deliveries.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// The signing secret for `X-Webhook-Signature`, returned in clear. Keep it out of logs and client-side code.
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// Event names delivered to this URL. An event is delivered only when its name appears here exactly.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<WebhookEvent>? Events { get; set; }

    /// <summary>
    /// `true` when deliveries are on. New subscriptions start `true`; set it with `PUT /webhooks/{id}`.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// When the subscription was created (ISO 8601). Read it from `GET /webhooks/{id}` or `GET /webhooks`.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

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
