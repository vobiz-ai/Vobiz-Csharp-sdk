using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One row of the coverage list, with the key rules for a destination country. Call `GET /coverage/{country}` for the full record.
/// </summary>
[Serializable]
public record CoverageSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country. Pass it to `GET /coverage/{country}`.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// English name of the country or territory, for example `United States`.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Geographic region the country belongs to, for example `Northern America`. `null` when not assigned.
    /// </summary>
    [JsonPropertyName("region")]
    public string? Region { get; set; }

    /// <summary>
    /// Country calling code without the `+`, for example `1` or `44`.
    /// </summary>
    [JsonPropertyName("dialCode")]
    public string? DialCode { get; set; }

    /// <summary>
    /// Which sender types the country accepts, for local and international traffic.
    /// </summary>
    [JsonPropertyName("senders")]
    public CoverageSenders? Senders { get; set; }

    /// <summary>
    /// Whether senders must be registered before sending, for local and international traffic.
    /// </summary>
    [JsonPropertyName("registrationRequired")]
    public LocalIntl? RegistrationRequired { get; set; }

    /// <summary>
    /// `true` when recipients can reply to your messages, `false` when they cannot, `null` when unknown.
    /// </summary>
    [JsonPropertyName("twoWay")]
    public bool? TwoWay { get; set; }

    /// <summary>
    /// `true` when messages must offer an opt-out, such as replying STOP. `null` when unknown.
    /// </summary>
    [JsonPropertyName("optOutMandatory")]
    public bool? OptOutMandatory { get; set; }

    /// <summary>
    /// `true` when the country restricts sending to certain hours. Read `sendWindow` on `GET /coverage/{country}` for the hours.
    /// </summary>
    [JsonPropertyName("hasSendWindow")]
    public bool? HasSendWindow { get; set; }

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
