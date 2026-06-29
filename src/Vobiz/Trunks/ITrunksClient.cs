namespace Vobiz;

public partial interface ITrunksClient
{
    /// <summary>
    /// Retrieve all SIP trunks configured on the account.
    /// </summary>
    WithRawResponseTask<ListTrunksResponse> ListTrunksAsync(
        ListTrunksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new SIP trunk for inbound or outbound calling.
    /// </summary>
    WithRawResponseTask<CreateTrunkResponse> CreateTrunkAsync(
        CreateTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details of a specific SIP trunk.
    /// </summary>
    WithRawResponseTask<RetrieveTrunkResponse> RetrieveTrunkAsync(
        RetrieveTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a SIP trunk's name, configuration, or status.
    /// </summary>
    WithRawResponseTask<UpdateTrunkResponse> UpdateTrunkAsync(
        UpdateTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a SIP trunk.
    /// </summary>
    WithRawResponseTask<string?> DeleteTrunkAsync(
        DeleteTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
