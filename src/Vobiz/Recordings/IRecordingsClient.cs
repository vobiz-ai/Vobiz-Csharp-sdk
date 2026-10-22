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
    ///
    /// `recording_url` points at `media.vobiz.ai`. Download it with the same
    /// `X-Auth-ID` and `X-Auth-Token` headers you use for the API; the media
    /// host returns `401` without them. The file is WAV, although the media
    /// host may label it `Content-Type: audio/mpeg`.
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
