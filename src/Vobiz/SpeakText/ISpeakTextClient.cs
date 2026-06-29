namespace Vobiz;

public partial interface ISpeakTextClient
{
    /// <summary>
    /// Convert text to speech and play it on a live call.
    /// </summary>
    WithRawResponseTask CallAsync(
        SpeakTextCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop ongoing TTS playback on a live call.
    /// </summary>
    WithRawResponseTask StopSpeakCallAsync(
        StopSpeakCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
