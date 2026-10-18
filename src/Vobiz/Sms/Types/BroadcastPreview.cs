using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The template rendered for the first pending recipients, with the information you need to check a broadcast before launching it.
/// </summary>
[Serializable]
public record BroadcastPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The template rendered for up to `limit` pending recipients, in upload order. Empty when no recipient is pending.
    /// </summary>
    [JsonPropertyName("samples")]
    public IEnumerable<BroadcastPreviewSample>? Samples { get; set; }

    /// <summary>
    /// Placeholders in the template that have no matching upload column. They render as empty text; an empty array means every placeholder is filled.
    /// </summary>
    [JsonPropertyName("missingVariables")]
    public IEnumerable<string>? MissingVariables { get; set; }

    /// <summary>
    /// Total SMS segments across all pending recipients. Multiply by your per-segment rate to estimate the cost of the launch.
    /// </summary>
    [JsonPropertyName("estimatedSegments")]
    public int? EstimatedSegments { get; set; }

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
