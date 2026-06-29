namespace Vobiz;

public partial interface IAccountClient
{
    /// <summary>
    /// Retrieve complete account details including pricing tier and credentials.
    /// </summary>
    WithRawResponseTask<RetrieveAccountResponse> RetrieveAccountAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the current concurrent call usage and configured limits.
    /// </summary>
    WithRawResponseTask<GetConcurrencyResponse> GetConcurrencyAsync(
        GetConcurrencyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
