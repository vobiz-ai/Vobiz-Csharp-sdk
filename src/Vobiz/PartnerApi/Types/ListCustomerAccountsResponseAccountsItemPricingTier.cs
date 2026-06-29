using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerAccountsResponseAccountsItemPricingTier : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("rate_per_minute")]
    public required double RatePerMinute { get; set; }

    [JsonPropertyName("streaming_rate_per_minute")]
    public required double StreamingRatePerMinute { get; set; }

    [JsonPropertyName("recording_rate_per_minute")]
    public required double RecordingRatePerMinute { get; set; }

    [JsonPropertyName("whatsapp_voice_rate")]
    public required double WhatsappVoiceRate { get; set; }

    [JsonPropertyName("transcription_rate_per_minute")]
    public required double TranscriptionRatePerMinute { get; set; }

    [JsonPropertyName("pii_redaction_rate_per_minute")]
    public required double PiiRedactionRatePerMinute { get; set; }

    [JsonPropertyName("charge_non_connected_calls")]
    public required bool ChargeNonConnectedCalls { get; set; }

    [JsonPropertyName("non_connected_call_fee")]
    public required double NonConnectedCallFee { get; set; }

    [JsonPropertyName("did_release_fee")]
    public required int DidReleaseFee { get; set; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("is_default")]
    public required bool IsDefault { get; set; }

    [JsonPropertyName("partner_id")]
    public object? PartnerId { get; set; }

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
