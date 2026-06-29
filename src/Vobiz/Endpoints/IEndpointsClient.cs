namespace Vobiz;

public partial interface IEndpointsClient
{
    /// <summary>
    /// Retrieve a paginated list of all SIP endpoints in your account.
    /// </summary>
    WithRawResponseTask<ListEndpointsResponse> ListEndpointsAsync(
        ListEndpointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new SIP endpoint that can be used to make and receive calls
    /// through IP phones, softphones, or SIP clients. Each endpoint is
    /// assigned a unique SIP URI and endpoint ID.
    /// </summary>
    WithRawResponseTask<CreateEndpointResponse> CreateEndpointAsync(
        CreateEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the details of an existing endpoint. The response includes
    /// all endpoint attributes and, if the endpoint is currently registered
    /// on a SIP client, additional registration details.
    /// </summary>
    WithRawResponseTask<RetrieveEndpointResponse> RetrieveEndpointAsync(
        RetrieveEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing endpoint's configuration. You can change the
    /// password, alias, or attached application. The fields `username`,
    /// `endpoint_id`, `domain`, `allow_same_domain`, `allow_other_domains`,
    /// `allow_phones`, and `allow_apps` are locked after creation.
    /// </summary>
    WithRawResponseTask<string> UpdateEndpointAsync(
        UpdateEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete an endpoint from your Vobiz account. Once deleted,
    /// the SIP URI will no longer be accessible, and any devices registered
    /// with this endpoint will be disconnected.
    /// </summary>
    WithRawResponseTask<string?> DeleteEndpointAsync(
        DeleteEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
