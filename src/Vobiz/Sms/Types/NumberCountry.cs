using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A country with messaging numbers in stock.
/// </summary>
[Serializable]
public record NumberCountry : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country. Pass it as `country` to `GET /numbers/available`.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// English name of the country, for example `United States`.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Number types in stock: `local`, `mobile`, `tollfree` or `shortcode`, or another lower-case inventory type.
    /// </summary>
    [JsonPropertyName("types")]
    public IEnumerable<string>? Types { get; set; }

    /// <summary>
    /// Upper-case capabilities offered by numbers in stock in the country, for example `SMS`, `MMS` and `VOICE`. Not every number has every capability; filter with `capabilities` on `GET /numbers/available`.
    /// </summary>
    [JsonPropertyName("capabilities")]
    public IEnumerable<string>? Capabilities { get; set; }

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
