using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Outcome of a single KYC verification step.
/// </summary>
[Serializable]
public record KycVerificationResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("verification_type")]
    public required KycVerificationResultVerificationType VerificationType { get; set; }

    [JsonPropertyName("status")]
    public required KycVerificationResultStatus Status { get; set; }

    /// <summary>
    /// Recomputed sub-account call-blocking state after this verification.
    /// </summary>
    [JsonPropertyName("kyc_calls_blocked")]
    public bool? KycCallsBlocked { get; set; }

    /// <summary>
    /// Present and `true` on responses from the test-mode endpoints.
    /// </summary>
    [JsonPropertyName("mock")]
    public bool? Mock { get; set; }

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
