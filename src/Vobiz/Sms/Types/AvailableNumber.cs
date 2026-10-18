using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A number in the inventory that you can buy, with its type, capabilities and price.
/// </summary>
[Serializable]
public record AvailableNumber : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The number in E.164 format. Pass it as `e164` on `POST /numbers/purchase`.
    /// </summary>
    [JsonPropertyName("e164")]
    public string? E164 { get; set; }

    /// <summary>
    /// Opaque inventory key for the number. Pass it as `numberKey` on `POST /numbers/purchase` when it is not empty; it is empty for US numbers, which are bought by `e164` alone.
    /// </summary>
    [JsonPropertyName("numberKey")]
    public string? NumberKey { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country the number belongs to.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Inventory type of the number in upper case, for example `VIRTUAL_LONG_NUMBER` or `TOLL_FREE`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Upper-case capability labels for the number, for example `SMS`, `MMS` and `VOICE`. Order is not significant.
    /// </summary>
    [JsonPropertyName("capabilities")]
    public IEnumerable<string>? Capabilities { get; set; }

    /// <summary>
    /// Name of the mobile network the number belongs to, when published. Empty string otherwise.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// One-time setup fee charged at purchase, in `currency`.
    /// </summary>
    [JsonPropertyName("setupPrice")]
    public double? SetupPrice { get; set; }

    /// <summary>
    /// Monthly rental charged at purchase for the first month and then on each renewal, in `currency`.
    /// </summary>
    [JsonPropertyName("monthlyPrice")]
    public double? MonthlyPrice { get; set; }

    /// <summary>
    /// ISO 4217 code of the prices, which is your wallet currency, for example `USD`.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// `true` when the number needs regulatory documents before it can be activated. Contact support to buy such a number; `POST /numbers/purchase` returns `422` for it.
    /// </summary>
    [JsonPropertyName("providerRequiresDocuments")]
    public bool? ProviderRequiresDocuments { get; set; }

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
