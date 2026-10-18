using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record TollFreeCampaignRequest
{
    /// <summary>
    /// Your own idempotency reference. Repeating a create with the same value reconciles to the same campaign instead of creating a second one.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Name for the toll-free campaign, for your reference. Required (`400` with `invalid request: name is required` otherwise).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Public URL of your privacy policy.
    /// </summary>
    [JsonPropertyName("privacyPolicyUrl")]
    public string? PrivacyPolicyUrl { get; set; }

    /// <summary>
    /// Public URL of the terms and conditions that cover the program.
    /// </summary>
    [JsonPropertyName("termsAndConditionsUrl")]
    public string? TermsAndConditionsUrl { get; set; }

    /// <summary>
    /// Expected monthly message volume. Values accepted by the US 10DLC registry: `HUNDRED`, `TEN_THOUSAND`, `TWO_HUNDRED_FIFTY_THOUSAND`, `SEVEN_HUNDRED_FIFTY_THOUSAND`, `FIVE_MILLION`.
    /// </summary>
    [JsonPropertyName("messageVolume")]
    public string? MessageVolume { get; set; }

    /// <summary>
    /// Toll-free numbers on your account to verify, in E.164 format (for example `+18885550100`).
    /// </summary>
    [JsonPropertyName("numbers")]
    public IEnumerable<string>? Numbers { get; set; }

    /// <summary>
    /// Registry number keys of the numbers to verify, as an alternative to `numbers`.
    /// </summary>
    [JsonPropertyName("numberKeys")]
    public IEnumerable<string>? NumberKeys { get; set; }

    /// <summary>
    /// Main use case of the program. Values accepted by the US 10DLC registry: `TWO_FACTOR_AUTH`, `NOTIFICATIONS`, `SYSTEM_ALERTS`, `APP_NOTIFICATIONS`, `BANKING`, `BOOKING_CONFIRMATIONS`, `CHATBOT`, `COURIER_SERVICES_DELIVERIES`, `EMERGENCY_ALERTS`, `EVENTS_PLANNING`, `FRAUD_ALERTS`, `GENERAL_MARKETING`, `HEALTHCARE`, `INSURANCE_SERVICES`, `LEGAL_SERVICES`, `MOTIVATIONAL_REMINDERS`, `POLITICAL`, `REAL_ESTATE_SERVICES`, `RELIGIOUS_SERVICES`, `REWARDS_PROGRAM`, `WEBINAR_REMINDERS`, `AUCTIONS`, `COVID_19_ALERTS`.
    /// </summary>
    [JsonPropertyName("useCase")]
    public string? UseCase { get; set; }

    /// <summary>
    /// Plain-language description of the program: what you send, to whom, how often and how recipients opt in.
    /// </summary>
    [JsonPropertyName("programSummary")]
    public string? ProgramSummary { get; set; }

    /// <summary>
    /// A sample message exactly as you will send it, including your brand name and opt-out language.
    /// </summary>
    [JsonPropertyName("exampleMessage")]
    public string? ExampleMessage { get; set; }

    /// <summary>
    /// How recipients give consent, as an object keyed by opt-in channel (for example `web` with `url` and `callToAction`). Passed to the registry as given.
    /// </summary>
    [JsonPropertyName("optIns")]
    public Dictionary<string, object?>? OptIns { get; set; }

    /// <summary>
    /// Public URLs of screenshots or images that show the opt-in flow to the reviewer.
    /// </summary>
    [JsonPropertyName("optInImageURLs")]
    public IEnumerable<string>? OptInImageUrLs { get; set; }

    /// <summary>
    /// Anything else the reviewer should know about the program, in plain text.
    /// </summary>
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country where the business is registered.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Postal address of the business as it appears on its registration records.
    /// </summary>
    [JsonPropertyName("address")]
    public BrandAddress? Address { get; set; }

    /// <summary>
    /// Support phone number for the business, in E.164 format.
    /// </summary>
    [JsonPropertyName("supportPhone")]
    public string? SupportPhone { get; set; }

    /// <summary>
    /// Support email address for the business.
    /// </summary>
    [JsonPropertyName("supportEmail")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// First name of the person the reviewer can contact about the business.
    /// </summary>
    [JsonPropertyName("businessContactFirstName")]
    public string? BusinessContactFirstName { get; set; }

    /// <summary>
    /// Last name of the person the reviewer can contact about the business.
    /// </summary>
    [JsonPropertyName("businessContactLastName")]
    public string? BusinessContactLastName { get; set; }

    /// <summary>
    /// Registered legal name of the business, exactly as it appears on tax records.
    /// </summary>
    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    /// <summary>
    /// Trading name ("doing business as") when it differs from `legalName`. Note the casing `businessDBA` on this endpoint, unlike `businessDba` on brands.
    /// </summary>
    [JsonPropertyName("businessDBA")]
    public string? BusinessDba { get; set; }

    /// <summary>
    /// Business name customers know you by.
    /// </summary>
    [JsonPropertyName("businessName")]
    public string? BusinessName { get; set; }

    /// <summary>
    /// Business website. It must be live and match the business.
    /// </summary>
    [JsonPropertyName("businessWebsite")]
    public string? BusinessWebsite { get; set; }

    /// <summary>
    /// Customer care email address for the program.
    /// </summary>
    [JsonPropertyName("customerCareEmail")]
    public string? CustomerCareEmail { get; set; }

    /// <summary>
    /// Tax identifier of the business, for example the US EIN.
    /// </summary>
    [JsonPropertyName("taxId")]
    public string? TaxId { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country that issued `taxId`.
    /// </summary>
    [JsonPropertyName("taxIdIssuingCountry")]
    public string? TaxIdIssuingCountry { get; set; }

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
    /// Campaign Verify token for a US political program. Omit it for every other program.
    /// </summary>
    [JsonPropertyName("campaignVerifyToken")]
    public string? CampaignVerifyToken { get; set; }

    /// <summary>
    /// ID (UUID) of a priority option from `GET /10dlc/campaigns/priorities`. A value that is not a UUID returns `400`; omit it when the list is empty.
    /// </summary>
    [JsonPropertyName("priorityId")]
    public string? PriorityId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
