using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The template rendered for one recipient, with the encoding and segment count it will be sent with.
/// </summary>
[Serializable]
public record BroadcastPreviewSample : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The recipient's number in E.164 format.
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>
    /// The exact message text this recipient will receive, with their variables filled.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Number of SMS segments this text is sent and billed as.
    /// </summary>
    [JsonPropertyName("segments")]
    public int? Segments { get; set; }

    /// <summary>
    /// `GSM-7` when every character is in the GSM alphabet (160 characters in a single segment). `UCS-2` when the text contains other characters, such as emoji or most non-Latin scripts (70 characters in a single segment).
    /// </summary>
    [JsonPropertyName("encoding")]
    public BroadcastPreviewSampleEncoding? Encoding { get; set; }

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
