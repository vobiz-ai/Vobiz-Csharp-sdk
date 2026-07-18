using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ChannelPricingPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("resource_type")]
    public required CapacityResourceType ResourceType { get; set; }

    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    /// <summary>
    /// Calculated monthly charge as a decimal string.
    /// </summary>
    [JsonPropertyName("monthly_cost")]
    public required string MonthlyCost { get; set; }

    /// <summary>
    /// Currency assigned by the account's pricing tier.
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// Pricing-bracket calculation details when supplied by the pricing tier.
    /// </summary>
    [JsonPropertyName("breakdown")]
    public IEnumerable<Dictionary<string, object?>> Breakdown { get; set; } =
        new List<Dictionary<string, object?>>();

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
