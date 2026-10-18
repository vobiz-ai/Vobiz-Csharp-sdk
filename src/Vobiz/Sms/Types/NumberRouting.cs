using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The routing record that connects a purchased number to your account for messaging.
/// </summary>
[Serializable]
public record NumberRouting : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Numeric identifier of the routing record.
    /// </summary>
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    /// <summary>
    /// The routed number in E.164 format.
    /// </summary>
    [JsonPropertyName("e164")]
    public string? E164 { get; set; }

    /// <summary>
    /// Internal routing identifier; do not rely on its value.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Lower-case messaging channels routed on the number, for example `sms` and `mms`.
    /// </summary>
    [JsonPropertyName("channelCapabilities")]
    public IEnumerable<string>? ChannelCapabilities { get; set; }

    /// <summary>
    /// Auth ID of the account the number is routed to, for example `MA_XXXXXXXX`.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the number's country.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// When the number was routed to your account (ISO 8601).
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

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
