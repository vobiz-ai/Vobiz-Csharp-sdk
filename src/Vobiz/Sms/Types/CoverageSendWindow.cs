using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The hours during which messages may be sent to the country. Each value is a text range with its timezone rule, for example `MON - FRI: 10:00:00 - 21:00:00; Timezone from MSISDN`, which means the recipient's local time.
/// </summary>
[Serializable]
public record CoverageSendWindow : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Permitted sending hours Monday to Friday, with the timezone rule.
    /// </summary>
    [JsonPropertyName("weekday")]
    public string? Weekday { get; set; }

    /// <summary>
    /// Permitted sending hours on Saturday, with the timezone rule.
    /// </summary>
    [JsonPropertyName("saturday")]
    public string? Saturday { get; set; }

    /// <summary>
    /// Permitted sending hours on Sunday, with the timezone rule.
    /// </summary>
    [JsonPropertyName("sunday")]
    public string? Sunday { get; set; }

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
