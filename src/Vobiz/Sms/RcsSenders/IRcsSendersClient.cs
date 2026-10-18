using Vobiz;

namespace Vobiz.Sms;

public partial interface IRcsSendersClient
{
    /// <summary>
    /// Returns the RCS senders on your account as a bare JSON array, without a total count. Page through them with `limit` and `offset`; an empty array means you have reached the end. `status` here is the last stored value, so call `GET /senders/{id}/status` for the latest state.
    /// </summary>
    WithRawResponseTask<IEnumerable<Sender>> ListSendersAsync(
        ListSendersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Registers a new RCS sender (agent) with the RCS platform and stores it on your account with status `pending`. `provider` and `senderName` are required; the profile fields are reviewed by the RCS platform and the carriers before the sender can reach real users. Poll `GET /senders/{id}/status` until the platform reports it as launched, then send with its `senderName` as `from` and `channel: rcs` on `POST /messages`. A rejected request returns `400` with the platform's reason in `error`.
    /// </summary>
    WithRawResponseTask<Sender> CreateSenderAsync(
        CreateSenderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one RCS sender as stored on your account, including its full profile. `status` is the last value stored on your account; call `GET /senders/{id}/status` to refresh it from the RCS platform. An unknown id returns `404`.
    /// </summary>
    WithRawResponseTask<Sender> GetSenderAsync(
        GetSenderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the sender's profile on the RCS platform and then on your account, and returns the updated sender. Send only the fields you want to change; fields you leave out keep their value. `provider`, `senderName` and `hostingRegion` are fixed after creation. Every failure, including an unknown id, returns `400`.
    /// </summary>
    WithRawResponseTask<Sender> UpdateSenderAsync(
        UpdateSenderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Asks the RCS platform for the sender's current launch status, stores it on the sender and returns the full sender. Poll it after `POST /senders` or a profile update until `status` shows the sender is live, then start sending. Every failure, including an unknown id, returns `400`.
    /// </summary>
    WithRawResponseTask<Sender> GetSenderStatusAsync(
        GetSenderStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the templates registered on one RCS sender as a bare JSON array, without a total count. Page through them with `limit` and `offset`. `status` is the last stored value; refresh one template with its `/status` endpoint.
    /// </summary>
    WithRawResponseTask<IEnumerable<Template>> ListTemplatesAsync(
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Registers a message template on an RCS sender with the RCS platform and returns it with status `pending`. `templateName`, `type` and `content` are passed to the platform unchanged, so use the template types and content shapes the RCS platform defines. Call `GET /senders/{senderId}/templates/{templateName}/status` to follow approval. An unknown sender or a platform rejection returns `400`.
    /// </summary>
    WithRawResponseTask<Template> CreateTemplateAsync(
        CreateTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one template as stored on your account, including the `content` you submitted. For the latest approval state from the RCS platform, call `GET /senders/{senderId}/templates/{templateName}/status`. An unknown sender or template returns `404`.
    /// </summary>
    WithRawResponseTask<Template> GetTemplateAsync(
        GetTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes the template from the RCS platform and from your account, and returns `204` with no body. You cannot send with the template afterwards. An unknown sender or template returns `400`.
    /// </summary>
    WithRawResponseTask DeleteTemplateAsync(
        DeleteTemplateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Asks the RCS platform for the template's current approval status, stores it on the template and returns the full template. Poll it after `POST /senders/{senderId}/templates` until the template is approved. Every failure, including an unknown sender or template, returns `400`.
    /// </summary>
    WithRawResponseTask<Template> GetTemplateStatusAsync(
        GetTemplateStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
