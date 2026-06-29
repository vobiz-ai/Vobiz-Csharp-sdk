namespace Vobiz;

public partial interface IConferencesClient
{
    /// <summary>
    /// Retrieve all active conference rooms on the account.
    /// </summary>
    WithRawResponseTask<ListConferencesResponse> ListConferencesAsync(
        ListConferencesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminate all active conference rooms.
    /// </summary>
    WithRawResponseTask DeleteAllConferencesAsync(
        DeleteAllConferencesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details and member list of a specific conference room.
    /// </summary>
    WithRawResponseTask<object> GetConferenceAsync(
        GetConferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminate a specific conference room and disconnect all members.
    /// </summary>
    WithRawResponseTask DeleteConferenceAsync(
        DeleteConferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
