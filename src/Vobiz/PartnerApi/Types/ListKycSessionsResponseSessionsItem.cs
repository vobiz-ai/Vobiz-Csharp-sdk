using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListKycSessionsResponseSessionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("account_auth_id")]
    public required string AccountAuthId { get; set; }

    [JsonPropertyName("customer_email")]
    public string? CustomerEmail { get; set; }

    [JsonPropertyName("kyc_type")]
    public string? KycType { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("expires_at")]
    public required string ExpiresAt { get; set; }

    [JsonPropertyName("first_opened_at")]
    public string? FirstOpenedAt { get; set; }

    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; set; }

    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

    [JsonPropertyName("reminder_schedule")]
    public IEnumerable<ListKycSessionsResponseSessionsItemReminderScheduleItem> ReminderSchedule { get; set; } =
        new List<ListKycSessionsResponseSessionsItemReminderScheduleItem>();

    [JsonPropertyName("metadata")]
    public required OneOf<
        object?,
        ListKycSessionsResponseSessionsItemMetadataCustomerRef
    > Metadata { get; set; }

    [JsonPropertyName("verified_data")]
    public required OneOf<
        object?,
        ListKycSessionsResponseSessionsItemVerifiedDataAadhaarDob
    > VerifiedData { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

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
