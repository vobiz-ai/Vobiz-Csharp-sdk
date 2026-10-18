using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A messaging-capable number on your account, with its registration state and what it can send.
/// </summary>
[Serializable]
public record SmsNumber : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The number in E.164 format. Use it as `from` when you send.
    /// </summary>
    [JsonPropertyName("e164")]
    public string? E164 { get; set; }

    /// <summary>
    /// Internal routing identifier; do not rely on its value.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Upper-case ISO 3166-1 alpha-2 code of the number's country. Empty string when unknown.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Lower-case channels routed on the number: `sms`, `mms` and `rcs`. Defaults to `["sms"]`.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<SmsNumberChannelsItem>? Channels { get; set; }

    /// <summary>
    /// Inventory type in upper case, for example `VIRTUAL_LONG_NUMBER`, `SHORT_CODE` or `TOLL_FREE`. Empty string when unknown.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Upper-case capability labels, for example `SMS`, `MMS` and `VOICE`. Empty array when unknown.
    /// </summary>
    [JsonPropertyName("capabilities")]
    public IEnumerable<string>? Capabilities { get; set; }

    /// <summary>
    /// The most relevant US registration campaign attached to the number. `null` when no campaign is attached.
    /// </summary>
    [JsonPropertyName("tenDlc")]
    public SmsNumberTenDlc? TenDlc { get; set; }

    /// <summary>
    /// `true` for US toll-free numbers, which use toll-free verification instead of a 10DLC campaign.
    /// </summary>
    [JsonPropertyName("tollFree")]
    public bool? TollFree { get; set; }

    /// <summary>
    /// US A2P registration state of the number and the campaign behind it.
    /// </summary>
    [JsonPropertyName("registration")]
    public SmsNumberRegistration? Registration { get; set; }

    /// <summary>
    /// The latest outbound message sent from this number. `null` when the number has not sent a message yet.
    /// </summary>
    [JsonPropertyName("lastMessage")]
    public SmsNumberLastMessage? LastMessage { get; set; }

    /// <summary>
    /// Where the number can send right now, derived from its country and registration state.
    /// </summary>
    [JsonPropertyName("sendable")]
    public SmsNumberSendable? Sendable { get; set; }

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
