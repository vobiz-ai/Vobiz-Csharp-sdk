using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CheckRcsReachabilityRequest
{
    /// <summary>
    /// Required. The `senderName` of your RCS sender, as returned by `GET /senders`.
    /// </summary>
    [JsonIgnore]
    public required string From { get; set; }

    /// <summary>
    /// Required. The recipient number to check, in E.164 format, for example `+14155550123`.
    /// </summary>
    [JsonIgnore]
    public required string To { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
