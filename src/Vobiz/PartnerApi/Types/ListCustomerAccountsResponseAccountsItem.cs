using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerAccountsResponseAccountsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("gstin")]
    public string? Gstin { get; set; }

    [JsonPropertyName("gst_status")]
    public string? GstStatus { get; set; }

    [JsonPropertyName("tds_enabled")]
    public required bool TdsEnabled { get; set; }

    [JsonPropertyName("tds_percentage")]
    public required int TdsPercentage { get; set; }

    [JsonPropertyName("business_type")]
    public required string BusinessType { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("auth_id")]
    public required string AuthId { get; set; }

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    [JsonPropertyName("account_type")]
    public required string AccountType { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("postpaid")]
    public required bool Postpaid { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("company")]
    public required string Company { get; set; }

    [JsonPropertyName("billing_mode")]
    public required string BillingMode { get; set; }

    [JsonPropertyName("auto_recharge")]
    public required bool AutoRecharge { get; set; }

    [JsonPropertyName("cash_credits")]
    public required string CashCredits { get; set; }

    [JsonPropertyName("cps_limit")]
    public required int CpsLimit { get; set; }

    [JsonPropertyName("concurrent_calls_limit")]
    public required int ConcurrentCallsLimit { get; set; }

    [JsonPropertyName("base_cps_limit")]
    public object? BaseCpsLimit { get; set; }

    [JsonPropertyName("base_concurrent_calls_limit")]
    public object? BaseConcurrentCallsLimit { get; set; }

    [JsonPropertyName("purchased_cps")]
    public object? PurchasedCps { get; set; }

    [JsonPropertyName("purchased_concurrent_calls")]
    public object? PurchasedConcurrentCalls { get; set; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("is_verified")]
    public required bool IsVerified { get; set; }

    [JsonPropertyName("is_trial_account")]
    public required bool IsTrialAccount { get; set; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("kyc_status")]
    public required string KycStatus { get; set; }

    [JsonPropertyName("google_id")]
    public object? GoogleId { get; set; }

    [JsonPropertyName("referral_code")]
    public string? ReferralCode { get; set; }

    [JsonPropertyName("referral_disabled")]
    public required bool ReferralDisabled { get; set; }

    [JsonPropertyName("custom_referrer_reward_amount")]
    public object? CustomReferrerRewardAmount { get; set; }

    [JsonPropertyName("custom_referee_reward_amount")]
    public object? CustomRefereeRewardAmount { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("last_login")]
    public string? LastLogin { get; set; }

    [JsonPropertyName("pricing_tier_id")]
    public required string PricingTierId { get; set; }

    [JsonPropertyName("pricing_tier")]
    public required ListCustomerAccountsResponseAccountsItemPricingTier PricingTier { get; set; }

    [JsonPropertyName("partner_id")]
    public required string PartnerId { get; set; }

    [JsonPropertyName("auto_recharge_config")]
    public object? AutoRechargeConfig { get; set; }

    [JsonPropertyName("resource_uri")]
    public required string ResourceUri { get; set; }

    [JsonPropertyName("auth_token")]
    public required string AuthToken { get; set; }

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
