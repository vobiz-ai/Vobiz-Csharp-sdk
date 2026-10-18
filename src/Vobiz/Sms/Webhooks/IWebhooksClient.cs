using Vobiz;

namespace Vobiz.Sms;

public partial interface IWebhooksClient
{
    /// <summary>
    /// Returns all of your webhook subscriptions, newest first, as a bare JSON array. The body is `null` rather than `[]` when you have none, so treat `null` as an empty list. The response includes each subscription's `secret`, so keep it out of logs and client-side code.
    /// </summary>
    WithRawResponseTask<IEnumerable<WebhookSubscription>?> ListWebhooksAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Registers an HTTPS endpoint that receives the events you subscribe to as signed `POST` requests. Only `url` is required; omit `events` to subscribe to `message.received`, `message.delivered` and `message.failed`. Every delivery carries `X-Webhook-ID`, `X-Webhook-Event` and `X-Webhook-Signature`, a lower-case hex HMAC-SHA256 of the raw body keyed with your `secret`. The subscription is active as soon as it is created; see the Webhooks guide for the payload envelope and a verification example.
    /// </summary>
    WithRawResponseTask<WebhookSubscription> CreateWebhookAsync(
        CreateWebhookRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one webhook subscription with its URL, events, `active` flag and signing secret. Use it to confirm the result of an update, since `PUT /webhooks/{id}` returns only `{"status":"ok"}`.
    /// </summary>
    WithRawResponseTask<WebhookSubscription> GetWebhookAsync(
        GetWebhookRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes any subset of `url`, `secret`, `events` and `active`. Fields you omit keep their current value; a field you send, including an empty string, replaces it. Set `active` to `false` to pause deliveries without losing the subscription, and back to `true` to resume. The response is `{"status":"ok"}`, so call `GET /webhooks/{id}` to read the updated subscription.
    /// </summary>
    WithRawResponseTask<StatusOk> UpdateWebhookAsync(
        UpdateWebhookRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes the subscription and stops all deliveries to its URL. The response is `200` with `{"status":"ok"}`. To stop deliveries temporarily and keep the configuration, set `active` to `false` with `PUT /webhooks/{id}` instead.
    /// </summary>
    WithRawResponseTask<StatusOk> DeleteWebhookAsync(
        DeleteWebhookRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
