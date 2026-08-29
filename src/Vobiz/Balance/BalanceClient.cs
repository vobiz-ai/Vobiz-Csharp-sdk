using global::System.Text.Json;
using Vobiz.Core;

namespace Vobiz;

public partial class BalanceClient : IBalanceClient
{
    private readonly RawClient _client;

    internal BalanceClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<GetBalanceResponse>> GetBalanceAsyncCore(
        GetBalanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Vobiz.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/v1/Account/{0}/balance/{1}",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.Currency)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetBalanceResponse>(responseBody)!;
                return new WithRawResponse<GetBalanceResponse>()
                {
                    Data = responseData,
                    RawResponse = new Vobiz.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VobizApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Vobiz.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new VobizApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Vobiz.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<ListTransactionsResponse>> ListTransactionsAsyncCore(
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("page", request.Page)
            .Add("per_page", request.PerPage)
            .Add("from_date", request.FromDate)
            .Add("to_date", request.ToDate)
            .Add("type", request.Type)
            .Add("status", request.Status)
            .Add("currency", request.Currency)
            .Add("reference_type", request.ReferenceType)
            .Add("description", request.Description)
            .Add("reference", request.Reference)
            .Add("transaction_id", request.TransactionId)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Vobiz.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/v1/Account/{0}/transactions",
                        ValueConvert.ToPathParameterString(request.AuthId)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ListTransactionsResponse>(responseBody)!;
                return new WithRawResponse<ListTransactionsResponse>()
                {
                    Data = responseData,
                    RawResponse = new Vobiz.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VobizApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Vobiz.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new VobizApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Vobiz.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<ListTransactionReferenceTypesResponse>
    > ListTransactionReferenceTypesAsyncCore(
        ListTransactionReferenceTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Vobiz.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/v1/Account/{0}/transactions/reference-types",
                        ValueConvert.ToPathParameterString(request.AuthId)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ListTransactionReferenceTypesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ListTransactionReferenceTypesResponse>()
                {
                    Data = responseData,
                    RawResponse = new Vobiz.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new VobizApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Vobiz.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new VobizApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Vobiz.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Retrieve the current account balance for a specific currency.
    /// </summary>
    /// <example><code>
    /// await client.Balance.GetBalanceAsync(
    ///     new GetBalanceRequest { AuthId = "MA_XXXXXX", Currency = "INR" }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetBalanceResponse> GetBalanceAsync(
        GetBalanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetBalanceResponse>(
            GetBalanceAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve paginated transaction history for the account, ordered by
    /// `created_at` descending. Filter to a single day by setting `from_date`
    /// and `to_date` to the same date - a bare `YYYY-MM-DD` in `to_date` is
    /// expanded to `23:59:59`, so both bounds are inclusive. Bare dates resolve
    /// in the server timezone (UTC); send an explicit offset such as
    /// `2026-08-28T00:00:00+05:30` to pin a local calendar day.
    ///
    /// `limit` and `offset` are not supported - unknown parameters are silently
    /// dropped. `total` and `summary` are computed over the whole filtered set
    /// and ignore pagination, so `per_page=1` returns full-window totals.
    /// </summary>
    /// <example><code>
    /// await client.Balance.ListTransactionsAsync(
    ///     new ListTransactionsRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         FromDate = "2026-08-25",
    ///         ToDate = "2026-08-25",
    ///         Type = "debit",
    ///         Currency = "INR",
    ///         ReferenceType = "cdr",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListTransactionsResponse> ListTransactionsAsync(
        ListTransactionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListTransactionsResponse>(
            ListTransactionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the distinct `reference_type` values present on the account's ledger. Use it to discover valid values for the `reference_type` filter on the transactions endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Balance.ListTransactionReferenceTypesAsync(
    ///     new ListTransactionReferenceTypesRequest { AuthId = "MA_XXXXXX" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListTransactionReferenceTypesResponse> ListTransactionReferenceTypesAsync(
        ListTransactionReferenceTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListTransactionReferenceTypesResponse>(
            ListTransactionReferenceTypesAsyncCore(request, options, cancellationToken)
        );
    }
}
