using global::System.Text.Json;
using Vobiz.Core;

namespace Vobiz;

public partial class CdrClient : ICdrClient
{
    private readonly RawClient _client;

    internal CdrClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ListCdrsResponse>> ListCdrsAsyncCore(
        ListCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 15)
            .Add("from_number", request.FromNumber)
            .Add("to_number", request.ToNumber)
            .Add("start_date", request.StartDate)
            .Add("end_date", request.EndDate)
            .Add("call_direction", request.CallDirection)
            .Add("min_duration", request.MinDuration)
            .Add("sip_call_id", request.SipCallId)
            .Add("bridge_uuid", request.BridgeUuid)
            .Add("hangup_cause", request.HangupCause)
            .Add("hangup_disposition", request.HangupDisposition)
            .Add("context", request.Context)
            .Add("campaign_id", request.CampaignId)
            .Add("search", request.Search)
            .Add("page", request.Page)
            .Add("per_page", request.PerPage)
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
                        "api/v1/Account/{0}/cdr",
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
                var responseData = JsonUtils.Deserialize<ListCdrsResponse>(responseBody)!;
                return new WithRawResponse<ListCdrsResponse>()
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

    private async Task<WithRawResponse<SearchCdrsResponse>> SearchCdrsAsyncCore(
        SearchCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 15)
            .Add("from_number", request.FromNumber)
            .Add("to_number", request.ToNumber)
            .Add("start_date", request.StartDate)
            .Add("end_date", request.EndDate)
            .Add("call_direction", request.CallDirection)
            .Add("min_duration", request.MinDuration)
            .Add("sip_call_id", request.SipCallId)
            .Add("bridge_uuid", request.BridgeUuid)
            .Add("hangup_cause", request.HangupCause)
            .Add("hangup_disposition", request.HangupDisposition)
            .Add("context", request.Context)
            .Add("campaign_id", request.CampaignId)
            .Add("search", request.Search)
            .Add("page", request.Page)
            .Add("per_page", request.PerPage)
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
                        "api/v1/Account/{0}/cdr/search",
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
                var responseData = JsonUtils.Deserialize<SearchCdrsResponse>(responseBody)!;
                return new WithRawResponse<SearchCdrsResponse>()
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

    private async Task<WithRawResponse<ListRecentCdrsResponse>> ListRecentCdrsAsyncCore(
        ListRecentCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("limit", request.Limit)
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
                        "api/v1/Account/{0}/cdr/recent",
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
                var responseData = JsonUtils.Deserialize<ListRecentCdrsResponse>(responseBody)!;
                return new WithRawResponse<ListRecentCdrsResponse>()
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

    private async Task<WithRawResponse<global::System.IO.Stream>> ExportCdrsAsyncCore(
        ExportCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 13)
            .Add("from_number", request.FromNumber)
            .Add("to_number", request.ToNumber)
            .Add("start_date", request.StartDate)
            .Add("end_date", request.EndDate)
            .Add("call_direction", request.CallDirection)
            .Add("min_duration", request.MinDuration)
            .Add("sip_call_id", request.SipCallId)
            .Add("bridge_uuid", request.BridgeUuid)
            .Add("hangup_cause", request.HangupCause)
            .Add("hangup_disposition", request.HangupDisposition)
            .Add("context", request.Context)
            .Add("campaign_id", request.CampaignId)
            .Add("search", request.Search)
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
                        "api/v1/Account/{0}/cdr/export",
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
            var stream = await response.Raw.Content.ReadAsStreamAsync();
            return new WithRawResponse<global::System.IO.Stream>()
            {
                Data = stream,
                RawResponse = new Vobiz.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                },
            };
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

    private async Task<WithRawResponse<GetCdrResponse>> GetCdrAsyncCore(
        GetCdrRequest request,
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
                        "api/v1/Account/{0}/cdr/{1}",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.CallId)
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
                var responseData = JsonUtils.Deserialize<GetCdrResponse>(responseBody)!;
                return new WithRawResponse<GetCdrResponse>()
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
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new Vobiz.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
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
    /// Returns all CDRs for your account. Supports filtering by phone numbers,
    /// date range, call direction, duration, and pagination.
    /// </summary>
    /// <example><code>
    /// await client.Cdr.ListCdrsAsync(
    ///     new ListCdrsRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         FromNumber = "9876543210",
    ///         ToNumber = "1234567890",
    ///         StartDate = new DateOnly(2026, 3, 1),
    ///         EndDate = new DateOnly(2026, 3, 17),
    ///         MinDuration = 10,
    ///         SipCallId = "dD1qwu5VZ5iK3ed5u3uspjY5RKL",
    ///         BridgeUuid = "4b7ae653-f40d-42f1-b582-6b05dfcd0c0a",
    ///         HangupCause = "NORMAL_CLEARING",
    ///         HangupDisposition = "send_refuse",
    ///         Context = "sip-trunking",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListCdrsResponse> ListCdrsAsync(
        ListCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListCdrsResponse>(
            ListCdrsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Identical filters to the list endpoint, but the response also includes a
    /// `filter_summary` object describing the active filters applied.
    /// </summary>
    /// <example><code>
    /// await client.Cdr.SearchCdrsAsync(
    ///     new SearchCdrsRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         FromNumber = "9876543210",
    ///         ToNumber = "1234567890",
    ///         StartDate = new DateOnly(2026, 3, 1),
    ///         EndDate = new DateOnly(2026, 3, 17),
    ///         MinDuration = 10,
    ///         SipCallId = "dD1qwu5VZ5iK3ed5u3uspjY5RKL",
    ///         BridgeUuid = "4b7ae653-f40d-42f1-b582-6b05dfcd0c0a",
    ///         HangupCause = "NORMAL_CLEARING",
    ///         HangupDisposition = "send_refuse",
    ///         Context = "sip-trunking",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SearchCdrsResponse> SearchCdrsAsync(
        SearchCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SearchCdrsResponse>(
            SearchCdrsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the most recent CDRs for your account without requiring a date range.
    /// Default 20 records; use `limit` to retrieve more.
    /// </summary>
    /// <example><code>
    /// await client.Cdr.ListRecentCdrsAsync(
    ///     new ListRecentCdrsRequest { AuthId = "MA_XXXXXX", Limit = 50 }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListRecentCdrsResponse> ListRecentCdrsAsync(
        ListRecentCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListRecentCdrsResponse>(
            ListRecentCdrsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns CDR data as a downloadable CSV file. Same filters as the list endpoint.
    ///
    /// **Note:** Do NOT send `Accept: application/json` on this endpoint - the response is `text/csv`.
    /// </summary>
    public WithRawResponseTask<global::System.IO.Stream> ExportCdrsAsync(
        ExportCdrsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<global::System.IO.Stream>(
            ExportCdrsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the CDR for a specific completed call using its `call_id`.
    /// Useful when you have a `call_id` from a callback or previous API response.
    /// </summary>
    /// <example><code>
    /// await client.Cdr.GetCdrAsync(
    ///     new GetCdrRequest { AuthId = "MA_XXXXXX", CallId = "abc123-def456-ghi789" }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetCdrResponse> GetCdrAsync(
        GetCdrRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetCdrResponse>(
            GetCdrAsyncCore(request, options, cancellationToken)
        );
    }
}
