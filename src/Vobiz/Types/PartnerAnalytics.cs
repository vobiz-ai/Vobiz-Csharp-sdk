using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Aggregated call analytics across all customer accounts for a date range.
/// </summary>
[Serializable]
public record PartnerAnalytics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("period")]
    public PartnerAnalyticsPeriod? Period { get; set; }

    [JsonPropertyName("totals")]
    public PartnerAnalyticsTotals? Totals { get; set; }

    [JsonPropertyName("by_direction")]
    public PartnerAnalyticsByDirection? ByDirection { get; set; }

    [JsonPropertyName("top_customers")]
    public IEnumerable<PartnerAnalyticsTopCustomersItem>? TopCustomers { get; set; }

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
