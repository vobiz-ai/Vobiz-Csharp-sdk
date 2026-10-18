using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Where a number can send right now, derived from its country and registration state. Check it before you send.
/// </summary>
[Serializable]
public record SmsNumberSendable : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// `true` when the number can send to recipients outside the US.
    /// </summary>
    [JsonPropertyName("international")]
    public bool? International { get; set; }

    /// <summary>
    /// `true` when the number can send to US recipients. A US number needs an approved 10DLC campaign or completed toll-free verification before this becomes `true`.
    /// </summary>
    [JsonPropertyName("usDomestic")]
    public bool? UsDomestic { get; set; }

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
