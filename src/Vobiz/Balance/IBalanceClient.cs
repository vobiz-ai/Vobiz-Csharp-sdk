namespace Vobiz;

public partial interface IBalanceClient
{
    /// <summary>
    /// Retrieve the current account balance for a specific currency.
    /// </summary>
    WithRawResponseTask<GetBalanceResponse> GetBalanceAsync(
        GetBalanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve paginated transaction history for the account, ordered by
    /// `created_at` descending. Filter to a single day by setting `from_date`
    /// and `to_date` to the same date - a bare `YYYY-MM-DD` in `to_date` is
    /// expanded to `23:59:59`, so both bounds are inclusive. Bare dates resolve
    /// in the server timezone (UTC); send an explicit offset such as
    /// `2026-08-28T00:00:00+05:30` to pin a local calendar day.
    ///
    /// `limit` and `offset` are not supported - unknown parameters are silently
    /// dropped. `total` and `summary` are computed over the whole filtered set
    /// and ignore pagination, so `per_page=1` returns full-window totals.
    /// </summary>
    WithRawResponseTask<ListTransactionsResponse> ListTransactionsAsync(
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the distinct `reference_type` values present on the account's ledger. Use it to discover valid values for the `reference_type` filter on the transactions endpoint.
    /// </summary>
    WithRawResponseTask<ListTransactionReferenceTypesResponse> ListTransactionReferenceTypesAsync(
        ListTransactionReferenceTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
