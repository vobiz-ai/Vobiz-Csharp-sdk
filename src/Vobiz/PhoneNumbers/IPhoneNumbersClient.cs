namespace Vobiz;

public partial interface IPhoneNumbersClient
{
    /// <summary>
    /// List all phone numbers on your account.
    /// </summary>
    WithRawResponseTask<ListNumbersResponse> ListNumbersAsync(
        ListNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Release a phone number from your account. Releasing a number incurs the
    /// number-release fee configured for the account; the response returns the
    /// charged amount in `release_fee`. By default, the number enters
    /// `pending_release` for a 24-hour cooldown. Cancelling during that window
    /// refunds the release fee. Set `immediate=true` to skip the cooldown; an
    /// immediate release cannot be cancelled.
    /// </summary>
    WithRawResponseTask<UnrentNumberResponse> UnrentNumberAsync(
        UnrentNumberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a pending number release during the 24-hour cooldown. The number is
    /// restored to `active`, the cooldown timer is cleared, and the release fee is
    /// refunded in full to the account balance. Any trunk or voice application
    /// detached by the release is not re-attached automatically.
    /// </summary>
    WithRawResponseTask<CancelNumberReleaseResponse> CancelNumberReleaseAsync(
        CancelNumberReleaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Browse available phone numbers in inventory that are not assigned to
    /// any account. Only numbers with `status='active'` and `auth_id=NULL`
    /// are returned. These numbers are ready to be purchased.
    /// </summary>
    WithRawResponseTask<ListInventoryNumbersResponse> ListInventoryNumbersAsync(
        ListInventoryNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Purchase a phone number from inventory and assign it to your account.
    /// Debits your account balance for the setup fee and monthly fee. For
    /// sub-accounts (SA_), the parent master account (MA_) is charged.
    /// </summary>
    WithRawResponseTask<object> PurchaseFromInventoryAsync(
        PurchaseFromInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign a phone number to a specific SIP trunk. Once assigned, all
    /// inbound calls to that phone number will be routed through the
    /// designated trunk. The phone number must be URL-encoded; use `%2B`
    /// instead of `+` (e.g., `%2B912271264217`).
    /// </summary>
    WithRawResponseTask AssignNumberToTrunkAsync(
        AssignNumberToTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove the assignment between a phone number and a SIP trunk. After
    /// unassignment, the number remains in your account inventory but will
    /// no longer route inbound calls through the previously assigned trunk.
    /// URL-encode the phone number (use `%2B` instead of `+`).
    /// </summary>
    WithRawResponseTask UnassignNumberFromTrunkAsync(
        UnassignNumberFromTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the health & analytics dashboard for one of your numbers: current
    /// status, spam flag, and call metrics over the selected window (total and
    /// answered calls, answer rate, minutes, average duration) plus a per-period
    /// time series of snapshots.
    /// </summary>
    WithRawResponseTask<GetNumberHealthResponse> GetNumberHealthAsync(
        GetNumberHealthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign a parent-pool DID to a sub-account.
    /// </summary>
    WithRawResponseTask AssignDidToSubaccountAsync(
        AssignDidToSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Move the DID back to the parent pool.
    ///
    /// A **15-day cool-off** is enforced: if the DID had a call within the last
    /// 15 days, the request is rejected with `409` and a
    /// `did_cool_off_in_effect` error that includes `cool_off_until` and
    /// `cool_off_remaining_seconds`. Never-used DIDs (`last_call_at` is `NULL`)
    /// move back immediately.
    ///
    /// Admins can bypass the cool-off with `?force=true` (see below); the
    /// bypass writes a `did_assignment_audit` row and requires an
    /// admin-role account.
    /// </summary>
    WithRawResponseTask UnassignDidFromSubaccountAsync(
        UnassignDidFromSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
