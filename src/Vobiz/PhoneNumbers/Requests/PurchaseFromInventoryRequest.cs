using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record PurchaseFromInventoryRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Phone number to purchase in E.164 format.
    /// </summary>
    [JsonPropertyName("e164")]
    public required string E164 { get; set; }

    /// <summary>
    /// Currency for transaction. Defaults to the number's currency or "USD".
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
