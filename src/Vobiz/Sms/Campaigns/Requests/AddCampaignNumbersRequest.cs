using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record AddCampaignNumbersRequest
{
    /// <summary>
    /// Campaign ID (UUID) returned by `POST /10dlc/campaigns` or `POST /10dlc/campaigns/toll-free`. An unknown ID, an ID from another account, or a value that is not a UUID returns `404` with `{"error":"campaign not found"}`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    [JsonIgnore]
    public required CampaignNumbersRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
