namespace Vobiz;

public partial interface IAudioStreamsClient
{
    /// <summary>
    /// List all audio streams on a live call.
    /// </summary>
    WithRawResponseTask ListStreamsAsync(
        ListStreamsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Start streaming raw audio from a live call to a WebSocket URL.
    /// </summary>
    WithRawResponseTask<object> StartStreamAsync(
        StartStreamRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details of a specific audio stream.
    /// </summary>
    WithRawResponseTask GetStreamAsync(
        GetStreamRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop a specific audio stream on a live call.
    /// </summary>
    WithRawResponseTask StopStreamAsync(
        StopStreamRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
