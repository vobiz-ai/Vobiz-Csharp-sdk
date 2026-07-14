using OneOf;

namespace Vobiz;

public partial interface IConferencesClient
{
    /// <summary>
    /// Retrieve conference room names reported by the API. An empty array is inconclusive and can occur while conferences are active. Maintain your own room registry for authoritative discovery, billing, cleanup, and destructive workflows.
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
    /// Retrieve a specific conference room. A live conference can currently return a 200 response with an error payload instead of conference details.
    /// </summary>
    WithRawResponseTask<
        OneOf<GetConferenceResponseConferenceMemberCount, GetConferenceResponseError>
    > GetConferenceAsync(
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
