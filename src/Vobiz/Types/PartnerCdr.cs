using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Call detail record for a single voice session under a partner customer account.
/// </summary>
[Serializable]
public record PartnerCdr : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("call_uuid")]
    public string? CallUuid { get; set; }

    [JsonPropertyName("from_number")]
    public string? FromNumber { get; set; }

    [JsonPropertyName("to_number")]
    public string? ToNumber { get; set; }

    [JsonPropertyName("direction")]
    public PartnerCdrDirection? Direction { get; set; }

    [JsonPropertyName("status")]
    public PartnerCdrStatus? Status { get; set; }

    [JsonPropertyName("duration_seconds")]
    public int? DurationSeconds { get; set; }

    [JsonPropertyName("hangup_cause")]
    public string? HangupCause { get; set; }

    [JsonPropertyName("cost")]
    public float? Cost { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("start_time")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("answer_time")]
    public DateTime? AnswerTime { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("trunk_id")]
    public string? TrunkId { get; set; }

    [JsonPropertyName("context")]
    public string? Context { get; set; }

    [JsonPropertyName("account_auth_id")]
    public string? AccountAuthId { get; set; }

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
