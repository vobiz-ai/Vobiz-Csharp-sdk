using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CancelNumberReleaseRequest
{
    /// <summary>
    /// Your account Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string AccountId { get; set; }

    /// <summary>
    /// The URL-encoded phone number in E.164 format. Encode `+` as `%2B`.
    /// </summary>
    [JsonIgnore]
    public required string E164 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
