using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record UnlinkNumberFromApplicationRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// The phone number, URL-encoded (use %2B instead of +).
    /// </summary>
    [JsonIgnore]
    public required string E164 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
