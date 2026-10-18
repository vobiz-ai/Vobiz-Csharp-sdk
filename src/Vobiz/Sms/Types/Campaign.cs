using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A 10DLC or toll-free campaign on your account and its state at the US 10DLC registry. Optional fields are omitted when empty, and registry state is refreshed when you retrieve the campaign.
/// </summary>
[Serializable]
public record Campaign : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Campaign ID (UUID) on your account. Use it in every `/10dlc/campaigns/{id}` path.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (`MA_...`). Always the account whose credentials made the request.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// ID of the brand the campaign runs under. Omitted for toll-free campaigns, which carry their business details themselves.
    /// </summary>
    [JsonPropertyName("brandId")]
    public string? BrandId { get; set; }

    /// <summary>
    /// Name you gave the campaign, for your reference.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Kind of campaign. `TEN_DIGIT_LONG_CODE` is a standard 10DLC campaign (the default on create) and `TOLL_FREE_UNIFIED_NUMBER` is a toll-free verification created with `POST /10dlc/campaigns/toll-free`. The other values are registry campaign types you can request on create.
    /// </summary>
    [JsonPropertyName("campaignType")]
    public CampaignCampaignType? CampaignType { get; set; }

    /// <summary>
    /// Registry lifecycle stage. A new campaign is `DRAFT`; after you register it, it moves through review stages such as `SUBMITTED`, `IN_REVIEW` or `APPEALED` and settles at `REGISTERED` or `REJECTED`. Other values include `REGISTERED_PENDING_UPDATE`, `REGISTERED_PENDING_DEREGISTRATION`, `REJECTED_EXTERNALLY`, `DEREGISTERED`, `ARCHIVED`, `BLOCKED`, `SUSPENDED` and `DELETED`; treat it as an open string.
    /// </summary>
    [JsonPropertyName("stage")]
    public string? Stage { get; set; }

    /// <summary>
    /// Description of the program as submitted to the registry. Omitted when not set.
    /// </summary>
    [JsonPropertyName("programSummary")]
    public string? ProgramSummary { get; set; }

    /// <summary>
    /// Opt-in confirmation message as submitted. Omitted when not set.
    /// </summary>
    [JsonPropertyName("confirmationMessage")]
    public string? ConfirmationMessage { get; set; }

    /// <summary>
    /// HELP reply as submitted. Omitted when not set.
    /// </summary>
    [JsonPropertyName("helpMessage")]
    public string? HelpMessage { get; set; }

    /// <summary>
    /// STOP reply as submitted. Omitted when not set.
    /// </summary>
    [JsonPropertyName("stopMessage")]
    public string? StopMessage { get; set; }

    /// <summary>
    /// Customer care phone number, in E.164 format. Omitted when not set.
    /// </summary>
    [JsonPropertyName("customerCarePhone")]
    public string? CustomerCarePhone { get; set; }

    /// <summary>
    /// Customer care email address. Omitted when not set.
    /// </summary>
    [JsonPropertyName("customerCareEmail")]
    public string? CustomerCareEmail { get; set; }

    /// <summary>
    /// Sample messages as submitted. Omitted when not set.
    /// </summary>
    [JsonPropertyName("exampleMessages")]
    public IEnumerable<string>? ExampleMessages { get; set; }

    /// <summary>
    /// Public URL of your terms and conditions. Omitted when not set.
    /// </summary>
    [JsonPropertyName("termsAndConditionsUrl")]
    public string? TermsAndConditionsUrl { get; set; }

    /// <summary>
    /// Public URL of your privacy policy. Omitted when not set.
    /// </summary>
    [JsonPropertyName("privacyPolicyUrl")]
    public string? PrivacyPolicyUrl { get; set; }

    /// <summary>
    /// Use-case codes as submitted, for example `ALERTS` or, on a toll-free campaign, `NOTIFICATIONS`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("useCases")]
    public IEnumerable<string>? UseCases { get; set; }

    /// <summary>
    /// Message types as submitted, for example `SMS`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("messageTypes")]
    public IEnumerable<string>? MessageTypes { get; set; }

    /// <summary>
    /// Opt-in details as submitted, keyed by channel (for example `web`). Omitted when not set.
    /// </summary>
    [JsonPropertyName("optIns")]
    public Dictionary<string, object?>? OptIns { get; set; }

    /// <summary>
    /// Whether the campaign is declared low volume. Always present; `false` unless you set it.
    /// </summary>
    [JsonPropertyName("lowVolume")]
    public bool? LowVolume { get; set; }

    /// <summary>
    /// Whether the content is restricted to adults. Always present; `false` unless you set it.
    /// </summary>
    [JsonPropertyName("ageGated")]
    public bool? AgeGated { get; set; }

    /// <summary>
    /// Whether the content relates to direct lending. Always present; `false` unless you set it.
    /// </summary>
    [JsonPropertyName("directLending")]
    public bool? DirectLending { get; set; }

    /// <summary>
    /// Whether messages contain URLs. Always present; `false` unless you set it.
    /// </summary>
    [JsonPropertyName("embeddedLink")]
    public bool? EmbeddedLink { get; set; }

    /// <summary>
    /// Whether messages contain phone numbers. Always present; `false` unless you set it.
    /// </summary>
    [JsonPropertyName("embeddedPhone")]
    public bool? EmbeddedPhone { get; set; }

    /// <summary>
    /// Numbers recorded on the campaign on your account. 10DLC campaigns store digits with country code (for example `14155550100`); toll-free campaigns store E.164 with a leading `+`. For the registry's own list use `GET /10dlc/campaigns/{id}/numbers`.
    /// </summary>
    [JsonPropertyName("numbers")]
    public IEnumerable<string>? Numbers { get; set; }

    /// <summary>
    /// The registry's review feedback after a rejection, with keys such as `rejectionDate`, `rejectionReasons` and `rejectionDetails` (each detail has `errorCode`, `description`, `recommendedAction` and `rejectionCategory`). Omitted when the campaign has no feedback; address every point before you appeal.
    /// </summary>
    [JsonPropertyName("rejectionReasons")]
    public Dictionary<string, object?>? RejectionReasons { get; set; }

    /// <summary>
    /// When Vobiz last refreshed this record from the US 10DLC registry, in ISO 8601 (RFC 3339) UTC. Omitted until the first refresh.
    /// </summary>
    [JsonPropertyName("lastSyncedAt")]
    public DateTime? LastSyncedAt { get; set; }

    /// <summary>
    /// When the record was created on your account, in ISO 8601 (RFC 3339) UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the record last changed on your account, in ISO 8601 (RFC 3339) UTC.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

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
