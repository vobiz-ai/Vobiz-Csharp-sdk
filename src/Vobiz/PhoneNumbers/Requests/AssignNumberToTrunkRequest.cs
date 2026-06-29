using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record AssignNumberToTrunkRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// The phone number to assign, URL-encoded (use %2B instead of +).
    /// </summary>
    [JsonIgnore]
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// The UUID of the trunk to assign this number to.
    /// </summary>
    [JsonPropertyName("trunk_group_id")]
    public required string TrunkGroupId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
