using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListOptOutsRequest
{
    /// <summary>
    /// Required. Maximum number of opt-outs to return, `1` or greater. Without it the response is `null`.
    /// </summary>
    [JsonIgnore]
    public required int Limit { get; set; }

    /// <summary>
    /// Required. Number of records to skip before the page starts. Pass `0` for the first page, then add `limit` for each following page.
    /// </summary>
    [JsonIgnore]
    public required int Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
