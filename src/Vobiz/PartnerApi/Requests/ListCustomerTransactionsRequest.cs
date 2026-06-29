using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListCustomerTransactionsRequest
{
    [JsonIgnore]
    public required string CustomerAuthId { get; set; }

    [JsonIgnore]
    public DateOnly? FromDate { get; set; }

    [JsonIgnore]
    public DateOnly? ToDate { get; set; }

    [JsonIgnore]
    public ListCustomerTransactionsRequestTransactionType? TransactionType { get; set; }

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
