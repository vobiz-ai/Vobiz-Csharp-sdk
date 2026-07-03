using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetNumberHealthRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// The number in E.164, URL-encoded (use %2B instead of +).
    /// </summary>
    [JsonIgnore]
    public required string E164 { get; set; }

    /// <summary>
    /// Snapshot granularity.
    /// </summary>
    [JsonIgnore]
    public GetNumberHealthRequestGranularity? Granularity { get; set; }

    /// <summary>
    /// Size of the window (in days) for the summary and snapshots.
    /// </summary>
    [JsonIgnore]
    public int? Days { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
