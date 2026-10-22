using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record UpdateApplicationRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string AppId { get; set; }

    [JsonPropertyName("app_name")]
    public string? AppName { get; set; }

    [JsonPropertyName("default_number_app")]
    public bool? DefaultNumberApp { get; set; }

    /// <summary>
    /// URL Vobiz fetches VobizXML from when a call reaches a number or endpoint linked to this application.
    /// </summary>
    [JsonPropertyName("answer_url")]
    public string? AnswerUrl { get; set; }

    /// <summary>
    /// HTTP method used for `answer_url`, `GET` or `POST`.
    /// </summary>
    [JsonPropertyName("answer_method")]
    public string? AnswerMethod { get; set; }

    /// <summary>
    /// URL Vobiz notifies when a call on this application ends.
    /// </summary>
    [JsonPropertyName("hangup_url")]
    public string? HangupUrl { get; set; }

    /// <summary>
    /// HTTP method used for `hangup_url`, `GET` or `POST`.
    /// </summary>
    [JsonPropertyName("hangup_method")]
    public string? HangupMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
