using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetCdrResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("account_id")]
    public required string AccountId { get; set; }

    [JsonPropertyName("answer_time")]
    public required string AnswerTime { get; set; }

    [JsonPropertyName("billsec")]
    public required int Billsec { get; set; }

    [JsonPropertyName("bridge_uuid")]
    public required string BridgeUuid { get; set; }

    [JsonPropertyName("call_direction")]
    public required string CallDirection { get; set; }

    [JsonPropertyName("caller_id_name")]
    public required string CallerIdName { get; set; }

    [JsonPropertyName("caller_id_number")]
    public required string CallerIdNumber { get; set; }

    [JsonPropertyName("campaign_id")]
    public object? CampaignId { get; set; }

    [JsonPropertyName("carrier_ip")]
    public object? CarrierIp { get; set; }

    [JsonPropertyName("codec")]
    public required string Codec { get; set; }

    [JsonPropertyName("context")]
    public required string Context { get; set; }

    [JsonPropertyName("cost")]
    public required double Cost { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("customer_endpoint")]
    public object? CustomerEndpoint { get; set; }

    [JsonPropertyName("destination_number")]
    public required string DestinationNumber { get; set; }

    [JsonPropertyName("duration")]
    public required int Duration { get; set; }

    [JsonPropertyName("end_time")]
    public required string EndTime { get; set; }

    [JsonPropertyName("failure_code")]
    public object? FailureCode { get; set; }

    [JsonPropertyName("failure_reason")]
    public object? FailureReason { get; set; }

    [JsonPropertyName("hangup_cause")]
    public required string HangupCause { get; set; }

    [JsonPropertyName("hangup_cause_code")]
    public required int HangupCauseCode { get; set; }

    [JsonPropertyName("hangup_cause_name")]
    public required string HangupCauseName { get; set; }

    [JsonPropertyName("hangup_disposition")]
    public required string HangupDisposition { get; set; }

    [JsonPropertyName("hangup_source")]
    public required string HangupSource { get; set; }

    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("jitter")]
    public required double Jitter { get; set; }

    [JsonPropertyName("mos")]
    public required double Mos { get; set; }

    [JsonPropertyName("network_addr")]
    public required string NetworkAddr { get; set; }

    [JsonPropertyName("origination_region")]
    public required string OriginationRegion { get; set; }

    [JsonPropertyName("packet_loss")]
    public required int PacketLoss { get; set; }

    [JsonPropertyName("progress_time")]
    public required string ProgressTime { get; set; }

    [JsonPropertyName("region")]
    public required string Region { get; set; }

    [JsonPropertyName("ring_time")]
    public required int RingTime { get; set; }

    [JsonPropertyName("sip_call_id")]
    public required string SipCallId { get; set; }

    [JsonPropertyName("sip_user_agent")]
    public required string SipUserAgent { get; set; }

    [JsonPropertyName("start_time")]
    public required string StartTime { get; set; }

    [JsonPropertyName("streaming_cost")]
    public required int StreamingCost { get; set; }

    [JsonPropertyName("terminated_to")]
    public object? TerminatedTo { get; set; }

    [JsonPropertyName("total_cost")]
    public required double TotalCost { get; set; }

    [JsonPropertyName("trunk_id")]
    public object? TrunkId { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

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
