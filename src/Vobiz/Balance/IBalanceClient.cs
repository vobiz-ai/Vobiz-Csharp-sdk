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
    /// Retrieve paginated transaction history for the account.
    /// </summary>
    WithRawResponseTask<ListTransactionsResponse> ListTransactionsAsync(
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
