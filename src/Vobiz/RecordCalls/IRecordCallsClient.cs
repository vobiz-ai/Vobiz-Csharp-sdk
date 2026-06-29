namespace Vobiz;

public partial interface IRecordCallsClient
{
    /// <summary>
    /// Begin recording an active call. Set format, enable transcription, and configure a callback URL.
    /// </summary>
    WithRawResponseTask<object> StartRecordingAsync(
        StartRecordingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop an active recording on an in-progress call.
    /// </summary>
    WithRawResponseTask StopRecordingAsync(
        StopRecordingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
