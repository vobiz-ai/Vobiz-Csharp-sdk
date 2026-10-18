using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CreateCampaignRequest
{
    /// <summary>
    /// Your own idempotency reference. Repeating a create with the same value reconciles to the same campaign instead of creating a second one. Ignored on update.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Required. ID of the brand from `POST /10dlc/brands` that runs this campaign. A missing, unknown or non-UUID value returns `404` with `{"error":"brand not found"}`.
    /// </summary>
    [JsonPropertyName("brandId")]
    public required string BrandId { get; set; }

    /// <summary>
    /// Kind of campaign. Defaults to `TEN_DIGIT_LONG_CODE`, the standard 10DLC campaign. Toll-free types return `400`; use `POST /10dlc/campaigns/toll-free` for those.
    /// </summary>
    [JsonPropertyName("campaignType")]
    public CreateCampaignRequestCampaignType? CampaignType { get; set; }

    /// <summary>
    /// Name for the campaign, for your reference. Required on create and on update.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Plain-language description of the program: what you send, to whom, how often and how recipients opt in. Reviewers read this first.
    /// </summary>
    [JsonPropertyName("programSummary")]
    public string? ProgramSummary { get; set; }

    /// <summary>
    /// Message you send when a recipient opts in. Include your brand name and how to get help or opt out.
    /// </summary>
    [JsonPropertyName("confirmationMessage")]
    public string? ConfirmationMessage { get; set; }

    /// <summary>
    /// Reply you send when a recipient texts HELP. Include your brand name and a way to reach support.
    /// </summary>
    [JsonPropertyName("helpMessage")]
    public string? HelpMessage { get; set; }

    /// <summary>
    /// Reply you send when a recipient texts STOP, confirming they will receive no further messages.
    /// </summary>
    [JsonPropertyName("stopMessage")]
    public string? StopMessage { get; set; }

    /// <summary>
    /// Customer care phone number for the program, in E.164 format.
    /// </summary>
    [JsonPropertyName("customerCarePhone")]
    public string? CustomerCarePhone { get; set; }

    /// <summary>
    /// Customer care email address for the program.
    /// </summary>
    [JsonPropertyName("customerCareEmail")]
    public string? CustomerCareEmail { get; set; }

    /// <summary>
    /// Public URL of the terms and conditions that cover the program.
    /// </summary>
    [JsonPropertyName("termsAndConditionsUrl")]
    public string? TermsAndConditionsUrl { get; set; }

    /// <summary>
    /// Public URL of your privacy policy.
    /// </summary>
    [JsonPropertyName("privacyPolicyUrl")]
    public string? PrivacyPolicyUrl { get; set; }

    /// <summary>
    /// Sample messages exactly as the campaign will send them, including your brand name and opt-out language. Cover each use case you list.
    /// </summary>
    [JsonPropertyName("exampleMessages")]
    public IEnumerable<string>? ExampleMessages { get; set; }

    /// <summary>
    /// Use-case codes the campaign covers. Values accepted by the US 10DLC registry: `TWO_FACTOR_AUTH`, `ALERTS`, `FRAUD_ALERTS`, `CHAT`, `PROMOTIONAL_MARKETING`, `EDUCATION`, `DONATION`, `PUBLIC_SERVICE_ANNOUNCEMENT`, `VOTING_POLLING`, `POLITICAL`, `M2M`, `SWEEPSTAKE`.
    /// </summary>
    [JsonPropertyName("useCases")]
    public IEnumerable<string>? UseCases { get; set; }

    /// <summary>
    /// Message types the campaign sends, for example `SMS` and `MMS`.
    /// </summary>
    [JsonPropertyName("messageTypes")]
    public IEnumerable<string>? MessageTypes { get; set; }

    /// <summary>
    /// How recipients give consent, as an object keyed by opt-in channel (for example `web`, `keyword`, `paper`). Each entry describes that flow, for example `url` and `callToAction` for `web`; the object is passed to the registry as given.
    /// </summary>
    [JsonPropertyName("optIns")]
    public Dictionary<string, object?>? OptIns { get; set; }

    /// <summary>
    /// Declares the campaign as low volume to the registry. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("lowVolume")]
    public bool? LowVolume { get; set; }

    /// <summary>
    /// Set `true` when the content is restricted to adults. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("ageGated")]
    public bool? AgeGated { get; set; }

    /// <summary>
    /// Set `true` when the content relates to direct lending or loan arrangements. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("directLending")]
    public bool? DirectLending { get; set; }

    /// <summary>
    /// Set `true` when messages contain URLs. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("embeddedLink")]
    public bool? EmbeddedLink { get; set; }

    /// <summary>
    /// Set `true` when messages contain phone numbers. Defaults to `false`.
    /// </summary>
    [JsonPropertyName("embeddedPhone")]
    public bool? EmbeddedPhone { get; set; }

    /// <summary>
    /// Numbers on your account to attach to the campaign, as digits with country code and no `+` (for example `14155550100`).
    /// </summary>
    [JsonPropertyName("numbers")]
    public IEnumerable<string>? Numbers { get; set; }

    /// <summary>
    /// `documentId` values of supporting documents uploaded with `POST /10dlc/documents`. Every ID must be on your account, otherwise the request returns `400`.
    /// </summary>
    [JsonPropertyName("supportingDocuments")]
    public IEnumerable<string>? SupportingDocuments { get; set; }

    /// <summary>
    /// `documentId` values of MMS sample files uploaded with `POST /10dlc/documents`. Every ID must be on your account, otherwise the request returns `400`.
    /// </summary>
    [JsonPropertyName("mmsSampleFiles")]
    public IEnumerable<string>? MmsSampleFiles { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
