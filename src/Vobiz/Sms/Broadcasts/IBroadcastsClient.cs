using Vobiz;

namespace Vobiz.Sms;

public partial interface IBroadcastsClient
{
    /// <summary>
    /// Returns the broadcasts on your account, newest first, each with freshly counted `stats`. The response wraps the page in `broadcasts` and gives the account-wide count in `total`, so you can page with `limit` and `offset` until `offset` reaches `total`.
    /// </summary>
    WithRawResponseTask<BroadcastList> ListBroadcastsAsync(
        ListBroadcastsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a broadcast in `draft` status with zero `stats` and no recipients. Only `name` and `from` are required; `channel` defaults to `sms` and `ratePerSecond` to 5. Nothing is sent when you create a broadcast. Next, upload recipients with `POST /broadcasts/{id}/recipients`, check the rendered text with `GET /broadcasts/{id}/preview`, then start sending with `POST /broadcasts/{id}/launch`.
    /// </summary>
    WithRawResponseTask<Broadcast> CreateBroadcastAsync(
        BroadcastInput request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one broadcast with its configuration, current `status` and freshly counted `stats`. Poll it while a broadcast runs to follow progress, or subscribe to the `broadcast.updated` WebSocket event. For per-recipient results, use `GET /broadcasts/{id}/recipients` or `GET /broadcasts/{id}/export`.
    /// </summary>
    WithRawResponseTask<Broadcast> GetBroadcastAsync(
        GetBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes a `draft` broadcast. Send only the fields you want to change; fields you leave out, or send as `null`, keep their value, except `scheduledAt`, where `null` or `""` clears a scheduled start. The same validation as create applies, so `name` and `from` cannot be set to an empty string. A broadcast in any other status returns `409` with `cannot edit a broadcast that is &lt;status&gt;`.
    /// </summary>
    WithRawResponseTask<Broadcast> UpdateBroadcastAsync(
        UpdateBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently removes a `draft` or `cancelled` broadcast together with its recipient list and returns `204` with no body. Any other status returns `409` with `cannot delete a broadcast that is &lt;status&gt;`, so cancel a scheduled, running or paused broadcast first. Completed broadcasts are kept as your sending record.
    /// </summary>
    WithRawResponseTask DeleteBroadcastAsync(
        DeleteBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the broadcast's recipients in upload order, each with its template `variables` and per-recipient send state. Filter by `status` to find failures, opted-out numbers or rows still waiting to send. The response gives the page in `recipients` and the count matching your filter in `total`. For a downloadable file of the same data, use `GET /broadcasts/{id}/export`.
    /// </summary>
    WithRawResponseTask<BroadcastRecipientList> ListRecipientsAsync(
        ListRecipientsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the recipient list of a `draft` broadcast; each upload replaces the previous list. Send `multipart/form-data` with a `.csv` or `.xlsx` `file` (10 MB maximum) to use template variables from extra columns, or JSON with a `numbers` array for a plain list. Numbers without a country code are normalised to E.164 with `defaultCountry` (default `US`). Duplicates are dropped, invalid rows are reported in `invalid`, and numbers that opted out of SMS from you are kept with status `opted_out` and never sent. A broadcast can hold up to 10,000 recipients; a larger list returns `422`.
    /// </summary>
    WithRawResponseTask<UploadResult> UploadRecipientsAsync(
        UploadRecipientsJson request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Renders the template for the first pending recipients so you can check personalisation, encoding and segment counts before you launch. Nothing is sent and nothing is charged. `missingVariables` lists placeholders that have no matching upload column; they render as empty text, so fix the template or re-upload before launching. `estimatedSegments` totals the segments across every pending recipient, not only the samples shown.
    /// </summary>
    WithRawResponseTask<BroadcastPreview> PreviewBroadcastAsync(
        PreviewBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads every recipient with its send result as a CSV file (`text/csv`), named `broadcast-&lt;id&gt;.csv`. The columns are `row`, `to`, `status`, `message_id`, `error_code`, `error_message` and `sent_at`, followed by one column per column of your upload. Text cells that start with `=`, `+`, `-`, `@`, a tab or a carriage return are prefixed with `'` so they open safely in spreadsheet applications. You can export a broadcast in any status, including a draft, to check the parsed list.
    /// </summary>
    WithRawResponseTask<string> ExportBroadcastAsync(
        ExportBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts sending. This sends real SMS to every `pending` recipient and charges your account per segment, so call it only with your own credentials on a list you have consent to message. Only a `draft` can be launched; it moves to `running`, or to `scheduled` when `scheduledAt` is in the future. Launch returns `422` when the template is empty, when no recipient is pending, or when a phone-number `from` is not an SMS number on your account. Each recipient is sent like `POST /messages` with the broadcast's `tag` and DLT IDs and the idempotency key `broadcast:&lt;broadcastId&gt;:&lt;recipientId&gt;`, so no recipient is messaged twice.
    /// </summary>
    WithRawResponseTask<Broadcast> LaunchBroadcastAsync(
        LaunchBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Pauses a `running` broadcast. Sending stops after the messages already in flight, and pending recipients stay `pending` until you resume or cancel. Any other status returns `409` with `cannot pause a broadcast that is &lt;status&gt;`.
    /// </summary>
    WithRawResponseTask<Broadcast> PauseBroadcastAsync(
        PauseBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Continues sending to the pending recipients of a `paused` broadcast and moves it back to `running`. This sends real messages and charges your account per segment. It also resumes a broadcast paused with `pauseReason` `insufficient_balance` once you have topped up. Any other status returns `409` with `cannot resume a broadcast that is &lt;status&gt;`.
    /// </summary>
    WithRawResponseTask<Broadcast> ResumeBroadcastAsync(
        ResumeBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stops a broadcast for good and sets `completedAt`. You can cancel from `draft`, `scheduled`, `running` or `paused`; a `completed`, `failed` or already `cancelled` broadcast returns `409`. Pending recipients become `skipped`, and messages already sent are unaffected. A cancelled broadcast cannot be resumed or edited, but it can be deleted.
    /// </summary>
    WithRawResponseTask<Broadcast> CancelBroadcastAsync(
        CancelBroadcastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
