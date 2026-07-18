using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record PreviewChannelPricingRequest
{
    /// <summary>
    /// Target account Auth ID. An account can preview only its own pricing; administrators may act for another account.
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Capacity type to price.
    /// </summary>
    [JsonIgnore]
    public required CapacityResourceType ResourceType { get; set; }

    /// <summary>
    /// Capacity quantity to price. Pricing-tier block and quantity rules also apply.
    /// </summary>
    [JsonIgnore]
    public required int Quantity { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
