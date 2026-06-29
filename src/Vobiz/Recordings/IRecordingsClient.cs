namespace Vobiz;

public partial interface IRecordingsClient
{
    /// <summary>
    /// Retrieve all call recordings on the account.
    /// </summary>
    WithRawResponseTask<ListRecordingsResponse> ListRecordingsAsync(
        ListRecordingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details and download URL for a specific recording.
    /// </summary>
    WithRawResponseTask<GetRecordingResponse> GetRecordingAsync(
        GetRecordingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a recording from the account.
    /// </summary>
    WithRawResponseTask DeleteRecordingAsync(
        DeleteRecordingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
