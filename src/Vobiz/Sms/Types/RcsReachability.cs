using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Whether a phone number can receive RCS messages from your RCS sender.
/// </summary>
[Serializable]
public record RcsReachability : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The phone number that was checked, in E.164 format.
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>
    /// `true` when the number can receive RCS from your sender. When `false`, send as SMS or set `failoverToSms` on an RCS send.
    /// </summary>
    [JsonPropertyName("reachable")]
    public bool? Reachable { get; set; }

    /// <summary>
    /// Name of the recipient's mobile carrier. Omitted when it is not known.
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    /// <summary>
    /// Capability label returned with the result, for example `reachable`. Base your decision on `reachable`.
    /// </summary>
    [JsonPropertyName("capability")]
    public string? Capability { get; set; }

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
