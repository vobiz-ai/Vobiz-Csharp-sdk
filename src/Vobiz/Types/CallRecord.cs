using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CallRecord : IJsonOnDeserialized
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

    [JsonPropertyName("call_status")]
    public CallRecordCallStatus? CallStatus { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("bill_duration")]
    public int? BillDuration { get; set; }

    [JsonPropertyName("billed_amount")]
    public string? BilledAmount { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

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
