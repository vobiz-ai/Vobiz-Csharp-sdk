using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One wallet charge raised for a purchased number: the initial purchase charge or a monthly renewal.
/// </summary>
[Serializable]
public record NumberBillingCharge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// `id` of the purchase this charge belongs to.
    /// </summary>
    [JsonPropertyName("purchaseId")]
    public string? PurchaseId { get; set; }

    /// <summary>
    /// `purchase` for the setup fee plus the first month, charged when you buy; `rental` for each later monthly renewal.
    /// </summary>
    [JsonPropertyName("kind")]
    public NumberBillingChargeKind? Kind { get; set; }

    /// <summary>
    /// Start of the billing period this charge covers (ISO 8601).
    /// </summary>
    [JsonPropertyName("periodStart")]
    public DateTime? PeriodStart { get; set; }

    /// <summary>
    /// Amount charged, in `currency`. For `kind: purchase` this is the setup fee plus the first month.
    /// </summary>
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    /// <summary>
    /// ISO 4217 code of `amount`, for example `USD`.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// `pending` while the charge is waiting to be collected, `paid` once collected, `failed` when collection failed, `refunded` when the amount was returned to your wallet.
    /// </summary>
    [JsonPropertyName("status")]
    public NumberBillingChargeStatus? Status { get; set; }

    /// <summary>
    /// Ledger reference for the charge, as it appears in your wallet transactions. Quote it to support when reconciling.
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    /// How many times collection of this charge has been attempted. Values above `1` mean earlier attempts failed, typically for lack of balance.
    /// </summary>
    [JsonPropertyName("attempts")]
    public int? Attempts { get; set; }

    /// <summary>
    /// When collection was last attempted (ISO 8601).
    /// </summary>
    [JsonPropertyName("attemptedAt")]
    public DateTime? AttemptedAt { get; set; }

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
