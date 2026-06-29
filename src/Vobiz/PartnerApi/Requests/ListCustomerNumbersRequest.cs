using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerNumbersRequest
{
    [JsonIgnore]
    public required string CustomerAuthId { get; set; }

    /// <summary>
    /// Substring match against the E.164 number.
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
