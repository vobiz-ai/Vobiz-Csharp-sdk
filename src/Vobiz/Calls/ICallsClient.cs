namespace Vobiz;

public partial interface ICallsClient
{
    /// <summary>
    /// Initiate an outbound call to a PSTN number or SIP endpoint.
    /// Use `&lt;` to separate multiple destinations (max 1000).
    /// </summary>
    WithRawResponseTask<MakeCallResponse> MakeCallAsync(
        MakeCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
