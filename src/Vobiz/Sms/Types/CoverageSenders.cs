using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Which sender types a destination accepts, each split into local and international traffic.
/// </summary>
[Serializable]
public record CoverageSenders : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether alphanumeric sender IDs (a brand name such as `ACME` in place of a number) are accepted.
    /// </summary>
    [JsonPropertyName("alphanumeric")]
    public LocalIntl? Alphanumeric { get; set; }

    /// <summary>
    /// Whether short codes (5 or 6 digit numbers) are accepted as senders.
    /// </summary>
    [JsonPropertyName("shortCode")]
    public LocalIntl? ShortCode { get; set; }

    /// <summary>
    /// Whether long numbers (standard-length phone numbers, such as US 10DLC numbers) are accepted as senders.
    /// </summary>
    [JsonPropertyName("longNumber")]
    public LocalIntl? LongNumber { get; set; }

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
