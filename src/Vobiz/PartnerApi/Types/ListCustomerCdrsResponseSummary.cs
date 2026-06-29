using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerCdrsResponseSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("answerRate")]
    public required int AnswerRate { get; set; }

    [JsonPropertyName("answeredCalls")]
    public required int AnsweredCalls { get; set; }

    [JsonPropertyName("avgCallDuration")]
    public required string AvgCallDuration { get; set; }

    [JsonPropertyName("last_call_at")]
    public required string LastCallAt { get; set; }

    [JsonPropertyName("totalCalls")]
    public required int TotalCalls { get; set; }

    [JsonPropertyName("total_billable_seconds")]
    public required int TotalBillableSeconds { get; set; }

    [JsonPropertyName("total_cost")]
    public required int TotalCost { get; set; }

    [JsonPropertyName("total_duration_seconds")]
    public required int TotalDurationSeconds { get; set; }

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
