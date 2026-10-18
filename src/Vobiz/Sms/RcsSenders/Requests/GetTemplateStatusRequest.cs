using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record GetTemplateStatusRequest
{
    /// <summary>
    /// The `id` (UUID) of the RCS sender that owns the templates. An unknown sender returns `sender not found`.
    /// </summary>
    [JsonIgnore]
    public required string SenderId { get; set; }

    /// <summary>
    /// The template's `templateName`, exactly as you set it when you created the template on this sender.
    /// </summary>
    [JsonIgnore]
    public required string TemplateName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
