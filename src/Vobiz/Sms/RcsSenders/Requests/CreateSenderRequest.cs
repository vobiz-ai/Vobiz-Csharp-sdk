using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CreateSenderRequest
{
    /// <summary>
    /// The routing identifier your account was provisioned with for RCS. Contact support if you are unsure which value to use; an unknown value returns `400`.
    /// </summary>
    [JsonPropertyName("provider")]
    public required string Provider { get; set; }

    /// <summary>
    /// Unique technical name of the sender on the RCS platform. You pass it as `from` when you send RCS, and it cannot be changed later.
    /// </summary>
    [JsonPropertyName("senderName")]
    public required string SenderName { get; set; }

    /// <summary>
    /// The brand name recipients see at the top of the conversation.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Short description of your business or the sender's purpose, shown on the sender's info page.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// How the RCS platform bills conversations from this sender. Values accepted by the platform include `CONVERSATIONAL` and `NON_CONVERSATIONAL`.
    /// </summary>
    [JsonPropertyName("billingCategory")]
    public string? BillingCategory { get; set; }

    /// <summary>
    /// The kind of traffic the sender carries, reviewed by the RCS platform. Values accepted by the platform include `OTP`, `TRANSACTIONAL`, `PROMOTIONAL` and `MULTI_USE`.
    /// </summary>
    [JsonPropertyName("useCase")]
    public string? UseCase { get; set; }

    /// <summary>
    /// The region where the RCS platform hosts the sender. Values accepted by the platform include `NORTH_AMERICA`, `EUROPE` and `ASIA_PACIFIC`. Cannot be changed later.
    /// </summary>
    [JsonPropertyName("hostingRegion")]
    public string? HostingRegion { get; set; }

    /// <summary>
    /// The brand the sender represents.
    /// </summary>
    [JsonPropertyName("brand")]
    public SenderBrand? Brand { get; set; }

    /// <summary>
    /// Accent colour for the sender's buttons and header, as a hex code such as `#1A73E8`.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Contact phone numbers shown on the sender's info page, each with a label.
    /// </summary>
    [JsonPropertyName("phones")]
    public IEnumerable<SenderPhone>? Phones { get; set; }

    /// <summary>
    /// Contact email addresses shown on the sender's info page, each with a label.
    /// </summary>
    [JsonPropertyName("emails")]
    public IEnumerable<SenderEmail>? Emails { get; set; }

    /// <summary>
    /// Websites shown on the sender's info page, each with a label.
    /// </summary>
    [JsonPropertyName("websites")]
    public IEnumerable<SenderWebsite>? Websites { get; set; }

    /// <summary>
    /// Publicly reachable HTTPS URL of the banner image shown at the top of the sender's info page.
    /// </summary>
    [JsonPropertyName("bannerUrl")]
    public string? BannerUrl { get; set; }

    /// <summary>
    /// Publicly reachable HTTPS URL of the logo shown next to every message.
    /// </summary>
    [JsonPropertyName("logoUrl")]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Link to your privacy policy, shown on the sender's info page.
    /// </summary>
    [JsonPropertyName("privacy")]
    public SenderLink? Privacy { get; set; }

    /// <summary>
    /// Link to your terms of service, shown on the sender's info page.
    /// </summary>
    [JsonPropertyName("termsOfService")]
    public SenderLink? TermsOfService { get; set; }

    /// <summary>
    /// Identifiers the RCS platform has already assigned to your agent, if you have any.
    /// </summary>
    [JsonPropertyName("platform")]
    public SenderPlatform? Platform { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
