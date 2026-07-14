namespace Vobiz;

public partial interface IConferenceMembersClient
{
    /// <summary>
    /// Prevent a member from speaking. Use `all` as member_id to mute everyone.
    /// </summary>
    WithRawResponseTask<object> MuteMemberAsync(
        MuteMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Allow a muted member to speak again.
    /// </summary>
    WithRawResponseTask UnmuteMemberAsync(
        UnmuteMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
