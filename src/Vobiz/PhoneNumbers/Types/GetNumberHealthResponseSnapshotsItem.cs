using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetNumberHealthResponseSnapshotsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ts")]
    public DateTime? Ts { get; set; }

    [JsonPropertyName("total_calls")]
    public int? TotalCalls { get; set; }

    [JsonPropertyName("answered_calls")]
    public int? AnsweredCalls { get; set; }

    [JsonPropertyName("failed_calls")]
    public int? FailedCalls { get; set; }

    [JsonPropertyName("answer_rate")]
    public double? AnswerRate { get; set; }

    [JsonPropertyName("total_duration")]
    public double? TotalDuration { get; set; }

    [JsonPropertyName("avg_duration")]
    public double? AvgDuration { get; set; }

    [JsonPropertyName("total_minutes")]
    public double? TotalMinutes { get; set; }

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
