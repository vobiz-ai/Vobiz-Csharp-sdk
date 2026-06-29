namespace Vobiz;

public partial interface ICdrClient
{
    /// <summary>
    /// Returns all CDRs for your account. Supports filtering by phone numbers,
    /// date range, call direction, duration, and pagination.
    /// </summary>
    WithRawResponseTask<ListCdrsResponse> ListCdrsAsync(
        ListCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Identical filters to the list endpoint, but the response also includes a
    /// `filter_summary` object describing the active filters applied.
    /// </summary>
    WithRawResponseTask<SearchCdrsResponse> SearchCdrsAsync(
        SearchCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the most recent CDRs for your account without requiring a date range.
    /// Default 20 records; use `limit` to retrieve more.
    /// </summary>
    WithRawResponseTask<ListRecentCdrsResponse> ListRecentCdrsAsync(
        ListRecentCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns CDR data as a downloadable CSV file. Same filters as the list endpoint.
    ///
    /// **Note:** Do NOT send `Accept: application/json` on this endpoint - the response is `text/csv`.
    /// </summary>
    WithRawResponseTask<global::System.IO.Stream> ExportCdrsAsync(
        ExportCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the CDR for a specific completed call using its `call_id`.
    /// Useful when you have a `call_id` from a callback or previous API response.
    /// </summary>
    WithRawResponseTask<GetCdrResponse> GetCdrAsync(
        GetCdrRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
