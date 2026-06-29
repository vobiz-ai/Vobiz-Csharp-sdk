namespace Vobiz;

public partial interface IPartnerApiClient
{
    /// <summary>
    /// Returns the authenticated partner's profile and balance.
    /// </summary>
    WithRawResponseTask<GetPartnerProfileResponse> GetPartnerProfileAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Aggregated partner metrics - total customers, active accounts, balance
    /// held across the partner ecosystem, MTD revenue, etc.
    /// </summary>
    WithRawResponseTask<GetPartnerDashboardResponse> GetPartnerDashboardAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all customer sub-accounts under your partner account.
    /// </summary>
    WithRawResponseTask<ListCustomerAccountsResponse> ListCustomerAccountsAsync(
        ListCustomerAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new customer sub-account under your partner account. VoBiz
    /// emails the customer their login credentials and (separately) a KYC link
    /// via the kyc-sessions endpoint.
    /// </summary>
    WithRawResponseTask<object> CreateCustomerAccountAsync(
        CreateCustomerAccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Atomically debits your partner master balance and credits the customer's
    /// wallet. Both legs are recorded in each account's ledger. Transfers are
    /// **permanent and cannot be reversed.**
    /// </summary>
    WithRawResponseTask<object> PartnerTransferBalanceAsync(
        PartnerTransferBalanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the customer's transaction ledger. Filter by date range or
    /// transaction type. Useful for billing reconciliation.
    /// </summary>
    WithRawResponseTask<ListCustomerTransactionsResponse> ListCustomerTransactionsAsync(
        ListCustomerTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Look up any customer's call history. Same filter set as the
    /// customer-side CDR endpoint.
    /// </summary>
    WithRawResponseTask<ListCustomerCdrsResponse> ListCustomerCdrsAsync(
        ListCustomerCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Phone numbers currently assigned to a customer account.
    /// </summary>
    WithRawResponseTask<ListCustomerNumbersResponse> ListCustomerNumbersAsync(
        ListCustomerNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ListKycSessionsResponse> ListKycSessionsAsync(
        ListKycSessionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Triggers VoBiz to email a KYC link to the customer. KYC is OTP-based
    /// (PAN + Aadhaar via DigiLocker for individuals, PAN + GSTIN for
    /// companies). No document uploads required.
    /// </summary>
    WithRawResponseTask<object> CreateKycSessionAsync(
        CreateKycSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask GetKycSessionAsync(
        GetKycSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an outstanding KYC session. Customer can no longer use the link.
    /// </summary>
    WithRawResponseTask<object> RevokeKycSessionAsync(
        RevokeKycSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Re-dispatches the KYC link to the customer. Rate-limited to once per 30 minutes.
    /// </summary>
    WithRawResponseTask ResendKycSessionAsync(
        ResendKycSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
