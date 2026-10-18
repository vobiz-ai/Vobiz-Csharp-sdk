using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CancelBroadcastRequest
{
    /// <summary>
    /// The broadcast's `id` (UUID), as returned by `POST /broadcasts` or `GET /broadcasts`. An id that is not a UUID, or that belongs to another account, returns `404` with `broadcast not found`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
