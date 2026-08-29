using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListTransactionsRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Page number, 1-indexed.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Records per page. A value above the maximum falls back to the default of 50 rather than clamping.
    /// </summary>
    [JsonIgnore]
    public int? PerPage { get; set; }

    /// <summary>
    /// Start of the window, inclusive. Date-only or full ISO 8601 timestamp. Day boundaries are UTC.
    /// </summary>
    [JsonIgnore]
    public string? FromDate { get; set; }

    /// <summary>
    /// End of the window, inclusive. A date-only value covers the whole day.
    /// </summary>
    [JsonIgnore]
    public string? ToDate { get; set; }

    /// <summary>
    /// `credit` or `debit` act as broad classifications and sweep in legacy entry types such as `did_rental`; any other value is an exact match on `transactions[].type`.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }

    /// <summary>
    /// Exact match on transaction status.
    /// </summary>
    [JsonIgnore]
    public ListTransactionsRequestStatus? Status { get; set; }

    /// <summary>
    /// Currency code. Uppercased server-side, exact match.
    /// </summary>
    [JsonIgnore]
    public string? Currency { get; set; }

    /// <summary>
    /// Spend source, matching `transactions[].reference_type`.
    /// </summary>
    [JsonIgnore]
    public string? ReferenceType { get; set; }

    /// <summary>
    /// Case-insensitive substring match on the description.
    /// </summary>
    [JsonIgnore]
    public string? Description { get; set; }

    /// <summary>
    /// Case-insensitive substring match on the reference.
    /// </summary>
    [JsonIgnore]
    public string? Reference { get; set; }

    /// <summary>
    /// Fetch a single ledger entry by its UUID.
    /// </summary>
    [JsonIgnore]
    public string? TransactionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
