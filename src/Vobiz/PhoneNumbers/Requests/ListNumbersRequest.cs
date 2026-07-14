using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListNumbersRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Page number, starting at 1
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Number of phone numbers to return per page
    /// </summary>
    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <summary>
    /// Filter by phone number. Include the country code and URL-encode a leading plus sign.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
