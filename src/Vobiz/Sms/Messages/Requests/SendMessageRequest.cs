using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record SendMessageRequest
{
    /// <summary>
    /// The sender. For `sms` and `mms`, one of your Vobiz numbers in E.164 format, for example `+14155550100`. For `rcs`, the `senderName` of your RCS sender (from `GET /senders`); with `failoverToSms`, the SMS copy is sent from a number on your account.
    /// </summary>
    [JsonPropertyName("from")]
    public required string From { get; set; }

    /// <summary>
    /// One or more recipient numbers in E.164 format. Each one becomes a separate message with its own `id`; blank entries and duplicates are ignored. At least one recipient is required.
    /// </summary>
    [JsonPropertyName("to")]
    public IEnumerable<string> To { get; set; } = new List<string>();

    /// <summary>
    /// Channel to send on: `sms`, `mms` or `rcs`. Defaults to `sms`. An `sms` with `mediaUrls` to US or Canadian recipients is sent as MMS automatically.
    /// </summary>
    [JsonPropertyName("channel")]
    public SendMessageRequestChannel? Channel { get; set; }

    /// <summary>
    /// Message body. Required for `sms` and `rcs`. A long SMS is split into segments and billed per segment (160 GSM-7 or 70 UCS-2 characters fit in one segment). For `mms`, provide `text`, `mediaUrls` or both, with `text` up to 5000 characters.
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Publicly reachable `https` URLs of media to attach. MMS accepts up to 10. RCS sends the first URL as a file. An SMS to recipients outside the US and Canada is sent as text only.
    /// </summary>
    [JsonPropertyName("mediaUrls")]
    public IEnumerable<string>? MediaUrls { get; set; }

    /// <summary>
    /// Subject line of an MMS. Used only when the message is sent as MMS.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Your own label, stored on every message the request creates. Filter `GET /messages` by it to find all recipients of one send or to group messages for reporting.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// A unique string you choose, for example a UUID or your own order ID, scoped to your account. Retrying with the same key returns the original message instead of sending again. With several recipients the key is applied per recipient.
    /// </summary>
    [JsonPropertyName("idempotencyKey")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Time to hold the message until, as an RFC 3339 / ISO 8601 timestamp such as `2026-11-01T09:00:00Z`. A future time stores the message with status `scheduled`; a past time or now sends immediately.
    /// </summary>
    [JsonPropertyName("scheduledAt")]
    public DateTime? ScheduledAt { get; set; }

    /// <summary>
    /// Used only when `channel` is `rcs`. When `true` and the RCS send cannot go through, Vobiz sends the same `text` as SMS and the message's `channel` becomes `sms`. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("failoverToSms")]
    public bool? FailoverToSms { get; set; }

    /// <summary>
    /// Suggestion buttons (suggested replies and actions) to show under an RCS message. Used only when `channel` is `rcs`. See the RCS suggestion object for each `type`.
    /// </summary>
    [JsonPropertyName("rcsSuggestions")]
    public IEnumerable<RcsSuggestion>? RcsSuggestions { get; set; }

    /// <summary>
    /// India (TRAI DLT): the Principal Entity ID you registered on a TRAI DLT portal. Pass it on every message to Indian numbers.
    /// </summary>
    [JsonPropertyName("dltEntityId")]
    public string? DltEntityId { get; set; }

    /// <summary>
    /// India (TRAI DLT): the ID of the sender header you registered on a TRAI DLT portal. Pass it on every message to Indian numbers.
    /// </summary>
    [JsonPropertyName("dltHeaderId")]
    public string? DltHeaderId { get; set; }

    /// <summary>
    /// India (TRAI DLT): the ID of the content template you registered on a TRAI DLT portal. `text` must match that template with its variables filled in.
    /// </summary>
    [JsonPropertyName("dltTemplateId")]
    public string? DltTemplateId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
