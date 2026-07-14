namespace Vobiz;

public partial interface IConferenceRecordingClient
{
    /// <summary>
    /// Queue recording for all audio in a conference room. The response does not include a recording ID or download URL.
    /// </summary>
    WithRawResponseTask<object> StartConferenceRecordingAsync(
        StartConferenceRecordingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop recording a conference room.
    /// </summary>
    WithRawResponseTask StopConferenceRecordingAsync(
        StopConferenceRecordingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
