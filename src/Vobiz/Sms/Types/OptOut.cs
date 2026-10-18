using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A phone number on your opt-out list for one channel. Vobiz blocks sends and broadcast deliveries to it on that channel until you delete the entry.
/// </summary>
[Serializable]
public record OptOut : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the opt-out record (UUID).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (Auth ID), for example `MA_XXXXXXXX`.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// The blocked phone number in E.164 format.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Channel the number is blocked on: `sms`, `mms` or `rcs`. An `sms` entry also blocks `mms`.
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>
    /// Why the entry exists. `stop`, `start` or `help` when the contact replied with a keyword; `manual` or your own text when you created it through the API or console.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// `inbound` when the entry came from a keyword reply, `manual` when you created it through the API or console.
    /// </summary>
    [JsonPropertyName("source")]
    public OptOutSource? Source { get; set; }

    /// <summary>
    /// `true` when the block has also been applied on the upstream network.
    /// </summary>
    [JsonPropertyName("syncedToProvider")]
    public bool? SyncedToProvider { get; set; }

    /// <summary>
    /// When the number was added to the list (ISO 8601, UTC).
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
