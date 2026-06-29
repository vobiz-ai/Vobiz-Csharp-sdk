namespace Vobiz;

public partial interface ISubAccountsClient
{
    /// <summary>
    /// Retrieve all sub-accounts under the master account.
    /// </summary>
    WithRawResponseTask<ListSubaccountsResponse> ListSubaccountsAsync(
        ListSubaccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new sub-account under the master account.
    ///
    /// Set `kyc_mode` to control how the sub-account is verified:
    ///
    /// - `personal_use` *(default)* — the sub-account inherits the parent's
    ///   KYC; no separate verification is required.
    /// - `customer_use` — the sub-account must complete its own KYC before it
    ///   can place calls. A fresh `customer_use` sub-account is returned with
    ///   `kyc_calls_blocked: true`. `customer_use` **requires** `email`.
    /// </summary>
    WithRawResponseTask<CreateSubaccountResponse> CreateSubaccountAsync(
        CreateSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of a specific sub-account.
    /// </summary>
    WithRawResponseTask<RetrieveSubaccountResponse> RetrieveSubaccountAsync(
        RetrieveSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the name or status of a sub-account, or change its `kyc_mode`.
    ///
    /// Promoting an existing sub-account to `customer_use` requires the
    /// sub-account to already have an `email` (otherwise `400`). On any
    /// `kyc_mode` change, `kyc_calls_blocked` is re-derived from the
    /// sub-account's current KYC state.
    /// </summary>
    WithRawResponseTask<UpdateSubaccountResponse> UpdateSubaccountAsync(
        UpdateSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a sub-account and revoke its credentials.
    /// </summary>
    WithRawResponseTask<DeleteSubaccountResponse?> DeleteSubaccountAsync(
        DeleteSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
