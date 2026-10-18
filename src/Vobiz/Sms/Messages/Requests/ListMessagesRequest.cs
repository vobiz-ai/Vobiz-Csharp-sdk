using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListMessagesRequest
{
    /// <summary>
    /// Only messages with this status: `scheduled`, `sent`, `delivered`, `failed`, `received` (inbound) or `unknown`.
    /// </summary>
    [JsonIgnore]
    public ListMessagesRequestStatus? Status { get; set; }

    /// <summary>
    /// Only messages sent or received on this channel: `sms`, `mms` or `rcs`. This is the channel actually used, so an SMS that was upgraded to MMS appears under `mms`.
    /// </summary>
    [JsonIgnore]
    public ListMessagesRequestChannel? Channel { get; set; }

    /// <summary>
    /// `out` for messages you sent, `in` for messages your numbers received.
    /// </summary>
    [JsonIgnore]
    public ListMessagesRequestDirection? Direction { get; set; }

    /// <summary>
    /// Recipient number to filter on, in E.164 format, exact match. For inbound messages this is your number.
    /// </summary>
    [JsonIgnore]
    public string? To { get; set; }

    /// <summary>
    /// Sender to filter on, exact match: one of your numbers in E.164 format (for example `+14155550100`), or the `senderName` of your RCS sender for RCS messages. For inbound messages this is the contact's number.
    /// </summary>
    [JsonIgnore]
    public string? From { get; set; }

    /// <summary>
    /// Only messages whose `tag` equals this value, exact match. Set the same `tag` on related sends to retrieve them together.
    /// </summary>
    [JsonIgnore]
    public string? Tag { get; set; }

    /// <summary>
    /// Only messages created at or after this time, as an RFC 3339 / ISO 8601 timestamp such as `2026-10-01T00:00:00Z`.
    /// </summary>
    [JsonIgnore]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Only messages created before this time, as an RFC 3339 / ISO 8601 timestamp such as `2026-11-01T00:00:00Z`. Combine with `startDate` for a date range.
    /// </summary>
    [JsonIgnore]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Maximum number of messages to return, from `1` to `100`. Defaults to `20`; a value outside that range also returns `20`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of records to skip before the page starts, `0` or greater. Defaults to `0`. Add the page size to it to fetch the next page.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
