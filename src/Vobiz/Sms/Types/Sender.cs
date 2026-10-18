using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// An RCS sender (agent): the verified brand identity that recipients see instead of a phone number. Send RCS from it by passing its `senderName` as `from` with `channel: rcs`.
/// </summary>
[Serializable]
public record Sender : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the sender on Vobiz (UUID). Use it in every `/senders/{id}` path.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (`MA_...`) that owns the sender.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Internal routing identifier; do not rely on its value.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Unique technical name of the sender on the RCS platform. Pass it as `from` when you send RCS. Fixed after creation.
    /// </summary>
    [JsonPropertyName("senderName")]
    public string? SenderName { get; set; }

    /// <summary>
    /// The brand name recipients see at the top of the conversation.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Short description shown on the sender's info page.
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
    /// The region where the RCS platform hosts the sender, for example `NORTH_AMERICA`, `EUROPE` or `ASIA_PACIFIC`. Fixed after creation.
    /// </summary>
    [JsonPropertyName("hostingRegion")]
    public string? HostingRegion { get; set; }

    /// <summary>
    /// Launch status reported by the RCS platform, stored on your account. `pending` until the platform reports otherwise. Call `GET /senders/{id}/status` to refresh it.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The brand the sender represents. Omitted when not set.
    /// </summary>
    [JsonPropertyName("brand")]
    public SenderBrand? Brand { get; set; }

    /// <summary>
    /// Accent colour as a hex code. Omitted when not set.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Contact phone numbers shown on the sender's info page. Omitted when none are set.
    /// </summary>
    [JsonPropertyName("phones")]
    public IEnumerable<SenderPhone>? Phones { get; set; }

    /// <summary>
    /// Contact email addresses shown on the sender's info page. Omitted when none are set.
    /// </summary>
    [JsonPropertyName("emails")]
    public IEnumerable<SenderEmail>? Emails { get; set; }

    /// <summary>
    /// Websites shown on the sender's info page. Omitted when none are set.
    /// </summary>
    [JsonPropertyName("websites")]
    public IEnumerable<SenderWebsite>? Websites { get; set; }

    /// <summary>
    /// HTTPS URL of the banner image. Omitted when not set.
    /// </summary>
    [JsonPropertyName("bannerUrl")]
    public string? BannerUrl { get; set; }

    /// <summary>
    /// HTTPS URL of the logo image. Omitted when not set.
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
    /// Identifiers the RCS platform assigned to your agent. Omitted when not set.
    /// </summary>
    [JsonPropertyName("platform")]
    public SenderPlatform? Platform { get; set; }

    /// <summary>
    /// When the sender was created on your account (ISO 8601, UTC).
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the sender last changed, including status refreshes (ISO 8601, UTC).
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
