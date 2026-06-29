using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Result of an atomic transfer from the partner master wallet to a customer sub-account.
/// </summary>
[Serializable]
public record BalanceTransferResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("customer_auth_id")]
    public string? CustomerAuthId { get; set; }

    [JsonPropertyName("amount")]
    public float? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("partner_balance_after")]
    public float? PartnerBalanceAfter { get; set; }

    [JsonPropertyName("customer_balance_after")]
    public float? CustomerBalanceAfter { get; set; }

    [JsonPropertyName("status")]
    public BalanceTransferResultStatus? Status { get; set; }

    [JsonPropertyName("created_at")]
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
