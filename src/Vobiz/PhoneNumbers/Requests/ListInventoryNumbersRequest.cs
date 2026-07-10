using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListInventoryNumbersRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Filter by country code (e.g., "US", "IN").
    /// </summary>
    [JsonIgnore]
    public string? Country { get; set; }

    /// <summary>
    /// Substring match against the E.164 number (e.g., "80" matches "+918065...").
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// One or more E.164 prefixes to remove from results. Include the country code (e.g. "9180" for India +91 80-series, "1415" for US +1 415); a leading "+" is optional. Matched against the full E.164 form, so it works for any country. Accepts a comma-separated list ("9180,9192") or repeated params ("exclude=9180&exclude=9192"), and the two forms can be combined. It is ANDed with all other filters, so it takes priority over `search`; duplicates are de-duplicated silently and `total` reflects the filtered result set.
    /// </summary>
    [JsonIgnore]
    public string? Exclude { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
