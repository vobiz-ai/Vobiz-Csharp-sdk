using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListRecipientsRequest
{
    /// <summary>
    /// The broadcast's `id` (UUID), as returned by `POST /broadcasts` or `GET /broadcasts`. An id that is not a UUID, or that belongs to another account, returns `404` with `broadcast not found`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// Return only recipients in this state, matched case-insensitively. `pending` waits to send, `sending` is in progress, `sent` and `delivered` track the message, `failed` has an `errorCode`, `opted_out` was excluded because the number opted out, and `skipped` was still pending when the broadcast was cancelled. Omit it to return every recipient; any other value returns `400`.
    /// </summary>
    [JsonIgnore]
    public ListRecipientsRequestStatus? Status { get; set; }

    /// <summary>
    /// Maximum number of recipients to return, from 1 to 500. Defaults to 50 when you omit it or pass `0`. A value above 500 returns `400` with `limit must be between 1 and 500`, and a non-integer returns `400` with `limit must be an integer`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of recipients to skip before the page starts, for paging through results with `limit`. Defaults to `0`. A negative value returns `400` with `offset must be &gt;= 0`, and a non-integer returns `400` with `offset must be an integer`.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
