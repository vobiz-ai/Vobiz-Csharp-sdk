using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record GetSenderRequest
{
    /// <summary>
    /// The sender's `id` (UUID), as returned by `POST /senders` or `GET /senders`. An unknown id returns `sender not found`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
