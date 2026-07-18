using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ChannelSubscriptionRequest
{
    /// <summary>
    /// Target account Auth ID. An account can purchase only for itself; administrators may act for another account.
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonPropertyName("resource_type")]
    public required CapacityResourceType ResourceType { get; set; }

    /// <summary>
    /// Capacity quantity to purchase. Pricing-tier block and quantity rules also apply.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
