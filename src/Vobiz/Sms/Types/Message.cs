using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One message sent from or received by your account. Each recipient of a send gets its own message object with its own `id`, status and conversation.
/// </summary>
[Serializable]
public record Message : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the message (UUID). Use it with `GET /messages/{id}` and to match status events.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (Auth ID), for example `MA_XXXXXXXX`.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// `out` for a message you sent, `in` for a message one of your numbers received.
    /// </summary>
    [JsonPropertyName("direction")]
    public MessageDirection? Direction { get; set; }

    /// <summary>
    /// Channel the message actually used: `sms`, `mms` or `rcs`. It can differ from the one you requested, for example `mms` after an SMS with media to US or Canadian numbers, or `sms` after an RCS send fell back with `failoverToSms`.
    /// </summary>
    [JsonPropertyName("channel")]
    public MessageChannel? Channel { get; set; }

    /// <summary>
    /// Sender. For outbound messages, your number in E.164 format or the `senderName` of your RCS sender; for inbound messages, the contact's number.
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>
    /// Recipient. For outbound messages, the contact's number in E.164 format; for inbound messages, your number.
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>
    /// Message body. An empty string when the message has no text, for example an MMS with media only.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// HTTPS URLs of the media attached to the message. `null` or an empty array when there is no media.
    /// </summary>
    [JsonPropertyName("mediaUrls")]
    public IEnumerable<string>? MediaUrls { get; set; }

    /// <summary>
    /// Where the message is in its lifecycle: `scheduled` (held for `scheduledAt`), `sent` (handed to the network), `delivered` (delivery confirmed), `failed` (see `errorCode` and `errorMessage`), `received` (inbound) or `unknown` (the network reported a status that maps to none of the others).
    /// </summary>
    [JsonPropertyName("status")]
    public MessageStatus? Status { get; set; }

    /// <summary>
    /// Error code reported for a failed message. Omitted when there is no error.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Human-readable reason a message failed. Omitted when there is no error; quote it to support when you need help with a failure.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// The label you set when sending, for filtering and reporting. Omitted when none was set.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// UUID of the conversation the message belongs to. Use it with `GET /conversations/{id}/messages` to load the thread.
    /// </summary>
    [JsonPropertyName("conversationId")]
    public string? ConversationId { get; set; }

    /// <summary>
    /// The time you asked the message to be held until (ISO 8601, UTC). Omitted for messages that were not scheduled.
    /// </summary>
    [JsonPropertyName("scheduledAt")]
    public DateTime? ScheduledAt { get; set; }

    /// <summary>
    /// When the message was created, as an RFC 3339 / ISO 8601 timestamp in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the message last changed, for example on a status update (ISO 8601, UTC).
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
