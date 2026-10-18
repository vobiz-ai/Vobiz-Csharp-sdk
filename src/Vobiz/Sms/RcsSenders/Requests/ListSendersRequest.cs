using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListSendersRequest
{
    /// <summary>
    /// Maximum number of items to return, from 1 to 100. Defaults to 20; a value outside that range or a non-integer is replaced by the default.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Number of items to skip before the page starts. Defaults to `0`. Pass a whole number of 0 or more.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
