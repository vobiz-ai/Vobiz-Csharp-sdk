using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A two-way thread between one of your numbers (or RCS senders) and one contact on one channel. Vobiz creates it with the first message in either direction and adds every later message between the same pair on that channel.
/// </summary>
[Serializable]
public record Conversation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the conversation (UUID). Pass it to the conversation endpoints; messages carry it as `conversationId`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (Auth ID), for example `MA_XXXXXXXX`.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Your side of the thread: your number in E.164 format, or the `senderName` of your RCS sender.
    /// </summary>
    [JsonPropertyName("participantA")]
    public string? ParticipantA { get; set; }

    /// <summary>
    /// The contact's phone number in E.164 format.
    /// </summary>
    [JsonPropertyName("participantB")]
    public string? ParticipantB { get; set; }

    /// <summary>
    /// Channel the thread runs on: `sms`, `mms` or `rcs`. The same two parties have a separate conversation on each channel.
    /// </summary>
    [JsonPropertyName("channel")]
    public ConversationChannel? Channel { get; set; }

    /// <summary>
    /// Time of the latest message in the thread, sent or received (ISO 8601, UTC). Conversation lists are ordered by it, newest first.
    /// </summary>
    [JsonPropertyName("lastMessageAt")]
    public DateTime? LastMessageAt { get; set; }

    /// <summary>
    /// Total number of messages in the thread, in both directions.
    /// </summary>
    [JsonPropertyName("messageCount")]
    public int? MessageCount { get; set; }

    /// <summary>
    /// Number of messages added to the thread since it was last marked read. `POST /conversations/{id}/read` resets it to `0`.
    /// </summary>
    [JsonPropertyName("unreadCount")]
    public int? UnreadCount { get; set; }

    /// <summary>
    /// When the thread was last marked read (ISO 8601, UTC). Omitted until you first call `POST /conversations/{id}/read`.
    /// </summary>
    [JsonPropertyName("lastReadAt")]
    public DateTime? LastReadAt { get; set; }

    /// <summary>
    /// When the conversation was created, as an RFC 3339 / ISO 8601 timestamp in UTC.
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
