using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record PreviewBroadcastRequest
{
    /// <summary>
    /// The broadcast's `id` (UUID), as returned by `POST /broadcasts` or `GET /broadcasts`. An id that is not a UUID, or that belongs to another account, returns `404` with `broadcast not found`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// Number of pending recipients to render in `samples`, from 1 to 50. Defaults to 5 when you omit it or pass `0`. A value above 50 returns `400` with `limit must be between 1 and 50`, and a non-integer returns `400` with `limit must be an integer`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
