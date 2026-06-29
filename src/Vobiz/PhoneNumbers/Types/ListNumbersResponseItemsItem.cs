using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListNumbersResponseItemsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("account_id")]
    public required string AccountId { get; set; }

    [JsonPropertyName("e164")]
    public required string E164 { get; set; }

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    [JsonPropertyName("region")]
    public required string Region { get; set; }

    [JsonPropertyName("capabilities")]
    public required ListNumbersResponseItemsItemCapabilities Capabilities { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("provider")]
    public required string Provider { get; set; }

    [JsonPropertyName("setup_fee")]
    public required int SetupFee { get; set; }

    [JsonPropertyName("monthly_fee")]
    public required int MonthlyFee { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("voice_enabled")]
    public required bool VoiceEnabled { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; } = new List<string>();

    [JsonPropertyName("purchased_at")]
    public required string PurchasedAt { get; set; }

    [JsonPropertyName("is_blocked")]
    public required bool IsBlocked { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("is_trial_number")]
    public required bool IsTrialNumber { get; set; }

    [JsonPropertyName("last_billing_date")]
    public string? LastBillingDate { get; set; }

    [JsonPropertyName("next_billing_date")]
    public string? NextBillingDate { get; set; }

    [JsonPropertyName("minimum_commitment_months")]
    public required int MinimumCommitmentMonths { get; set; }

    [JsonPropertyName("aadhaar_verification_required")]
    public required bool AadhaarVerificationRequired { get; set; }

    [JsonPropertyName("aadhaar_verified")]
    public required bool AadhaarVerified { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("released_at")]
    public string? ReleasedAt { get; set; }

    [JsonPropertyName("trunk_group_id")]
    public string? TrunkGroupId { get; set; }

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
