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

    /// <summary>
    /// Calculate the monthly price for CPS or concurrent-call capacity without purchasing capacity or debiting the account.
    /// </summary>
    WithRawResponseTask<ChannelPricingPreview> PreviewChannelPricingAsync(
        PreviewChannelPricingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Purchase recurring CPS or concurrent-call capacity. A successful request immediately debits the first monthly charge and activates a subscription that renews every 30 days.
    /// </summary>
    WithRawResponseTask<ChannelSubscription> CreateChannelSubscriptionAsync(
        ChannelSubscriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
