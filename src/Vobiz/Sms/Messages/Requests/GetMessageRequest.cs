using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record GetMessageRequest
{
    /// <summary>
    /// The message `id` (UUID) returned by `POST /messages`, `GET /messages`, a conversation, or an event.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
