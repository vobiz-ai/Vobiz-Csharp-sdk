using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record PartnerAnalyticsTotals : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("total_calls")]
    public int? TotalCalls { get; set; }

    [JsonPropertyName("answered_calls")]
    public int? AnsweredCalls { get; set; }

    [JsonPropertyName("failed_calls")]
    public int? FailedCalls { get; set; }

    [JsonPropertyName("total_duration_seconds")]
    public int? TotalDurationSeconds { get; set; }

    [JsonPropertyName("total_cost")]
    public float? TotalCost { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

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
