namespace Vobiz;

public partial interface IOriginationUriClient
{
    /// <summary>
    /// Add an inbound SIP endpoint (origination URI) to a trunk.
    /// </summary>
    WithRawResponseTask<CreateOriginationUriResponse> CreateOriginationUriAsync(
        CreateOriginationUriRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all origination URIs on the account.
    /// </summary>
    WithRawResponseTask<ListOriginationUrisResponse> ListOriginationUrisAsync(
        ListOriginationUrisRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing origination URI.
    /// </summary>
    WithRawResponseTask<UpdateOriginationUriResponse> UpdateOriginationUriAsync(
        UpdateOriginationUriRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an origination URI from a trunk.
    /// </summary>
    WithRawResponseTask<string?> DeleteOriginationUriAsync(
        DeleteOriginationUriRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
