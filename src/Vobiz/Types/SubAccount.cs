using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record SubAccount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("auth_id")]
    public string? AuthId { get; set; }

    [JsonPropertyName("auth_token")]
    public string? AuthToken { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Verification mode. `customer_use` sub-accounts must complete their own KYC before placing calls.
    /// </summary>
    [JsonPropertyName("kyc_mode")]
    public SubAccountKycMode? KycMode { get; set; }

    /// <summary>
    /// Legal constitution of the customer (e.g. `private_limited`).
    /// </summary>
    [JsonPropertyName("business_type")]
    public string? BusinessType { get; set; }

    /// <summary>
    /// True while a `customer_use` sub-account has not yet completed the KYC required to place calls.
    /// </summary>
    [JsonPropertyName("kyc_calls_blocked")]
    public bool? KycCallsBlocked { get; set; }

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
