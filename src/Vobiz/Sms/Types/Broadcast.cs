using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A bulk SMS send that renders one template for every recipient of an uploaded list and sends at a controlled rate. Its `status` moves from `draft` through `scheduled` or `running` to `completed`, `cancelled` or `failed`, and `stats` counts recipients by state.
/// </summary>
[Serializable]
public record Broadcast : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the broadcast (UUID). Use it in every `/broadcasts/{id}` path.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (`MA_...`) that owns the broadcast.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// The label you gave the broadcast, shown in the console and in listings.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The sender every message goes out from, as stored: an E.164 number, a short code or an alphanumeric sender ID.
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>
    /// The channel the broadcast sends on. Always `sms`.
    /// </summary>
    [JsonPropertyName("channel")]
    public BroadcastChannel? Channel { get; set; }

    /// <summary>
    /// The message body with `{{variable}}` placeholders, filled per recipient from the columns of the upload. Empty until you set it.
    /// </summary>
    [JsonPropertyName("template")]
    public string? Template { get; set; }

    /// <summary>
    /// Lifecycle state. `draft` until you launch, then `scheduled` (waiting for `scheduledAt`) or `running`. `paused` after a pause call or when `pauseReason` is set; `completed` once every recipient is processed; `cancelled` after a cancel call; `failed` when the run stopped on an error.
    /// </summary>
    [JsonPropertyName("status")]
    public BroadcastStatus? Status { get; set; }

    /// <summary>
    /// Present only while the broadcast is paused for a reason other than your own pause call. `insufficient_balance` means the balance ran out; top up and call `POST /broadcasts/{id}/resume`.
    /// </summary>
    [JsonPropertyName("pauseReason")]
    public BroadcastPauseReason? PauseReason { get; set; }

    /// <summary>
    /// When sending starts after launch, in UTC (ISO 8601). `null` means sending starts as soon as you launch.
    /// </summary>
    [JsonPropertyName("scheduledAt")]
    public DateTime? ScheduledAt { get; set; }

    /// <summary>
    /// Maximum messages sent per second while running, from 1 to 50.
    /// </summary>
    [JsonPropertyName("ratePerSecond")]
    public int? RatePerSecond { get; set; }

    /// <summary>
    /// Your label, copied onto every message the broadcast sends. Empty string when not set.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// India (TRAI DLT). The Principal Entity ID copied onto every message. Empty string when not set.
    /// </summary>
    [JsonPropertyName("dltEntityId")]
    public string? DltEntityId { get; set; }

    /// <summary>
    /// India (TRAI DLT). The registered sender header ID copied onto every message. Empty string when not set.
    /// </summary>
    [JsonPropertyName("dltHeaderId")]
    public string? DltHeaderId { get; set; }

    /// <summary>
    /// India (TRAI DLT). The registered content template ID copied onto every message. Empty string when not set.
    /// </summary>
    [JsonPropertyName("dltTemplateId")]
    public string? DltTemplateId { get; set; }

    /// <summary>
    /// Column names from the latest recipient upload, as written in your file header. The first is the phone column and the rest are available as template variables. Empty until you upload recipients.
    /// </summary>
    [JsonPropertyName("columns")]
    public IEnumerable<string>? Columns { get; set; }

    /// <summary>
    /// Recipient counts by state, recounted on every read.
    /// </summary>
    [JsonPropertyName("stats")]
    public BroadcastStats? Stats { get; set; }

    /// <summary>
    /// When the broadcast was created (ISO 8601, UTC).
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the broadcast last changed, including status changes (ISO 8601, UTC).
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// When sending began (ISO 8601, UTC). `null` until the broadcast runs.
    /// </summary>
    [JsonPropertyName("startedAt")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// When the broadcast finished, either because the last recipient was processed or because it was cancelled (ISO 8601, UTC). `null` until then.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public DateTime? CompletedAt { get; set; }

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
