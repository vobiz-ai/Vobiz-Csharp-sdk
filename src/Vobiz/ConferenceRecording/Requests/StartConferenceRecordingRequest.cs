using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record StartConferenceRecordingRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string ConferenceName { get; set; }

    [JsonPropertyName("file_format")]
    public StartConferenceRecordingRequestFileFormat? FileFormat { get; set; }

    [JsonPropertyName("callback_url")]
    public string? CallbackUrl { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
