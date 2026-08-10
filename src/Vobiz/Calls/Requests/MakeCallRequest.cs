using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record MakeCallRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonPropertyName("from")]
    public required string From { get; set; }

    /// <summary>
    /// Destination PSTN number or SIP endpoint. Separate multiple destinations with
    /// the `&lt;` character to fan out a single request to up to 1000 destinations,
    /// for example `+919876543210&lt;+919876543211`.
    /// </summary>
    [JsonPropertyName("to")]
    public required string To { get; set; }

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
