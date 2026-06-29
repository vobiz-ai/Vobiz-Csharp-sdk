namespace Vobiz;

public partial interface ILiveCallsClient
{
    /// <summary>
    /// Retrieve all queued (pending, not yet connected) calls on the account.
    /// </summary>
    WithRawResponseTask<ListQueuedCallsResponse> ListQueuedCallsAsync(
        ListQueuedCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all currently active (live) calls on the account.
    /// </summary>
    WithRawResponseTask<ListLiveCallsResponse> ListLiveCallsAsync(
        ListLiveCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a specific live or queued call.
    /// </summary>
    WithRawResponseTask<GetLiveCallResponse> GetLiveCallAsync(
        GetLiveCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminate an active call by its UUID.
    /// </summary>
    WithRawResponseTask HangupCallAsync(
        HangupCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a specific queued (pending) call.
    /// </summary>
    WithRawResponseTask<GetQueuedCallResponse> GetQueuedCallAsync(
        GetQueuedCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
