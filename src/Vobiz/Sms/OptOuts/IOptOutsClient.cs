using Vobiz;

namespace Vobiz.Sms;

public partial interface IOptOutsClient
{
    /// <summary>
    /// Returns the numbers on your opt-out list, newest first, including entries created from STOP, START and HELP keyword replies and the ones you added. Pass both `limit` and `offset` on every call: the response is a bare JSON array, and it is `null` when the page has no records (including when `limit` is missing). Page by increasing `offset` until a page returns fewer items than `limit` or `null`. To check a single number, use `GET /opt-outs/{phoneNumber}` instead.
    /// </summary>
    WithRawResponseTask<IEnumerable<OptOut>?> ListOptOutsAsync(
        ListOptOutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a phone number to your opt-out list for one channel, so Vobiz stops messages to it. After this, `POST /messages` to that number on that channel returns `422` and broadcasts skip it. An `sms` opt-out also blocks `mms`. Use it to record consent withdrawn outside a keyword reply, for example on a call or a web form. Creating the same number and channel again updates the stored `reason` instead of adding a second record.
    /// </summary>
    WithRawResponseTask<StatusOk> CreateOptOutAsync(
        CreateOptOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Tells you whether a phone number is on your opt-out list for a channel. Call it before a send to skip a blocked contact instead of handling a `422` from `POST /messages`. The response is always `200` with `optedOut` set to `true` or `false`.
    /// </summary>
    WithRawResponseTask<OptOutCheck> CheckOptOutAsync(
        CheckOptOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a phone number from your opt-out list for one channel, so you can message it again on that channel. Do this only after the contact has given consent again, for example after they reply `START`. The response is `200` whether or not a record existed, so it is safe to retry. Removing an opt-out on one channel leaves entries on other channels in place; delete each one separately.
    /// </summary>
    WithRawResponseTask<StatusOk> DeleteOptOutAsync(
        DeleteOptOutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
