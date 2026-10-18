using Vobiz;

namespace Vobiz.Sms;

public partial interface ICampaignsClient
{
    /// <summary>
    /// Returns every 10DLC and toll-free campaign on your account as a bare JSON array, newest first. The list is not paginated and reads the records stored on your account without contacting the registry. Toll-free campaigns have `campaignType` `TOLL_FREE_UNIFIED_NUMBER` and no `brandId`. Call `GET /10dlc/campaigns/{id}` for the latest registry state of one campaign.
    /// </summary>
    WithRawResponseTask<IEnumerable<Campaign>> ListCampaignsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a 10DLC campaign, the messaging program you run under one of your brands, and mirrors it to the US 10DLC registry in `DRAFT` stage. `name` and `brandId` are required; `campaignType` defaults to `TEN_DIGIT_LONG_CODE`. Upload any `supportingDocuments` or `mmsSampleFiles` with `POST /10dlc/documents` first. Pass a `referenceId` so a retried request reconciles to the same campaign. Next, submit the campaign with `POST /10dlc/campaigns/{id}/register`; toll-free verification uses `POST /10dlc/campaigns/toll-free` instead.
    /// </summary>
    WithRawResponseTask<Campaign> CreateCampaignAsync(
        CreateCampaignRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts toll-free verification for one or more toll-free numbers. The business details travel inside the request, so no brand is needed; only `name` is required, but the registry reviews every field you send. The campaign is created with `campaignType` `TOLL_FREE_UNIFIED_NUMBER` and no `brandId`. Pass a `referenceId` so a retried request reconciles to the same campaign, then submit it with `POST /10dlc/campaigns/{id}/register`.
    /// </summary>
    WithRawResponseTask<Campaign> CreateTollFreeCampaignAsync(
        TollFreeCampaignRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the priority options available to your account at the US 10DLC registry, as a JSON array. Pass an option's `id` as `priorityId` when you create or register a toll-free campaign. An empty array means no priority options apply to your account, and you can omit `priorityId`.
    /// </summary>
    WithRawResponseTask<IEnumerable<PriorityOption>> CampaignPrioritiesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one campaign after refreshing its `stage` and review feedback (`rejectionReasons`) from the US 10DLC registry. If the registry is slow to answer, you get the stored record and `lastSyncedAt` tells you how fresh it is. Poll this endpoint (or listen for the `10dlc.campaign.updated` WebSocket event) after registering until `stage` settles at `REGISTERED` or `REJECTED`.
    /// </summary>
    WithRawResponseTask<Campaign> GetCampaignAsync(
        GetCampaignRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the editable fields of a 10DLC campaign and pushes the change to the US 10DLC registry. This is a full replacement: `name` is required and any field you leave out is cleared. `campaignType` and the brand stay as created, and `referenceId` is ignored. The registry accepts updates while the campaign is `DRAFT` or `REJECTED`. Toll-free campaigns return `400` on this endpoint.
    /// </summary>
    WithRawResponseTask<Campaign> UpdateCampaignAsync(
        UpdateCampaignRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the campaign from your account and from the US 10DLC registry and returns `204` with no body. The registry accepts deletion while the campaign is `DRAFT`, `DEREGISTERED` or `REJECTED`; deregister a registered campaign with `POST /10dlc/campaigns/{id}/deregister` first. Delete all of a brand's campaigns before you delete the brand.
    /// </summary>
    WithRawResponseTask DeleteCampaignAsync(
        DeleteCampaignRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits the campaign to the US 10DLC registry for review and returns the refreshed campaign. The `stage` moves out of `DRAFT`; poll `GET /10dlc/campaigns/{id}` until it settles at `REGISTERED` or `REJECTED`. The body is optional and carries a `priorityId` from `GET /10dlc/campaigns/priorities` for toll-free campaigns; a value that is not a UUID returns `400`. Submit only when the campaign details are final and you intend to run this program.
    /// </summary>
    WithRawResponseTask<Campaign> RegisterCampaignAsync(
        CampaignRegisterRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Withdraws a registered campaign from the US 10DLC registry and returns the campaign. Once deregistration completes, traffic on the campaign's numbers is no longer covered by this registration, so move the numbers to another registered campaign first if you keep sending. The request has no body. A deregistered campaign can then be deleted with `DELETE /10dlc/campaigns/{id}`.
    /// </summary>
    WithRawResponseTask<Campaign> DeregisterCampaignAsync(
        DeregisterCampaignRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Asks the US 10DLC registry to reconsider a `REJECTED` campaign and returns the campaign after the appeal is filed. Fix the campaign with `PUT /10dlc/campaigns/{id}` first, then explain what changed in `reason`, which is required (`400` with `invalid request: reason is required` otherwise). Follow the outcome with `GET /10dlc/campaigns/{id}`.
    /// </summary>
    WithRawResponseTask<Campaign> AppealCampaignAsync(
        CampaignAppealRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Asks the US 10DLC registry to update the set of numbers covered by a registered campaign, without deregistering it. Provide `numbers`, `numberKeys`, or both; if both are empty the call returns `400` with `invalid request: numbers or numberKeys is required`. The response is the campaign; the `numbers` list stored on your account is left as it was. Use `POST` and `DELETE /10dlc/campaigns/{id}/numbers` for incremental changes.
    /// </summary>
    WithRawResponseTask<Campaign> UpdateCampaignRegistrationAsync(
        UpdateCampaignRegistrationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the campaign's status at each US carrier network, read live from the US 10DLC registry. Each entry names the network and its `state`, plus the message class, throughput and brand tier when the network reports them. Use it after the campaign reaches `REGISTERED` to see which networks have provisioned it and what throughput they grant.
    /// </summary>
    WithRawResponseTask<IEnumerable<CampaignNetworkStatus>> CampaignNetworkStatusesAsync(
        CampaignNetworkStatusesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the numbers attached to the campaign at the US 10DLC registry, as `{"numberPreviews": [...]}`. Each entry gives the number, its country and the registry `numberKey`, which you can pass in `numberKeys` on the number endpoints. Use it to confirm which numbers the registry associates with the campaign.
    /// </summary>
    WithRawResponseTask<CampaignNumberList> ListCampaignNumbersAsync(
        ListCampaignNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Attaches numbers to the campaign at the US 10DLC registry and adds the `numbers` values to the campaign's `numbers` list on your account. Provide `numbers`, `numberKeys`, or both; if both are empty the call returns `400`. Returns `200` with `{"status":"ok"}`. Attach only numbers on your account that you send this program from.
    /// </summary>
    WithRawResponseTask<StatusOk> AddCampaignNumbersAsync(
        AddCampaignNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Detaches numbers from the campaign at the US 10DLC registry and removes the `numbers` values from the campaign's `numbers` list on your account. Send `numbers`, `numberKeys`, or both in the `DELETE` request body; if both are empty the call returns `400`. Returns `200` with `{"status":"ok"}`. Messages from a detached number are no longer covered by this campaign.
    /// </summary>
    WithRawResponseTask<StatusOk> RemoveCampaignNumbersAsync(
        RemoveCampaignNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a supporting document or MMS sample file for campaign registration and stores it at the US 10DLC registry. Send `multipart/form-data` with the file in a part named `document` that carries a filename; the file can be up to 10 MB (`413` above that). The response is the document record; reference its `documentId` in a campaign's `supportingDocuments` or `mmsSampleFiles`, and use the same value to download it again.
    /// </summary>
    WithRawResponseTask<Document> UploadDocumentAsync(
        UploadDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads a document you uploaded with `POST /10dlc/documents`. The response body is the file itself, with the file's own `Content-Type` and a `Content-Disposition: attachment` header that carries the original filename. Look the file up by its `documentId`, not by the record `id`.
    /// </summary>
    WithRawResponseTask<global::System.IO.Stream> GetDocumentAsync(
        GetDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
