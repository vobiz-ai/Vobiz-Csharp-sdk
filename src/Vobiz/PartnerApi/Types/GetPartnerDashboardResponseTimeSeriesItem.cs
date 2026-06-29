using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetPartnerDashboardResponseTimeSeriesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("date")]
    public required string Date { get; set; }

    [JsonPropertyName("total_calls")]
    public required int TotalCalls { get; set; }

    [JsonPropertyName("answered_calls")]
    public required int AnsweredCalls { get; set; }

    [JsonPropertyName("total_minutes")]
    public required double TotalMinutes { get; set; }

    [JsonPropertyName("total_cost")]
    public required string TotalCost { get; set; }

    [JsonPropertyName("inbound")]
    public required GetPartnerDashboardResponseTimeSeriesItemInbound Inbound { get; set; }

    [JsonPropertyName("outbound")]
    public required GetPartnerDashboardResponseTimeSeriesItemOutbound Outbound { get; set; }

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
