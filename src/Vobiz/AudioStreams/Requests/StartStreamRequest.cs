using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record StartStreamRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string CallUuid { get; set; }

    [JsonPropertyName("service_url")]
    public required string ServiceUrl { get; set; }

    [JsonPropertyName("bidirectional")]
    public bool? Bidirectional { get; set; }

    [JsonPropertyName("audio_track")]
    public StartStreamRequestAudioTrack? AudioTrack { get; set; }

    [JsonPropertyName("audio_format")]
    public StartStreamRequestAudioFormat? AudioFormat { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
