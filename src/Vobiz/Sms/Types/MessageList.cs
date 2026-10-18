using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One page of messages from `GET /messages`, with the total number of matches so you can page through the rest.
/// </summary>
[Serializable]
public record MessageList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The messages on this page, newest first. An empty array when nothing matches.
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<Message>? Messages { get; set; }

    /// <summary>
    /// Total number of messages that match your filters across all pages. Stop paging when `offset` plus the page length reaches it.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// The `limit` you sent in the request, or `0` when you omitted it. The page itself holds at most 100 messages, and 20 when `limit` is omitted.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The number of messages skipped before this page, as sent in the request.
    /// </summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

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
