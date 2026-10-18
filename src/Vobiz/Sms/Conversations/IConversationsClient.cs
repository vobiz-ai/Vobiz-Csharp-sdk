using Vobiz;

namespace Vobiz.Sms;

public partial interface IConversationsClient
{
    /// <summary>
    /// Returns your conversations, most recently active first (ordered by `lastMessageAt`). A conversation is the thread between one of your numbers and one contact on one channel, and Vobiz creates it with the first message in either direction. The response is a bare JSON array, `[]` when you have none. Page with `limit` and `offset`; when a page returns fewer items than `limit`, you have reached the end.
    /// </summary>
    WithRawResponseTask<IEnumerable<Conversation>> ListConversationsAsync(
        ListConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the total of `unreadCount` across all your conversations. Use it for an inbox badge, then call `GET /conversations` to see which threads are unread. The total drops when you mark a conversation read with `POST /conversations/{id}/read`.
    /// </summary>
    WithRawResponseTask<UnreadCount> UnreadCountAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one conversation with its participants, channel and counters. Use it to refresh a thread's `unreadCount` or `lastMessageAt` after a new message arrives. To read the messages themselves, call `GET /conversations/{id}/messages`.
    /// </summary>
    WithRawResponseTask<Conversation> GetConversationAsync(
        GetConversationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the messages in one conversation, in both directions, newest first. Use it to render a chat thread: reverse the page to show it oldest to newest. The response is a bare JSON array of message objects without `statusHistory`; call `GET /messages/{id}` for one message's history. Page with `limit` and `offset`.
    /// </summary>
    WithRawResponseTask<IEnumerable<Message>> ListConversationMessagesAsync(
        ListConversationMessagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Marks a conversation as read: it sets `unreadCount` to `0` and `lastReadAt` to the current time. Call it when a user opens the thread in your inbox. It takes no request body, and calling it on a thread that is already read is harmless. The account-wide total from `GET /conversations/unread-count` drops by the thread's previous `unreadCount`.
    /// </summary>
    WithRawResponseTask<StatusOk> MarkConversationReadAsync(
        MarkConversationReadRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
