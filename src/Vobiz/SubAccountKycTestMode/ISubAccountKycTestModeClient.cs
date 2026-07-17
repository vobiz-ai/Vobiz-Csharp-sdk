namespace Vobiz;

public partial interface ISubAccountKycTestModeClient
{
    /// <summary>
    /// Mock PAN verification - never hits the provider. Magic `pan` inputs:
    ///
    /// | Input | Outcome |
    /// |---|---|
    /// | `TESTSUCCESS0001` | verified |
    /// | `TESTFAIL0001` | failed |
    /// | `TESTERROR0001` | HTTP 500 |
    /// | `TESTPENDING001` | pending (finalize as verified) |
    /// | `TESTPENDING_FAIL` | pending (finalize as failed) |
    ///
    /// Persists a real `kyc_verifications` row and recomputes `kyc_status`.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> MockVerifySubaccountPanAsync(
        MockVerifySubaccountPanRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mock GST verification. Same magic-input matrix as [Mock verify PAN](#operation/mock-verify-subaccount-pan).
    /// </summary>
    WithRawResponseTask<KycVerificationResult> MockVerifySubaccountGstAsync(
        MockVerifySubaccountGstRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns deterministic fake company matches.
    /// </summary>
    WithRawResponseTask<object> MockSearchSubaccountCinAsync(
        MockSearchSubaccountCinRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Succeeds when `selected_cin` starts with `U72900KA2024PTC123456`.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> MockConfirmSubaccountCinAsync(
        MockConfirmSubaccountCinRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a deterministic `access_request_id`.
    /// </summary>
    WithRawResponseTask<object> MockSubaccountDigilockerInitiateAsync(
        MockSubaccountDigilockerInitiateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// `access_request_id` `MOCK_AR_SUCCESS` → verified; `MOCK_AR_FAIL` → failed.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> MockSubaccountDigilockerVerifyAsync(
        MockSubaccountDigilockerVerifyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Promotes the most recent **pending** mock verification of the given
    /// type to a terminal outcome - this drives the async (`TESTPENDING…`)
    /// path without webhooks. `verification_type` ∈ `pan | aadhaar | gst | cin`;
    /// `outcome` ∈ `verified | failed`.
    /// </summary>
    WithRawResponseTask<KycVerificationResult> MockFinalizePendingKycAsync(
        MockFinalizePendingKycRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
