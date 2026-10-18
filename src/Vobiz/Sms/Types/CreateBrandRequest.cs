using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The business that will send messages. `name` and `brandType` are required; every other value is passed to the US 10DLC registry as given, so use the values the registry accepts (listed per field) and match your official records.
/// </summary>
[Serializable]
public record CreateBrandRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Your own idempotency reference, any string unique per brand on your account. Repeating a create with the same value reconciles to the same brand instead of creating a second one. Ignored on update.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Display name of the brand, usually the name customers know you by. Required.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Registered legal name of the business, exactly as it appears on tax records.
    /// </summary>
    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    /// <summary>
    /// Kind of business. Required. One of `TENDLC_PRIVATE_COMPANY` (privately held business), `TENDLC_PUBLIC_COMPANY` (publicly traded company; also goes through brand authentication), `TENDLC_NON_PROFIT` (registered non-profit), `TENDLC_GOVERNMENT` (government body) or `TOLL_FREE_NUMBER` (a business registered for toll-free messaging).
    /// </summary>
    [JsonPropertyName("brandType")]
    public required CreateBrandRequestBrandType BrandType { get; set; }

    /// <summary>
    /// Business website. It must be live, match the business and show your privacy policy.
    /// </summary>
    [JsonPropertyName("website")]
    public string? Website { get; set; }

    /// <summary>
    /// Support email address for the business, ideally on the website's domain.
    /// </summary>
    [JsonPropertyName("supportEmail")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// Support phone number for the business, in E.164 format (for example `+14155550100`).
    /// </summary>
    [JsonPropertyName("supportPhone")]
    public string? SupportPhone { get; set; }

    /// <summary>
    /// Industry of the business. Values accepted by the US 10DLC registry include `AGRICULTURE`, `COMMUNICATION`, `CONSTRUCTION`, `EDUCATION`, `ENERGY`, `ENTERTAINMENT`, `FINANCIAL`, `GAMBLING`, `GOVERNMENT`, `HEALTHCARE`, `HOSPITALITY`, `HUMAN_RESOURCES`, `INFORMATION_TECHNOLOGY_SERVICES`, `INSURANCE`, `LEGAL`, `MANUFACTURING`, `NGO`, `POLITICAL`, `POSTAL`, `PROFESSIONAL`, `REAL_ESTATE`, `RETAIL`, `TECHNOLOGY`, `TRANSPORTATION`.
    /// </summary>
    [JsonPropertyName("vertical")]
    public string? Vertical { get; set; }

    /// <summary>
    /// Tax identifier of the business, for example the 9-digit US EIN. It must match `legalName` in the issuing country's records.
    /// </summary>
    [JsonPropertyName("taxId")]
    public string? TaxId { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country that issued `taxId`, for example `US`.
    /// </summary>
    [JsonPropertyName("taxIdIssuingCountry")]
    public string? TaxIdIssuingCountry { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country where the business is registered, for example `US`.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Postal address of the business as it appears on its registration records.
    /// </summary>
    [JsonPropertyName("address")]
    public BrandAddress? Address { get; set; }

    /// <summary>
    /// Alternate business identifier (for example a DUNS or LEI record), passed to the registry as given. Send it only when the registry asks for one.
    /// </summary>
    [JsonPropertyName("alternateBusinessId")]
    public Dictionary<string, object?>? AlternateBusinessId { get; set; }

    /// <summary>
    /// First name of the person the registry can contact about the brand.
    /// </summary>
    [JsonPropertyName("businessContactFirstName")]
    public string? BusinessContactFirstName { get; set; }

    /// <summary>
    /// Last name of the person the registry can contact about the brand.
    /// </summary>
    [JsonPropertyName("businessContactLastName")]
    public string? BusinessContactLastName { get; set; }

    /// <summary>
    /// Email address of the business contact. The registry sends brand-authentication and 2FA requests for `TENDLC_PUBLIC_COMPANY` brands here.
    /// </summary>
    [JsonPropertyName("businessContactEmail")]
    public string? BusinessContactEmail { get; set; }

    /// <summary>
    /// Trading name ("doing business as") when it differs from `legalName`. Note the casing `businessDba` on brand requests.
    /// </summary>
    [JsonPropertyName("businessDba")]
    public string? BusinessDba { get; set; }

    /// <summary>
    /// Legal form of the business. Values accepted by the US 10DLC registry: `PRIVATE_COMPANY`, `PUBLIC_COMPANY`, `NON_PROFIT`, `GOVERNMENT`, `SOLE_PROPRIETOR`.
    /// </summary>
    [JsonPropertyName("legalEntityType")]
    public string? LegalEntityType { get; set; }

    /// <summary>
    /// Type of registration number for a business outside the US. Values accepted by the US 10DLC registry: `VAT`, `CBN`, `PROVINCIAL_NUMBER`, `ABN`, `SIREN`, `NZBN`, `CIF`, `CNPJ`, `OTHER`.
    /// </summary>
    [JsonPropertyName("businessRegistrationType")]
    public string? BusinessRegistrationType { get; set; }

    /// <summary>
    /// Tax-exempt status of a `TENDLC_NON_PROFIT` brand.
    /// </summary>
    [JsonPropertyName("taxExemptStatus")]
    public string? TaxExemptStatus { get; set; }

    /// <summary>
    /// Exchange where the company is listed, for example `NASDAQ` or `NYSE`. `TENDLC_PUBLIC_COMPANY` brands only.
    /// </summary>
    [JsonPropertyName("stockExchange")]
    public string? StockExchange { get; set; }

    /// <summary>
    /// Ticker symbol on `stockExchange`. `TENDLC_PUBLIC_COMPANY` brands only.
    /// </summary>
    [JsonPropertyName("stockSymbol")]
    public string? StockSymbol { get; set; }

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
