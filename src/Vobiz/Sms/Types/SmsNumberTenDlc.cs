using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The most relevant US registration campaign attached to a number. `null` when no campaign is attached.
/// </summary>
[Serializable]
public record SmsNumberTenDlc : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the campaign the number is registered to. Use it with the 10DLC campaign endpoints.
    /// </summary>
    [JsonPropertyName("campaignId")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Name you gave that campaign.
    /// </summary>
    [JsonPropertyName("campaignName")]
    public string? CampaignName { get; set; }

    /// <summary>
    /// Registry stage of the campaign in upper case, for example `REGISTERED` or `IN_REVIEW`. Treat as an open string.
    /// </summary>
    [JsonPropertyName("stage")]
    public string? Stage { get; set; }

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
