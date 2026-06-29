namespace Vobiz;

public partial interface IPlayAudioClient
{
    /// <summary>
    /// Play an audio file to a live call leg.
    /// </summary>
    WithRawResponseTask CallAsync(
        PlayAudioCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop audio playing on a live call.
    /// </summary>
    WithRawResponseTask StopAudioCallAsync(
        StopAudioCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
