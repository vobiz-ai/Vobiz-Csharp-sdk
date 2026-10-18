using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One suggestion button on an RCS message: a suggested reply or an action the recipient can tap. Which optional fields apply depends on `type`.
/// </summary>
[Serializable]
public record RcsSuggestion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// What the button does: `REPLY` sends `text` back as a reply, `OPEN_URL` opens `url`, `DIAL_PHONE` calls `phoneNumber`, `SHOW_LOCATION` shows a map pin at `latitude`/`longitude`, and `REQUEST_LOCATION` asks the recipient to share their location.
    /// </summary>
    [JsonPropertyName("type")]
    public required RcsSuggestionType Type { get; set; }

    /// <summary>
    /// Button label shown to the recipient. Keep it short so it fits on the button.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// Your own string, returned to you with the inbound event when the recipient taps the button. Use it to tell which button was tapped.
    /// </summary>
    [JsonPropertyName("postbackData")]
    public string? PostbackData { get; set; }

    /// <summary>
    /// HTTPS link to open. Used only when `type` is `OPEN_URL`.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Phone number to dial, in E.164 format. Used only when `type` is `DIAL_PHONE`.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Latitude of the map pin, in decimal degrees from `-90` to `90`. Used only when `type` is `SHOW_LOCATION`.
    /// </summary>
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    /// <summary>
    /// Longitude of the map pin, in decimal degrees from `-180` to `180`. Used only when `type` is `SHOW_LOCATION`.
    /// </summary>
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    /// <summary>
    /// Label shown on the map pin. Used only when `type` is `SHOW_LOCATION`.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

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
