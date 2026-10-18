using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListBrandVetsRequest
{
    /// <summary>
    /// Brand ID (UUID) returned by `POST /10dlc/brands`. An unknown ID, an ID from another account, or a value that is not a UUID returns `404` with `{"error":"brand not found"}`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// Zero-based page index. Defaults to `0`. Must be 0 or more; a negative value returns `400`. A value that is not an integer is treated as `0`.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Records per page, from 0 to 100. Defaults to `20`; `0` or a value that is not an integer also gives the default page size. A value above 100 returns `400`.
    /// </summary>
    [JsonIgnore]
    public int? Size { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
