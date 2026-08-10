using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record BulkExportRecordingsRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Email delivery targets for the export archive.
    /// </summary>
    [JsonPropertyName("recipient")]
    public required BulkExportRecordingsRequestRecipient Recipient { get; set; }

    /// <summary>
    /// Start date for the export. Format: YYYY-MM-DD HH:MM:SS. Defaults to 7 days ago.
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>
    /// End date for the export. Format: YYYY-MM-DD HH:MM:SS. Defaults to the current time.
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>
    /// Export recordings exactly N days old. `"7"` exports recordings from exactly 7 days ago.
    /// </summary>
    [JsonPropertyName("recording_storage_duration")]
    public string? RecordingStorageDuration { get; set; }

    /// <summary>
    /// Export recordings N days old or older. `"7"` exports recordings 7 days old and older.
    /// </summary>
    [JsonPropertyName("recording_storage_duration__gte")]
    public string? RecordingStorageDurationGte { get; set; }

    /// <summary>
    /// Export recordings older than N days. `"7"` exports recordings 8 days old and older.
    /// </summary>
    [JsonPropertyName("recording_storage_duration__gt")]
    public string? RecordingStorageDurationGt { get; set; }

    /// <summary>
    /// Export recordings N days old or newer. `"30"` exports recordings 0-30 days old.
    /// </summary>
    [JsonPropertyName("recording_storage_duration__lte")]
    public string? RecordingStorageDurationLte { get; set; }

    /// <summary>
    /// Export recordings newer than N days. `"30"` exports recordings 0-29 days old.
    /// </summary>
    [JsonPropertyName("recording_storage_duration__lt")]
    public string? RecordingStorageDurationLt { get; set; }

    /// <summary>
    /// Filter by caller phone number. Applies when the range is 30 days or less.
    /// </summary>
    [JsonPropertyName("from_number")]
    public string? FromNumber { get; set; }

    /// <summary>
    /// Filter by destination phone number. Applies when the range is 30 days or less.
    /// </summary>
    [JsonPropertyName("to_number")]
    public string? ToNumber { get; set; }

    /// <summary>
    /// Filter by call UUID. Also use this field for a conference_uuid or mpc_uuid. Applies when the range is 30 days or less.
    /// </summary>
    [JsonPropertyName("call_uuid")]
    public string? CallUuid { get; set; }

    /// <summary>
    /// Filter by conference name. Also use this field for an mpc_name. Applies when the range is 30 days or less.
    /// </summary>
    [JsonPropertyName("conference_name")]
    public string? ConferenceName { get; set; }

    /// <summary>
    /// Filter by recording format. Applies when the range is 30 days or less.
    /// </summary>
    [JsonPropertyName("recording_format")]
    public BulkExportRecordingsRequestRecordingFormat? RecordingFormat { get; set; }

    /// <summary>
    /// Filter by a specific recording ID. Applies when the range is 30 days or less.
    /// </summary>
    [JsonPropertyName("recording_id")]
    public string? RecordingId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
