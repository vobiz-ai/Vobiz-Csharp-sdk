using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The campaign's status on one US carrier network, read live from the US 10DLC registry.
/// </summary>
[Serializable]
public record CampaignNetworkStatus : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Carrier network the entry describes, for example `T_MOBILE`, `ATT` or `VERIZON`.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }

    /// <summary>
    /// The campaign's registration state on that network, for example `ACTIVE` once provisioned.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Message class the network assigned to the campaign. `null` when the network does not report one.
    /// </summary>
    [JsonPropertyName("messageClass")]
    public string? MessageClass { get; set; }

    /// <summary>
    /// Throughput the network grants the campaign. The unit depends on the network (messages per minute on some, a daily cap on others). `null` when the network does not report one.
    /// </summary>
    [JsonPropertyName("throughput")]
    public int? Throughput { get; set; }

    /// <summary>
    /// Brand tier the network applies, for example `LOW`. `null` when the network does not use tiers.
    /// </summary>
    [JsonPropertyName("brandTier")]
    public string? BrandTier { get; set; }

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
