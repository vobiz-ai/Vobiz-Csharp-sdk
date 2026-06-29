using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateSubaccountKycSessionRequest
{
    /// <summary>
    /// The sub-account's Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string SubAuthId { get; set; }

    /// <summary>
    /// The sub-account's auth_id (typically equal to the path `sub_auth_id`).
    /// </summary>
    [JsonPropertyName("account_auth_id")]
    public required string AccountAuthId { get; set; }

    [JsonPropertyName("flow_type")]
    public required CreateSubaccountKycSessionRequestFlowType FlowType { get; set; }

    /// <summary>
    /// Required when `flow_type` is `email`.
    /// </summary>
    [JsonPropertyName("customer_email")]
    public string? CustomerEmail { get; set; }

    /// <summary>
    /// Required when `flow_type` is `redirect`. After verification the customer's
    /// browser is sent to this URL.
    /// </summary>
    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// HTTPS endpoint VoBiz POSTs the KYC result to. Omit it and no callbacks are sent.
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    [JsonPropertyName("expires_in_days")]
    public int? ExpiresInDays { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
