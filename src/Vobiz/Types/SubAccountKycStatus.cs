using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Aggregated KYC state for a sub-account.
/// </summary>
[Serializable]
public record SubAccountKycStatus : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sub_account_id")]
    public string? SubAccountId { get; set; }

    [JsonPropertyName("kyc_mode")]
    public SubAccountKycStatusKycMode? KycMode { get; set; }

    [JsonPropertyName("business_type")]
    public string? BusinessType { get; set; }

    [JsonPropertyName("overall_status")]
    public SubAccountKycStatusOverallStatus? OverallStatus { get; set; }

    /// <summary>
    /// True while the sub-account still needs KYC before it can place calls.
    /// </summary>
    [JsonPropertyName("kyc_calls_blocked")]
    public bool? KycCallsBlocked { get; set; }

    /// <summary>
    /// Per-document state keyed by verification type.
    /// </summary>
    [JsonPropertyName("verifications")]
    public Dictionary<string, SubAccountKycStatusVerificationsValue>? Verifications { get; set; }

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
