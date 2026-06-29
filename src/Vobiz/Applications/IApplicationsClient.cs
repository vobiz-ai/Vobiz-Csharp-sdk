namespace Vobiz;

public partial interface IApplicationsClient
{
    /// <summary>
    /// Get details of all applications created under your Vobiz account.
    /// </summary>
    WithRawResponseTask<ListApplicationsResponse> ListApplicationsAsync(
        ListApplicationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates an Application with webhook URLs for call handling.
    /// Creating an application is usually a first step, after which you
    /// attach the application to either a number or an endpoint.
    /// </summary>
    WithRawResponseTask<CreateApplicationResponse> CreateApplicationAsync(
        CreateApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details of a particular application by passing the app_id.
    /// </summary>
    WithRawResponseTask<RetrieveApplicationResponse> RetrieveApplicationAsync(
        RetrieveApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify an application using this API. You can update any subset of
    /// fields (partial update). Fields not provided will remain unchanged.
    /// </summary>
    WithRawResponseTask<UpdateApplicationResponse> UpdateApplicationAsync(
        UpdateApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete an Application. If the application is associated
    /// with phone numbers, the deletion may be blocked unless those
    /// associations are removed first.
    /// </summary>
    WithRawResponseTask<string?> DeleteApplicationAsync(
        DeleteApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
