using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The full coverage record for one destination country, returned by `GET /coverage/{country}`.
/// </summary>
[Serializable]
public record CoverageDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// English name of the country or territory, for example `United States`.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Geographic region the country belongs to, for example `Northern America`. Use this value with the `region` filter on `GET /coverage`. `null` when not assigned.
    /// </summary>
    [JsonPropertyName("region")]
    public string? Region { get; set; }

    /// <summary>
    /// Country calling code without the `+`, for example `1` or `44`.
    /// </summary>
    [JsonPropertyName("dialCode")]
    public string? DialCode { get; set; }

    /// <summary>
    /// Mobile country code (MCC) of the country's networks, for example `311`. `null` when not published.
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// `true` when subscribers can keep their number when they change network, `null` when unknown.
    /// </summary>
    [JsonPropertyName("numberPortability")]
    public bool? NumberPortability { get; set; }

    /// <summary>
    /// `true` when the country applies different rules to local (in-country) and international senders. When `true`, read the `local` and `international` values of each rule separately.
    /// </summary>
    [JsonPropertyName("localVsInternationalTraffic")]
    public bool? LocalVsInternationalTraffic { get; set; }

    /// <summary>
    /// Which sender types the country accepts, for local and international traffic.
    /// </summary>
    [JsonPropertyName("senders")]
    public CoverageSenders? Senders { get; set; }

    /// <summary>
    /// Whether senders must be registered, and what registration involves.
    /// </summary>
    [JsonPropertyName("registration")]
    public CoverageRegistration? Registration { get; set; }

    /// <summary>
    /// Rules for links in message bodies.
    /// </summary>
    [JsonPropertyName("urls")]
    public CoverageUrls? Urls { get; set; }

    /// <summary>
    /// `true` when messages must offer an opt-out, such as replying STOP. `null` when unknown.
    /// </summary>
    [JsonPropertyName("optOutMandatory")]
    public bool? OptOutMandatory { get; set; }

    /// <summary>
    /// `true` when recipients can reply to your messages, `false` when they cannot, `null` when unknown.
    /// </summary>
    [JsonPropertyName("twoWay")]
    public bool? TwoWay { get; set; }

    /// <summary>
    /// Content categories that may not be sent to the country, for example `Gambling` or `Phishing`. Empty array when none are listed.
    /// </summary>
    [JsonPropertyName("prohibitedTopics")]
    public IEnumerable<string>? ProhibitedTopics { get; set; }

    /// <summary>
    /// Free-text detail on prohibited or restricted content. `null` when none.
    /// </summary>
    [JsonPropertyName("prohibitedNotes")]
    public string? ProhibitedNotes { get; set; }

    /// <summary>
    /// Hours during which you may send, by day type. `null` when the country has no sending window.
    /// </summary>
    [JsonPropertyName("sendWindow")]
    public CoverageSendWindow? SendWindow { get; set; }

    /// <summary>
    /// Free-text guidance on sending to this market, such as sender behaviour and local rules. `null` when none.
    /// </summary>
    [JsonPropertyName("marketNotes")]
    public string? MarketNotes { get; set; }

    /// <summary>
    /// When the coverage dataset was last refreshed (ISO 8601).
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

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
