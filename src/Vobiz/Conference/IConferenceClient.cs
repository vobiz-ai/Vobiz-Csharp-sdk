namespace Vobiz;

public partial interface IConferenceClient
{
    /// <summary>
    /// Remove a specific participant from a conference call.
    /// </summary>
    WithRawResponseTask<object> KickMemberAsync(
        KickMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disconnect a specific member from a conference.
    /// </summary>
    WithRawResponseTask HangupMemberAsync(
        HangupMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Play an audio file to a specific conference member.
    /// </summary>
    WithRawResponseTask PlayAudioMemberAsync(
        PlayAudioMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop audio playback for a specific conference member.
    /// </summary>
    WithRawResponseTask StopAudioMemberAsync(
        StopAudioMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Prevent a conference member from hearing other participants.
    /// </summary>
    WithRawResponseTask DeafMemberAsync(
        DeafMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restore a conference member's ability to hear other participants.
    /// </summary>
    WithRawResponseTask UndeafMemberAsync(
        UndeafMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
