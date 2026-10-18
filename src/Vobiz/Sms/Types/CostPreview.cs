using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// An estimate of what a message costs before you send it: how many segments the text splits into, and the price per segment and in total.
/// </summary>
[Serializable]
public record CostPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Channel the estimate is for: `sms`, `mms` or `rcs`, matching the `channel` you requested.
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>
    /// Number of segments the text splits into. A GSM-7 SMS fits 160 characters in one segment and 153 per segment when split; text with other characters uses UCS-2 (70 and 67).
    /// </summary>
    [JsonPropertyName("segmentCount")]
    public int? SegmentCount { get; set; }

    /// <summary>
    /// Price of one segment, in `currency`.
    /// </summary>
    [JsonPropertyName("unitCost")]
    public double? UnitCost { get; set; }

    /// <summary>
    /// Estimated price of the message to one recipient, in `currency`: `unitCost` multiplied by `segmentCount`.
    /// </summary>
    [JsonPropertyName("totalCost")]
    public double? TotalCost { get; set; }

    /// <summary>
    /// ISO 4217 code of the currency the prices are in, for example `USD`.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the destination country, for example `US`. Omitted when the destination country is not resolved.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

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
