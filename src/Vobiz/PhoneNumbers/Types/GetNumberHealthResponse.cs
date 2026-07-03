using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetNumberHealthResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("e164")]
    public string? E164 { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Reputation/usage rating for the number.
    /// </summary>
    [JsonPropertyName("usage_status")]
    public string? UsageStatus { get; set; }

    [JsonPropertyName("is_spam")]
    public bool? IsSpam { get; set; }

    [JsonPropertyName("granularity")]
    public string? Granularity { get; set; }

    [JsonPropertyName("summary")]
    public GetNumberHealthResponseSummary? Summary { get; set; }

    [JsonPropertyName("snapshots")]
    public IEnumerable<GetNumberHealthResponseSnapshotsItem>? Snapshots { get; set; }

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
