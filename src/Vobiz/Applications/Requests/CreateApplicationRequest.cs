using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateApplicationRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonPropertyName("app_name")]
    public required string AppName { get; set; }

    [JsonPropertyName("answer_url")]
    public required string AnswerUrl { get; set; }

    [JsonPropertyName("answer_method")]
    public required string AnswerMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
