namespace Vobiz;

public partial interface IConferenceRecordingClient
{
    /// <summary>
    /// Begin recording all audio in a conference room.
    /// </summary>
    WithRawResponseTask StartConferenceRecordingAsync(
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
