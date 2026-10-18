using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Numbers to add to, remove from or re-register on a campaign. Provide `numbers`, `numberKeys`, or both; if both are empty the request returns `400` with `invalid request: numbers or numberKeys is required`.
/// </summary>
[Serializable]
public record CampaignNumbersRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Phone numbers on your account, as digits with country code and no `+` (for example `14155550100`). These values also update the campaign's `numbers` list on add and remove.
    /// </summary>
    [JsonPropertyName("numbers")]
    public IEnumerable<string>? Numbers { get; set; }

    /// <summary>
    /// Registry number keys from `GET /10dlc/campaigns/{id}/numbers`, as an alternative to `numbers`.
    /// </summary>
    [JsonPropertyName("numberKeys")]
    public IEnumerable<string>? NumberKeys { get; set; }

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
