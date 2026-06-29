using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetBalanceResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("account_id")]
    public required string AccountId { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("balance")]
    public required double Balance { get; set; }

    [JsonPropertyName("reserved_funds")]
    public required int ReservedFunds { get; set; }

    [JsonPropertyName("promotional_balance")]
    public required int PromotionalBalance { get; set; }

    [JsonPropertyName("promotional_reserved_balance")]
    public required int PromotionalReservedBalance { get; set; }

    [JsonPropertyName("available_balance")]
    public required double AvailableBalance { get; set; }

    [JsonPropertyName("credit_limit")]
    public required int CreditLimit { get; set; }

    [JsonPropertyName("is_postpaid")]
    public required bool IsPostpaid { get; set; }

    [JsonPropertyName("credit_limit_type")]
    public required string CreditLimitType { get; set; }

    [JsonPropertyName("low_balance_threshold")]
    public required int LowBalanceThreshold { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

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
