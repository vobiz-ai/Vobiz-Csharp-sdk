using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateKycSessionRequest
{
    /// <summary>
    /// Customer's auth_id (from create-customer-account).
    /// </summary>
    [JsonPropertyName("account_auth_id")]
    public required string AccountAuthId { get; set; }

    /// <summary>
    /// Delivery mode. `email` (default) emails the customer the KYC link.
    /// `redirect` returns a `widget_url` in the response for immediate redirect.
    /// </summary>
    [JsonPropertyName("flow_type")]
    public CreateKycSessionRequestFlowType? FlowType { get; set; }

    /// <summary>
    /// Required when `flow_type` is `email`. Ignored otherwise.
    /// </summary>
    [JsonPropertyName("customer_email")]
    public string? CustomerEmail { get; set; }

    /// <summary>
    /// Required when `flow_type` is `redirect`. After verification the customer's
    /// browser is sent to this URL with query params `session_id`, `status`, `auth_id`.
    /// </summary>
    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// VoBiz POSTs the KYC result here.
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// Days before the KYC link expires.
    /// </summary>
    [JsonPropertyName("expires_in_days")]
    public int? ExpiresInDays { get; set; }

    /// <summary>
    /// Auto reminder emails before expiry. Email flow only.
    /// </summary>
    [JsonPropertyName("reminder_schedule")]
    public IEnumerable<CreateKycSessionRequestReminderScheduleItem>? ReminderSchedule { get; set; }

    /// <summary>
    /// Free-form key/value object echoed back on GET and webhooks.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
