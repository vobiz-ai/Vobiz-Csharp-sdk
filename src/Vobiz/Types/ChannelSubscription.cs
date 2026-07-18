using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ChannelSubscription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("account_id")]
    public required int AccountId { get; set; }

    [JsonPropertyName("resource_type")]
    public required CapacityResourceType ResourceType { get; set; }

    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    /// <summary>
    /// Recurring monthly charge as a decimal string.
    /// </summary>
    [JsonPropertyName("monthly_cost")]
    public required string MonthlyCost { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("last_billing_date")]
    public required DateTime LastBillingDate { get; set; }

    [JsonPropertyName("next_billing_date")]
    public required DateTime NextBillingDate { get; set; }

    [JsonPropertyName("purchased_at")]
    public required DateTime PurchasedAt { get; set; }

    [JsonPropertyName("cancelled_at")]
    public DateTime? CancelledAt { get; set; }

    [JsonPropertyName("cancellation_reason")]
    public string? CancellationReason { get; set; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
