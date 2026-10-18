using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CheckOptOutRequest
{
    /// <summary>
    /// The number in E.164 format, for example `+14155550123`. In raw HTTP requests, URL-encode the `+` as `%2B` (`/opt-outs/%2B14155550123`); the SDKs encode it for you.
    /// </summary>
    [JsonIgnore]
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Channel to check: `sms`, `mms` or `rcs`. Defaults to `sms`.
    /// </summary>
    [JsonIgnore]
    public string? Channel { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
