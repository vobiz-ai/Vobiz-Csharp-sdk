using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCdrsRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Filter by the originating phone number (caller).
    /// </summary>
    [JsonIgnore]
    public string? FromNumber { get; set; }

    /// <summary>
    /// Filter by the destination phone number (callee).
    /// </summary>
    [JsonIgnore]
    public string? ToNumber { get; set; }

    /// <summary>
    /// Beginning of the search period (YYYY-MM-DD). Required when using `end_date`.
    /// </summary>
    [JsonIgnore]
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// End of the search period (YYYY-MM-DD). Required when using `start_date`.
    /// </summary>
    [JsonIgnore]
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// Filter by direction.
    /// </summary>
    [JsonIgnore]
    public ListCdrsRequestCallDirection? CallDirection { get; set; }

    /// <summary>
    /// Minimum call duration in seconds. Excludes calls shorter than this value.
    /// </summary>
    [JsonIgnore]
    public int? MinDuration { get; set; }

    /// <summary>
    /// Page number for paginated results.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Number of records per page. Max: 100.
    /// </summary>
    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
