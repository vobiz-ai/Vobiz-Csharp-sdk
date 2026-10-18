using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The brand's state at one registrar, read live from the US 10DLC registry.
/// </summary>
[Serializable]
public record BrandRegistrarStatus : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Registrar that reviewed the brand.
    /// </summary>
    [JsonPropertyName("registrar")]
    public string? Registrar { get; set; }

    /// <summary>
    /// The brand's registration state at this registrar, for example `ACTIVE`, `PENDING` or `REJECTED`.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Identity verification result from this registrar, for example `VERIFIED`. Present only when the registrar reports one.
    /// </summary>
    [JsonPropertyName("brandIdentityStatus")]
    public string? BrandIdentityStatus { get; set; }

    /// <summary>
    /// Brand-authentication (2FA) status for `TENDLC_PUBLIC_COMPANY` brands. Present only when the registrar reports one.
    /// </summary>
    [JsonPropertyName("brandAuthenticationStatus")]
    public string? BrandAuthenticationStatus { get; set; }

    /// <summary>
    /// Why the registrar rejected the brand. Present only when `state` is a rejection.
    /// </summary>
    [JsonPropertyName("rejectionReason")]
    public string? RejectionReason { get; set; }

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
