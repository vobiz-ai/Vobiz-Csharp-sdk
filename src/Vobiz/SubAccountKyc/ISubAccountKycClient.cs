namespace Vobiz;

public partial interface ISubAccountKycClient
{
    /// <summary>
    /// Returns the aggregated KYC state for a `customer_use` sub-account —
    /// which verifications have passed, whether calls are still blocked, and
    /// the business type. The caller must be the parent main account that owns
    /// the sub-account (or an admin).
    /// </summary>
    WithRawResponseTask<SubAccountKycStatus> GetSubaccountKycStatusAsync(
        GetSubaccountKycStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Runs a real PAN verification (Perfios) for the sub-account. `pan` must
    /// be exactly 10 characters. Persists a `kyc_verifications` row and
    /// recomputes the sub-account's aggregated `kyc_status`.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> VerifySubaccountPanAsync(
        VerifySubaccountPanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Runs a real GSTIN verification. `gstin` must be a 15-character GSTIN.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> VerifySubaccountGstAsync(
        VerifySubaccountGstRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Name-based CIN lookup. Returns candidate company matches; pick one and
    /// pass it to [CIN confirm](#operation/confirm-subaccount-cin).
    /// </summary>
    WithRawResponseTask<object> SearchSubaccountCinAsync(
        SearchSubaccountCinRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Confirm the CIN selected from the search results.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> ConfirmSubaccountCinAsync(
        ConfirmSubaccountCinRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the DigiLocker authorization link and an `access_request_id`.
    /// The customer completes the OAuth flow on the DigiLocker portal, after
    /// which you finalize with
    /// [DigiLocker verify](#operation/subaccount-digilocker-verify).
    /// </summary>
    WithRawResponseTask<object> SubaccountDigilockerInitiateAsync(
        SubaccountDigilockerInitiateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Finalize Aadhaar via DigiLocker after the customer completes OAuth.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> SubaccountDigilockerVerifyAsync(
        SubaccountDigilockerVerifyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a Vobiz-hosted KYC session for the sub-account. With
    /// `flow_type=email` (default) Vobiz emails the customer a signed link
    /// (from `kyc@vobiz.ai`, hosted at `kyc.vobiz.ai`) and `customer_email` is
    /// required. With `flow_type=redirect`, omit `customer_email`, pass a
    /// `redirect_url`, and the `widget_url` is returned directly for an inline
    /// redirect.
    ///
    /// This is the sub-account–scoped equivalent of the partner-level
    /// [KYC Sessions](/partner/api/kyc-sessions) endpoint.
    /// </summary>
    WithRawResponseTask<object> CreateSubaccountKycSessionAsync(
        CreateSubaccountKycSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
