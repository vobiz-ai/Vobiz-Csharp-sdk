using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetPartnerProfileResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("account_id")]
    public required int AccountId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    [JsonPropertyName("company")]
    public required string Company { get; set; }

    [JsonPropertyName("auth_id")]
    public required string AuthId { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    [JsonPropertyName("billing_model")]
    public required string BillingModel { get; set; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("is_verified")]
    public required bool IsVerified { get; set; }

    [JsonPropertyName("max_accounts")]
    public required int MaxAccounts { get; set; }

    [JsonPropertyName("can_create_accounts")]
    public required bool CanCreateAccounts { get; set; }

    [JsonPropertyName("can_create_pricing_tiers")]
    public required bool CanCreatePricingTiers { get; set; }

    [JsonPropertyName("can_view_cdrs")]
    public required bool CanViewCdrs { get; set; }

    [JsonPropertyName("can_transfer_balance")]
    public required bool CanTransferBalance { get; set; }

    [JsonPropertyName("default_pricing_tier_id")]
    public required string DefaultPricingTierId { get; set; }

    [JsonPropertyName("account_count")]
    public required int AccountCount { get; set; }

    [JsonPropertyName("balance")]
    public required string Balance { get; set; }

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
