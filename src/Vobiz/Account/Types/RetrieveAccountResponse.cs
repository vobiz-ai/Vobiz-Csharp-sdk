using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record RetrieveAccountResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("auth_id")]
    public required string AuthId { get; set; }

    [JsonPropertyName("auth_secret")]
    public required string AuthSecret { get; set; }

    [JsonPropertyName("auth_token_expire_time")]
    public object? AuthTokenExpireTime { get; set; }

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    [JsonPropertyName("timezone")]
    public required string Timezone { get; set; }

    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("state")]
    public required string State { get; set; }

    [JsonPropertyName("address")]
    public required string Address { get; set; }

    [JsonPropertyName("zip_code")]
    public required string ZipCode { get; set; }

    [JsonPropertyName("company")]
    public required string Company { get; set; }

    [JsonPropertyName("account_type")]
    public required string AccountType { get; set; }

    [JsonPropertyName("postpaid")]
    public required bool Postpaid { get; set; }

    [JsonPropertyName("auto_recharge")]
    public required bool AutoRecharge { get; set; }

    [JsonPropertyName("auto_recharge_config")]
    public object? AutoRechargeConfig { get; set; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("carrier_type")]
    public object? CarrierType { get; set; }

    [JsonPropertyName("customer_type")]
    public object? CustomerType { get; set; }

    [JsonPropertyName("credit_limit")]
    public required int CreditLimit { get; set; }

    [JsonPropertyName("cps_limit")]
    public required int CpsLimit { get; set; }

    [JsonPropertyName("concurrent_calls_limit")]
    public required int ConcurrentCallsLimit { get; set; }

    [JsonPropertyName("base_cps_limit")]
    public required int BaseCpsLimit { get; set; }

    [JsonPropertyName("base_concurrent_calls_limit")]
    public required int BaseConcurrentCallsLimit { get; set; }

    [JsonPropertyName("purchased_cps")]
    public required int PurchasedCps { get; set; }

    [JsonPropertyName("purchased_concurrent_calls")]
    public required int PurchasedConcurrentCalls { get; set; }

    [JsonPropertyName("risk_rating")]
    public required int RiskRating { get; set; }

    [JsonPropertyName("risk_status")]
    public object? RiskStatus { get; set; }

    [JsonPropertyName("features")]
    public required RetrieveAccountResponseFeatures Features { get; set; }

    [JsonPropertyName("ip_auth_enabled")]
    public required bool IpAuthEnabled { get; set; }

    [JsonPropertyName("ip_whitelist_rules")]
    public Dictionary<string, object?> IpWhitelistRules { get; set; } =
        new Dictionary<string, object?>();

    [JsonPropertyName("allow_aws_ips")]
    public required bool AllowAwsIps { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("is_verified")]
    public required bool IsVerified { get; set; }

    [JsonPropertyName("is_trial_account")]
    public required bool IsTrialAccount { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("last_login")]
    public required string LastLogin { get; set; }

    [JsonPropertyName("pricing_tier_id")]
    public required string PricingTierId { get; set; }

    [JsonPropertyName("pricing_tier")]
    public required RetrieveAccountResponsePricingTier PricingTier { get; set; }

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
