using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One number attached to a campaign at the US 10DLC registry.
/// </summary>
[Serializable]
public record CampaignNumberPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Registry key for the number. Pass it in `numberKeys` on campaign number requests.
    /// </summary>
    [JsonPropertyName("numberKey")]
    public string? NumberKey { get; set; }

    /// <summary>
    /// The number, as digits with country code and no `+` (for example `14155550100`).
    /// </summary>
    [JsonPropertyName("number")]
    public string? Number { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of the number, for example `US`.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

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
