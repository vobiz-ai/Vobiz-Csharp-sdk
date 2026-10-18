using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ReleaseNumberRequest
{
    /// <summary>
    /// The number to release, in E.164 format, for example `+14155550100`. In raw HTTP requests, URL-encode the `+` as `%2B`; the SDKs encode it for you. A value that is not an E.164 number returns `400`, and a number that is not on your account returns `404`.
    /// </summary>
    [JsonIgnore]
    public required string E164 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
