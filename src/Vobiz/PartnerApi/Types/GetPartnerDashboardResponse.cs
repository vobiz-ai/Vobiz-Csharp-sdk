using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetPartnerDashboardResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("partner")]
    public required GetPartnerDashboardResponsePartner Partner { get; set; }

    [JsonPropertyName("period")]
    public required GetPartnerDashboardResponsePeriod Period { get; set; }

    [JsonPropertyName("accounts")]
    public required GetPartnerDashboardResponseAccounts Accounts { get; set; }

    [JsonPropertyName("total_balance")]
    public required string TotalBalance { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("calls")]
    public required GetPartnerDashboardResponseCalls Calls { get; set; }

    [JsonPropertyName("traffic")]
    public required GetPartnerDashboardResponseTraffic Traffic { get; set; }

    [JsonPropertyName("by_product")]
    public required GetPartnerDashboardResponseByProduct ByProduct { get; set; }

    [JsonPropertyName("time_series")]
    public IEnumerable<GetPartnerDashboardResponseTimeSeriesItem> TimeSeries { get; set; } =
        new List<GetPartnerDashboardResponseTimeSeriesItem>();

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
