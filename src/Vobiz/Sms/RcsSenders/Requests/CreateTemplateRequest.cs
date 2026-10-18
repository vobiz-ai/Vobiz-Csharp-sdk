using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CreateTemplateRequest
{
    /// <summary>
    /// The `id` (UUID) of the RCS sender that owns the templates. An unknown sender returns `sender not found`.
    /// </summary>
    [JsonIgnore]
    public required string SenderId { get; set; }

    /// <summary>
    /// Unique name for the template on this sender. You use it in the path of every template endpoint.
    /// </summary>
    [JsonPropertyName("templateName")]
    public required string TemplateName { get; set; }

    /// <summary>
    /// Template type as defined by the RCS platform. It decides which `content` shape the platform expects.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Template content as a JSON object in the shape the RCS platform defines for the chosen `type`. Stored and returned exactly as you submit it.
    /// </summary>
    [JsonPropertyName("content")]
    public Dictionary<string, object?> Content { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
