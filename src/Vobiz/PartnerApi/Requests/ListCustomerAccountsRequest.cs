using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerAccountsRequest
{
    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <summary>
    /// Substring match on name or email.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
