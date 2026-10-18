using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record MarkConversationReadRequest
{
    /// <summary>
    /// The conversation `id` (UUID) to mark as read.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
