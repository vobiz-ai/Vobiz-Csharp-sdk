using Vobiz;

namespace Vobiz.Sms;

public partial interface IMessagesClient
{
    /// <summary>
    /// Returns the messages on your account, sent and received, newest first. Combine the filters to find a message you did not keep the `id` for, such as the other recipients of a multi-recipient send (filter by `tag` or `to`). Every filter is an exact match, and filters you omit are not applied. Page through results with `limit` and `offset`, and use `total` to know when to stop.
    /// </summary>
    WithRawResponseTask<MessageList> ListMessagesAsync(
        ListMessagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends an SMS, MMS or RCS message from one of your numbers or RCS senders to one or more recipients. Each number in `to` becomes its own message, with its own `id`, status and conversation, and the response body is the first recipient's message. Every recipient is checked against your opt-out list first, and a send with a future `scheduledAt` is stored with status `scheduled`.
    ///
    /// - `201` when every recipient was accepted, including an idempotent replay and a successful SMS fallback.
    /// - `202` when at least one recipient was recorded and at least one errored. Find the other recipients with `GET /messages` filtered by `tag` or `to`.
    /// - `422` when the recipient has opted out and nothing was recorded.
    /// - `502` when the send was rejected before a message was recorded. Retry with the same `idempotencyKey`.
    ///
    /// Track delivery with `GET /messages/{id}`, your webhooks (callbacks) or the WebSocket.
    /// </summary>
    WithRawResponseTask<Message> SendMessageAsync(
        SendMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Prices a message before you send it, without sending anything. It splits `text` into segments for the chosen channel and returns the segment count, the price per segment and the total in your account currency. Use it to show a cost estimate in your app or to keep long messages within a budget. The figures are for one recipient; multiply `totalCost` by the number of recipients for a multi-recipient send.
    /// </summary>
    WithRawResponseTask<CostPreview> PreviewMessageCostAsync(
        PreviewMessageCostRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Checks whether a phone number can receive RCS messages from your RCS sender, without sending anything. Call it before an RCS send to choose between RCS and SMS for that contact. If `reachable` is `false`, send with `channel: "sms"` instead, or send RCS with `failoverToSms: true` so Vobiz falls back to SMS automatically.
    /// </summary>
    WithRawResponseTask<RcsReachability> CheckRcsReachabilityAsync(
        CheckRcsReachabilityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one message with its full status history. Use it to follow a message from `sent` to `delivered` or `failed`, and to read `errorCode` and `errorMessage` when it fails. The `statusHistory` array lists every status change, oldest first. For real-time updates, subscribe to webhooks (callbacks) or the WebSocket instead of polling.
    /// </summary>
    WithRawResponseTask<MessageWithHistory> GetMessageAsync(
        GetMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
