using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// US A2P registration state of a number: which registration path applies and how far it has progressed.
/// </summary>
[Serializable]
public record SmsNumberRegistration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Registration path: `10dlc` for long numbers that need a 10DLC campaign, `toll_free` for toll-free numbers that need toll-free verification, `none` when no US registration applies.
    /// </summary>
    [JsonPropertyName("kind")]
    public SmsNumberRegistrationKind? Kind { get; set; }

    /// <summary>
    /// Progress of that registration: `not_registered` (no campaign attached), `draft` (campaign not submitted), `pending` (under review), `approved` (cleared to send to US recipients), `rejected` (fix and resubmit) or `not_required`.
    /// </summary>
    [JsonPropertyName("status")]
    public SmsNumberRegistrationStatus? Status { get; set; }

    /// <summary>
    /// ID of the campaign the number is attached to. Empty string when none.
    /// </summary>
    [JsonPropertyName("campaignId")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Name of that campaign. Empty string when none.
    /// </summary>
    [JsonPropertyName("campaignName")]
    public string? CampaignName { get; set; }

    /// <summary>
    /// Registry stage of that campaign in upper case, for example `REGISTERED`. Treat as an open string; empty string when none.
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
