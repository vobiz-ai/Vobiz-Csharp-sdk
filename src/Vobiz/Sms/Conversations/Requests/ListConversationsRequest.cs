using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListConversationsRequest
{
    /// <summary>
    /// Maximum number of conversations to return, from `1` to `100`. Defaults to `20`; a value outside that range also returns `20`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of conversations to skip before the page starts, `0` or greater. Defaults to `0`. Add the page size to it to fetch the next page.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
