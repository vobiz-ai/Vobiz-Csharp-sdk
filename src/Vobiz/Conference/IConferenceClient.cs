namespace Vobiz;

public partial interface IConferenceClient
{
    /// <summary>
    /// Remove one or more participants from a conference while allowing their XML flow to continue.
    /// </summary>
    WithRawResponseTask<object> KickMemberAsync(
        KickMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Terminate one or more active conference member calls. A normal active-member request disconnects the member. If a member was kicked, continued its XML flow, and rejoined with the same numeric member ID, confirm removal through conference exit or call hangup callbacks.
    /// </summary>
    WithRawResponseTask HangupMemberAsync(
        HangupMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Play an audio file to a specific conference member.
    /// </summary>
    WithRawResponseTask<object> PlayAudioMemberAsync(
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
    WithRawResponseTask<object> DeafMemberAsync(
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
