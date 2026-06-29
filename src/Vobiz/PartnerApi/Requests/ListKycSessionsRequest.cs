using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListKycSessionsRequest
{
    [JsonIgnore]
    public ListKycSessionsRequestStatus? Status { get; set; }

    [JsonIgnore]
    public string? AccountAuthId { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public int? Size { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
