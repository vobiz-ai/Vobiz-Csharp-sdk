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
