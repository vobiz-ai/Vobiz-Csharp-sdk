using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Rules for links in message bodies sent to a destination country.
/// </summary>
[Serializable]
public record CoverageUrls : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether message bodies may contain URLs, for local and international traffic.
    /// </summary>
    [JsonPropertyName("allowed")]
    public LocalIntl? Allowed { get; set; }

    /// <summary>
    /// Whether the domains you link to must be registered (whitelisted) in advance, for local and international traffic.
    /// </summary>
    [JsonPropertyName("whitelistingRequired")]
    public LocalIntl? WhitelistingRequired { get; set; }

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
