using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Countries where you can buy messaging numbers, from a snapshot of the inventory.
/// </summary>
[Serializable]
public record NumberCountries : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Countries with numbers in stock. Empty while `ready` is `false`.
    /// </summary>
    [JsonPropertyName("countries")]
    public IEnumerable<NumberCountry>? Countries { get; set; }

    /// <summary>
    /// When the stock snapshot was last refreshed (ISO 8601). `null` until the first snapshot is built.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// `true` once the stock snapshot has been built. While `false`, `countries` is empty and `updatedAt` is `null`; retry after a few seconds.
    /// </summary>
    [JsonPropertyName("ready")]
    public bool? Ready { get; set; }

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
