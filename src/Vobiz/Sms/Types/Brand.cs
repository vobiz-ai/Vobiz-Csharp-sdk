using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A brand on your account: the business behind your 10DLC traffic and its state at the US 10DLC registry. Optional fields are omitted when empty, and registry state is refreshed when you retrieve the brand.
/// </summary>
[Serializable]
public record Brand : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Brand ID (UUID) on your account. Use it in every `/10dlc/brands/{id}` path and as `brandId` when you create a campaign.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (`MA_...`). Always the account whose credentials made the request.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Display name you gave the brand when you created it.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Registered legal name of the business. Omitted when not set.
    /// </summary>
    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    /// <summary>
    /// Kind of business behind the brand: `TENDLC_PRIVATE_COMPANY` (privately held business), `TENDLC_PUBLIC_COMPANY` (publicly traded company; also goes through brand authentication), `TENDLC_NON_PROFIT` (registered non-profit), `TENDLC_GOVERNMENT` (government body) or `TOLL_FREE_NUMBER` (a business registered for toll-free messaging).
    /// </summary>
    [JsonPropertyName("brandType")]
    public BrandBrandType? BrandType { get; set; }

    /// <summary>
    /// Where the brand is in your workflow: `DRAFT` until you call `POST /10dlc/brands/{id}/register`, then `SUBMITTED`.
    /// </summary>
    [JsonPropertyName("stage")]
    public BrandStage? Stage { get; set; }

    /// <summary>
    /// The registrar's decision, present once the brand is submitted. `PENDING` while under review, `PENDING_2FA` while a public company's business contact completes brand authentication, `PENDING_APPEAL` while an appeal is reviewed, `ACTIVE` when approved and `REJECTED` when declined (see `rejectionReasons`).
    /// </summary>
    [JsonPropertyName("registrationStatus")]
    public BrandRegistrationStatus? RegistrationStatus { get; set; }

    /// <summary>
    /// Identity verification result from the registry, for example `VERIFIED`, `UNVERIFIED` or `VETTED_VERIFIED`. Omitted until the registry reports one.
    /// </summary>
    [JsonPropertyName("brandIdentityStatus")]
    public string? BrandIdentityStatus { get; set; }

    /// <summary>
    /// Rejections recorded by registrars, one entry per registrar. Omitted when there are none; fix the brand with `PUT /10dlc/brands/{id}` and register it again.
    /// </summary>
    [JsonPropertyName("rejectionReasons")]
    public IEnumerable<BrandRejectionReason>? RejectionReasons { get; set; }

    /// <summary>
    /// Business website as submitted to the registry. Omitted when not set.
    /// </summary>
    [JsonPropertyName("website")]
    public string? Website { get; set; }

    /// <summary>
    /// Support email address for the business. Omitted when not set.
    /// </summary>
    [JsonPropertyName("supportEmail")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// Support phone number for the business, in E.164 format. Omitted when not set.
    /// </summary>
    [JsonPropertyName("supportPhone")]
    public string? SupportPhone { get; set; }

    /// <summary>
    /// Industry vertical code as submitted to the registry, for example `TECHNOLOGY`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("vertical")]
    public string? Vertical { get; set; }

    /// <summary>
    /// Tax identifier of the business, for example a US EIN. Omitted when not set.
    /// </summary>
    [JsonPropertyName("taxId")]
    public string? TaxId { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country that issued `taxId`, for example `US`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("taxIdIssuingCountry")]
    public string? TaxIdIssuingCountry { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country where the business is registered. Omitted when not set.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Postal address of the business as submitted to the registry. Omitted when not set.
    /// </summary>
    [JsonPropertyName("address")]
    public BrandAddress? Address { get; set; }

    /// <summary>
    /// Alternate business identifier (for example a DUNS or LEI record), returned as you sent it. Omitted when not set.
    /// </summary>
    [JsonPropertyName("alternateBusinessId")]
    public Dictionary<string, object?>? AlternateBusinessId { get; set; }

    /// <summary>
    /// First name of the business contact the registry can reach. Omitted when not set.
    /// </summary>
    [JsonPropertyName("businessContactFirstName")]
    public string? BusinessContactFirstName { get; set; }

    /// <summary>
    /// Last name of the business contact the registry can reach. Omitted when not set.
    /// </summary>
    [JsonPropertyName("businessContactLastName")]
    public string? BusinessContactLastName { get; set; }

    /// <summary>
    /// Email address of the business contact; brand-authentication and 2FA requests go here. Omitted when not set.
    /// </summary>
    [JsonPropertyName("businessContactEmail")]
    public string? BusinessContactEmail { get; set; }

    /// <summary>
    /// Trading name ("doing business as") when it differs from `legalName`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("businessDba")]
    public string? BusinessDba { get; set; }

    /// <summary>
    /// Legal entity type as submitted to the registry, for example `PRIVATE_COMPANY`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("legalEntityType")]
    public string? LegalEntityType { get; set; }

    /// <summary>
    /// Type of business registration number for a business outside the US, for example `VAT`. Omitted when not set.
    /// </summary>
    [JsonPropertyName("businessRegistrationType")]
    public string? BusinessRegistrationType { get; set; }

    /// <summary>
    /// Exchange where a `TENDLC_PUBLIC_COMPANY` brand is listed. Omitted when not set.
    /// </summary>
    [JsonPropertyName("stockExchange")]
    public string? StockExchange { get; set; }

    /// <summary>
    /// Ticker symbol of a `TENDLC_PUBLIC_COMPANY` brand. Omitted when not set.
    /// </summary>
    [JsonPropertyName("stockSymbol")]
    public string? StockSymbol { get; set; }

    /// <summary>
    /// Tax-exempt status of a `TENDLC_NON_PROFIT` brand. Omitted when not set.
    /// </summary>
    [JsonPropertyName("taxExemptStatus")]
    public string? TaxExemptStatus { get; set; }

    /// <summary>
    /// When Vobiz last refreshed this record from the US 10DLC registry, in ISO 8601 (RFC 3339) UTC. Omitted until the first refresh.
    /// </summary>
    [JsonPropertyName("lastSyncedAt")]
    public DateTime? LastSyncedAt { get; set; }

    /// <summary>
    /// When the record was created on your account, in ISO 8601 (RFC 3339) UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the record last changed on your account, in ISO 8601 (RFC 3339) UTC.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

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
