using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A number you bought through Vobiz, with its price, lifecycle status and billing history.
/// </summary>
[Serializable]
public record NumberPurchase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the purchase (UUID).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Auth ID of the account that owns the purchase, for example `MA_XXXXXXXX`.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Internal routing identifier; do not rely on its value.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// The purchased number in E.164 format. Use it as the path value of `POST /numbers/{e164}/release`.
    /// </summary>
    [JsonPropertyName("e164")]
    public string? E164 { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the number's country.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Inventory type of the number in upper case, for example `VIRTUAL_LONG_NUMBER`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Upper-case capability labels for the number, for example `SMS`, `MMS` and `VOICE`.
    /// </summary>
    [JsonPropertyName("capabilities")]
    public IEnumerable<string>? Capabilities { get; set; }

    /// <summary>
    /// One-time setup fee charged at purchase, in `currency`.
    /// </summary>
    [JsonPropertyName("setupAmount")]
    public double? SetupAmount { get; set; }

    /// <summary>
    /// Monthly rental for the number, in `currency`.
    /// </summary>
    [JsonPropertyName("monthlyAmount")]
    public double? MonthlyAmount { get; set; }

    /// <summary>
    /// ISO 4217 code of the amounts, for example `USD`.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Lifecycle state: `pending` (created), `debited` (charged, purchase in progress), `purchased` (active and billing monthly), `past_due` (a renewal has been failing for more than 7 days), `failed` (did not complete), `refunded` (charge returned after a failed purchase) or `released` (you released it).
    /// </summary>
    [JsonPropertyName("status")]
    public NumberPurchaseStatus? Status { get; set; }

    /// <summary>
    /// When the number went live on your account (ISO 8601). `null` until the purchase completes.
    /// </summary>
    [JsonPropertyName("purchasedAt")]
    public DateTime? PurchasedAt { get; set; }

    /// <summary>
    /// When the next monthly rental is charged (ISO 8601). `null` before the purchase completes and after release.
    /// </summary>
    [JsonPropertyName("nextBillingAt")]
    public DateTime? NextBillingAt { get; set; }

    /// <summary>
    /// When you released the number (ISO 8601). `null` while the number is active.
    /// </summary>
    [JsonPropertyName("releasedAt")]
    public DateTime? ReleasedAt { get; set; }

    /// <summary>
    /// When the purchase was started (ISO 8601).
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the purchase last changed, for example on renewal or release (ISO 8601).
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Wallet charges raised for this number, oldest first: the initial `purchase` charge and each monthly `rental`. `null` when none have been raised.
    /// </summary>
    [JsonPropertyName("charges")]
    public IEnumerable<NumberBillingCharge>? Charges { get; set; }

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
