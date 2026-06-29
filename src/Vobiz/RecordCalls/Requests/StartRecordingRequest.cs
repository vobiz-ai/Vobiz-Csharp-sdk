using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record StartRecordingRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string CallUuid { get; set; }

    [JsonPropertyName("time_limit")]
    public int? TimeLimit { get; set; }

    [JsonPropertyName("file_format")]
    public StartRecordingRequestFileFormat? FileFormat { get; set; }

    /// <summary>
    /// Set to `auto` to enable transcription
    /// </summary>
    [JsonPropertyName("transcription_type")]
    public string? TranscriptionType { get; set; }

    [JsonPropertyName("callback_url")]
    public string? CallbackUrl { get; set; }

    [JsonPropertyName("record_channel_type")]
    public StartRecordingRequestRecordChannelType? RecordChannelType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
