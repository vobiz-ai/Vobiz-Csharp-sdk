using Vobiz;

namespace Vobiz.Sms;

public partial interface ICoverageClient
{
    /// <summary>
    /// Returns one summary row per destination country, sorted by country name: the sender types it accepts, whether sender registration is required, two-way support, opt-out rules and whether a sending window applies. Use it to plan where to send and which sender to use before you buy numbers or register. Filters combine, so `region` plus `twoWay=true` returns only two-way countries in that region. For the full record of one country, call `GET /coverage/{country}`.
    /// </summary>
    WithRawResponseTask<CoverageList> ListCoverageAsync(
        ListCoverageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the full coverage record for one country: accepted sender types, registration requirements and lead time, link rules, prohibited topics, the permitted sending window and free-text market notes. Read it before your first send to a new country so your sender, content and send times match the local rules. An unknown code returns `404` with `country not found`.
    /// </summary>
    WithRawResponseTask<CoverageDetail> GetCoverageAsync(
        GetCoverageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
