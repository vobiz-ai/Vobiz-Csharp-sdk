using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListBroadcastsRequest
{
    /// <summary>
    /// Maximum number of broadcasts to return, from 1 to 500. Defaults to 50 when you omit it or pass `0`. A value above 500 returns `400` with `limit must be between 1 and 500`, and a non-integer returns `400` with `limit must be an integer`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of broadcasts to skip before the page starts, for paging through results with `limit`. Defaults to `0`. A negative value returns `400` with `offset must be &gt;= 0`, and a non-integer returns `400` with `offset must be an integer`.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
