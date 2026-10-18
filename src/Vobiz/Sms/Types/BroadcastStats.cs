using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Counts of the broadcast's stored recipients by state, recounted every time you read the broadcast.
/// </summary>
[Serializable]
public record BroadcastStats : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Recipients stored on the broadcast, including opted-out ones. Invalid rows and duplicates from the upload are not stored and not counted.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Recipients still waiting to be sent.
    /// </summary>
    [JsonPropertyName("pending")]
    public int? Pending { get; set; }

    /// <summary>
    /// Recipients whose message was accepted for sending and has no delivery report yet.
    /// </summary>
    [JsonPropertyName("sent")]
    public int? Sent { get; set; }

    /// <summary>
    /// Recipients whose message was reported delivered.
    /// </summary>
    [JsonPropertyName("delivered")]
    public int? Delivered { get; set; }

    /// <summary>
    /// Recipients whose message failed. Their `errorCode` says why.
    /// </summary>
    [JsonPropertyName("failed")]
    public int? Failed { get; set; }

    /// <summary>
    /// Recipients excluded because the number opted out of SMS from you. They are never sent.
    /// </summary>
    [JsonPropertyName("optedOut")]
    public int? OptedOut { get; set; }

    /// <summary>
    /// Recipients that were still pending when the broadcast was cancelled.
    /// </summary>
    [JsonPropertyName("skipped")]
    public int? Skipped { get; set; }

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
