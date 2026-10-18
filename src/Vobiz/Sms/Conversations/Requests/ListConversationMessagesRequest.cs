using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListConversationMessagesRequest
{
    /// <summary>
    /// The conversation `id` (UUID), from `GET /conversations` or the `conversationId` on any message.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// Maximum number of messages to return, from `1` to `100`. Defaults to `50`; a value outside that range also returns `50`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of messages to skip before the page starts, `0` or greater. Defaults to `0`. Add the page size to it to load older messages.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
