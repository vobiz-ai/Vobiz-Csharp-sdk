using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// The result of a successful purchase: the billing record and the routing record.
/// </summary>
[Serializable]
public record PurchaseNumberResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The purchase record, with `status: purchased`, the amounts charged and `nextBillingAt`.
    /// </summary>
    [JsonPropertyName("purchase")]
    public NumberPurchase? Purchase { get; set; }

    /// <summary>
    /// The routing record that connects the number to your account. The number appears in `GET /numbers` from this point.
    /// </summary>
    [JsonPropertyName("number")]
    public NumberRouting? Number { get; set; }

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
