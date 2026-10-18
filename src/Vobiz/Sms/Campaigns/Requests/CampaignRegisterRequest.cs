using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CampaignRegisterRequest
{
    /// <summary>
    /// Campaign ID (UUID) returned by `POST /10dlc/campaigns` or `POST /10dlc/campaigns/toll-free`. An unknown ID, an ID from another account, or a value that is not a UUID returns `404` with `{"error":"campaign not found"}`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// ID (UUID) of a priority option from `GET /10dlc/campaigns/priorities`, for toll-free campaigns. A value that is not a UUID returns `400` with `invalid request: priorityId must be a UUID`.
    /// </summary>
    [JsonPropertyName("priorityId")]
    public string? PriorityId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
