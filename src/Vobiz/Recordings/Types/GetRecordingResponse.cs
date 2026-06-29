using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetRecordingResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("add_time")]
    public required string AddTime { get; set; }

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    [JsonPropertyName("call_uuid")]
    public required string CallUuid { get; set; }

    [JsonPropertyName("conference_name")]
    public object? ConferenceName { get; set; }

    [JsonPropertyName("from_number")]
    public required string FromNumber { get; set; }

    [JsonPropertyName("monthly_recording_storage_amount")]
    public required int MonthlyRecordingStorageAmount { get; set; }

    [JsonPropertyName("recording_duration_ms")]
    public required string RecordingDurationMs { get; set; }

    [JsonPropertyName("recording_end_ms")]
    public object? RecordingEndMs { get; set; }

    [JsonPropertyName("recording_format")]
    public required string RecordingFormat { get; set; }

    [JsonPropertyName("recording_id")]
    public required string RecordingId { get; set; }

    [JsonPropertyName("recording_start_ms")]
    public object? RecordingStartMs { get; set; }

    [JsonPropertyName("recording_storage_duration")]
    public required int RecordingStorageDuration { get; set; }

    [JsonPropertyName("recording_storage_rate")]
    public required double RecordingStorageRate { get; set; }

    [JsonPropertyName("recording_type")]
    public required string RecordingType { get; set; }

    [JsonPropertyName("recording_url")]
    public required string RecordingUrl { get; set; }

    [JsonPropertyName("resource_uri")]
    public required string ResourceUri { get; set; }

    [JsonPropertyName("rounded_recording_duration")]
    public required int RoundedRecordingDuration { get; set; }

    [JsonPropertyName("to_number")]
    public required string ToNumber { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
