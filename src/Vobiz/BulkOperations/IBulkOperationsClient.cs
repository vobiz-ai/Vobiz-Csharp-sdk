namespace Vobiz;

public partial interface IBulkOperationsClient
{
    /// <summary>
    /// Queue a bulk export of the recordings matching your filter criteria. The request is
    /// validated and accepted for background processing, and the resulting archive is emailed
    /// as a download link to every address in `recipient.customer_account`. The archive is
    /// typically available within 15-60 minutes depending on volume.
    ///
    /// Results are delivered by email only; the export runs to completion in the background
    /// after the `202` response.
    ///
    /// One export runs at a time per account. While an export is in progress, further requests
    /// return `403`.
    ///
    /// Filter rules:
    /// - Use either `from`/`to` or the `recording_storage_duration*` filters, not both.
    /// - Use one of `__gt` or `__gte`, and one of `__lt` or `__lte`.
    /// - When using range filters (`__gte`/`__lte`), provide both.
    /// - Maximum date range is 1 year (366 days); maximum storage duration range is 30 days.
    /// - The additional filters (`from_number`, `to_number`, `call_uuid`, `conference_name`,
    ///   `recording_format`, `recording_id`) apply when the range is 30 days or less.
    /// </summary>
    WithRawResponseTask<BulkExportRecordingsResponse> BulkExportRecordingsAsync(
        BulkExportRecordingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
