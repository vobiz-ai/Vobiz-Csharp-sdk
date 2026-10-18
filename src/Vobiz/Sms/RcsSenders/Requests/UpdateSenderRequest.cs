using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record UpdateSenderRequest
{
    /// <summary>
    /// The sender's `id` (UUID), as returned by `POST /senders` or `GET /senders`. An unknown id returns `sender not found`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

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
    /// How the RCS platform bills conversations from this sender, for example `CONVERSATIONAL` or `NON_CONVERSATIONAL`.
    /// </summary>
    [JsonPropertyName("billingCategory")]
    public string? BillingCategory { get; set; }

    /// <summary>
    /// The kind of traffic the sender carries, for example `OTP`, `TRANSACTIONAL`, `PROMOTIONAL` or `MULTI_USE`.
    /// </summary>
    [JsonPropertyName("useCase")]
    public string? UseCase { get; set; }

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
    /// Contact phone numbers shown on the sender's info page.
    /// </summary>
    [JsonPropertyName("phones")]
    public IEnumerable<SenderPhone>? Phones { get; set; }

    /// <summary>
    /// Contact email addresses shown on the sender's info page.
    /// </summary>
    [JsonPropertyName("emails")]
    public IEnumerable<SenderEmail>? Emails { get; set; }

    /// <summary>
    /// Websites shown on the sender's info page.
    /// </summary>
    [JsonPropertyName("websites")]
    public IEnumerable<SenderWebsite>? Websites { get; set; }

    /// <summary>
    /// Publicly reachable HTTPS URL of the banner image.
    /// </summary>
    [JsonPropertyName("bannerUrl")]
    public string? BannerUrl { get; set; }

    /// <summary>
    /// Publicly reachable HTTPS URL of the logo image.
    /// </summary>
    [JsonPropertyName("logoUrl")]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Link to your privacy policy.
    /// </summary>
    [JsonPropertyName("privacy")]
    public SenderLink? Privacy { get; set; }

    /// <summary>
    /// Link to your terms of service.
    /// </summary>
    [JsonPropertyName("termsOfService")]
    public SenderLink? TermsOfService { get; set; }

    /// <summary>
    /// Identifiers the RCS platform has assigned to your agent.
    /// </summary>
    [JsonPropertyName("platform")]
    public SenderPlatform? Platform { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
