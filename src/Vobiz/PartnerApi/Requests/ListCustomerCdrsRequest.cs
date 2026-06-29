using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerCdrsRequest
{
    [JsonIgnore]
    public required string CustomerAuthId { get; set; }

    [JsonIgnore]
    public DateOnly? StartDate { get; set; }

    [JsonIgnore]
    public DateOnly? EndDate { get; set; }

    [JsonIgnore]
    public ListCustomerCdrsRequestCallDirection? CallDirection { get; set; }

    [JsonIgnore]
    public ListCustomerCdrsRequestStatus? Status { get; set; }

    [JsonIgnore]
    public int? MinDuration { get; set; }

    [JsonIgnore]
    public string? HangupCause { get; set; }

    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
