using Vobiz;

namespace Vobiz.Sms;

public partial interface IBrandsClient
{
    /// <summary>
    /// Returns every brand on your account as a bare JSON array, newest first. The list is not paginated and reads the records stored on your account without contacting the registry; deleted brands are left out. Call `GET /10dlc/brands/{id}` for the latest registry state of one brand.
    /// </summary>
    WithRawResponseTask<IEnumerable<Brand>> ListBrandsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a brand, the business identity that US carriers associate with your 10DLC traffic, and mirrors it to the US 10DLC registry in `DRAFT` stage. `name` and `brandType` are required; send every other field your business has, because the registry reviews them when you register. Nothing is submitted for review until you call `POST /10dlc/brands/{id}/register`. Pass a `referenceId` so that a retried request (for example after a `502`) reconciles to the same brand instead of creating a second one. Next, register the brand, then create a campaign under it with `POST /10dlc/campaigns`.
    /// </summary>
    WithRawResponseTask<Brand> CreateBrandAsync(
        CreateBrandRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one brand after refreshing its `stage`, `registrationStatus`, `brandIdentityStatus` and `rejectionReasons` from the US 10DLC registry. The refresh is best-effort: if the registry is slow to answer, you get the stored record and `lastSyncedAt` tells you how fresh it is. Poll this endpoint (or listen for the `10dlc.brand.updated` WebSocket event) after registering to follow the review.
    /// </summary>
    WithRawResponseTask<Brand> GetBrandAsync(
        GetBrandRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the brand with the body you send and pushes the change to the US 10DLC registry. This is a full replacement, not a patch: send the same shape as create, including `name` and `brandType`, and any field you leave out is cleared. `referenceId` is ignored on update. Use it to correct a brand before registering it, or to fix the points listed in `rejectionReasons` before resubmitting.
    /// </summary>
    WithRawResponseTask<Brand> UpdateBrandAsync(
        UpdateBrandRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the brand from your account and from the US 10DLC registry and returns `204` with no body. A brand that still owns campaigns returns `409` with `conflict: brand still has N campaign(s); delete them first`, so delete or deregister its campaigns first. Deletion cannot be undone; a new brand needs a new registration.
    /// </summary>
    WithRawResponseTask DeleteBrandAsync(
        DeleteBrandRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits the brand to the US 10DLC registry for identity verification. The brand moves from `DRAFT` to `SUBMITTED` and `registrationStatus` starts tracking the registrar's decision (`PENDING`, then `ACTIVE` or `REJECTED`). The request has no body and returns the refreshed brand. Submit only when the brand details are final and you intend to register this business. Follow progress with `GET /10dlc/brands/{id}` or `GET /10dlc/brands/{id}/registrar-statuses`.
    /// </summary>
    WithRawResponseTask<Brand> RegisterBrandAsync(
        RegisterBrandRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the brand's state at each registrar that has reviewed it, read live from the US 10DLC registry. Each entry carries the registrar's `state` and, when the registrar reports them, the identity result, the authentication status and a rejection reason. An empty array means no registrar has recorded a state yet. Use it to see why a brand is pending or rejected.
    /// </summary>
    WithRawResponseTask<IEnumerable<BrandRegistrarStatus>> BrandRegistrarStatusesAsync(
        BrandRegistrarStatusesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts the registry's brand authentication for a brand whose `brandType` is `TENDLC_PUBLIC_COMPANY`. The registry sends a two-factor verification request to the brand's `businessContactEmail`, and the brand shows `registrationStatus` `PENDING_2FA` until the contact completes it. The request has no body and returns `202` with `{"status":"requested"}`. Any other brand type returns `400` with `invalid request: brand authentication is only available for TENDLC_PUBLIC_COMPANY brands`.
    /// </summary>
    WithRawResponseTask<BrandAuthRequested> BrandAuthVerificationAsync(
        BrandAuthVerificationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Asks the registry to send the brand-authentication verification again to the brand's `businessContactEmail`. Use it when a `TENDLC_PUBLIC_COMPANY` brand is `PENDING_2FA` and the contact did not receive or let the first request expire. The request has no body and returns `202` with `{"status":"requested"}`. Any other brand type returns `400`.
    /// </summary>
    WithRawResponseTask<BrandAuthRequested> Resend2FaAsync(
        Resend2FaRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requests an external vet of a registered brand from the US 10DLC registry. A successful vet can raise the brand's trust tier and, with it, the throughput carriers grant its campaigns. `type` defaults to `STANDARD`; any value other than `STANDARD`, `ENHANCED` or `POLITICAL` returns `400`. Every call files a new vetting request, so send it only when you intend to. The response is the registry's vetting record, returned as received; list past vets with `GET /10dlc/brands/{id}/vets`.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> VetBrandAsync(
        BrandVetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the brand's vetting records from the US 10DLC registry, one page at a time. The body is `{"results": [...], "paging": {...}}`, where each result is a registry vetting record passed through as received. `page` must be 0 or more and `size` between 0 and 100; other values return `400` with `page must be &gt;= 0 and size between 0 and 100`.
    /// </summary>
    WithRawResponseTask<BrandVetList> ListBrandVetsAsync(
        ListBrandVetsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
