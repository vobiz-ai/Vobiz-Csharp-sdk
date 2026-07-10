using global::System.Text.Json;
using Vobiz.Core;

namespace Vobiz;

public partial class PhoneNumbersClient : IPhoneNumbersClient
{
    private readonly RawClient _client;

    internal PhoneNumbersClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ListNumbersResponse>> ListNumbersAsyncCore(
        ListNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("limit", request.Limit)
            .Add("offset", request.Offset)
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
                        "api/v1/Account/{0}/numbers",
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
                var responseData = JsonUtils.Deserialize<ListNumbersResponse>(responseBody)!;
                return new WithRawResponse<ListNumbersResponse>()
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

    private async Task<RawResponse> UnrentNumberAsyncCore(
        UnrentNumberRequest request,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "api/v1/Account/{0}/numbers/{1}",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.E164)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return new Vobiz.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
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

    private async Task<WithRawResponse<ListInventoryNumbersResponse>> ListInventoryNumbersAsyncCore(
        ListInventoryNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("country", request.Country)
            .Add("search", request.Search)
            .Add("exclude", request.Exclude)
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
                        "api/v1/Account/{0}/inventory/numbers",
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
                var responseData = JsonUtils.Deserialize<ListInventoryNumbersResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ListInventoryNumbersResponse>()
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

    private async Task<WithRawResponse<object>> PurchaseFromInventoryAsyncCore(
        PurchaseFromInventoryRequest request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/Account/{0}/numbers/purchase-from-inventory",
                        ValueConvert.ToPathParameterString(request.AuthId)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
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
                var responseData = JsonUtils.Deserialize<object>(responseBody)!;
                return new WithRawResponse<object>()
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
                    case 500:
                        throw new InternalServerError(
                            JsonUtils.Deserialize<Error>(responseBody),
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

    private async Task<RawResponse> AssignNumberToTrunkAsyncCore(
        AssignNumberToTrunkRequest request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/Account/{0}/numbers/{1}/assign",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.PhoneNumber)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return new Vobiz.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
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

    private async Task<RawResponse> UnassignNumberFromTrunkAsyncCore(
        UnassignNumberFromTrunkRequest request,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "api/v1/Account/{0}/numbers/{1}/assign",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.PhoneNumber)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return new Vobiz.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
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

    private async Task<WithRawResponse<GetNumberHealthResponse>> GetNumberHealthAsyncCore(
        GetNumberHealthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("granularity", request.Granularity)
            .Add("days", request.Days)
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
                        "api/v1/account/{0}/numbers/{1}/health",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.E164)
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
                var responseData = JsonUtils.Deserialize<GetNumberHealthResponse>(responseBody)!;
                return new WithRawResponse<GetNumberHealthResponse>()
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

    private async Task<RawResponse> AssignDidToSubaccountAsyncCore(
        AssignDidToSubaccountRequest request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/account/{0}/numbers/{1}/assign-subaccount",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.E164)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return new Vobiz.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
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

    private async Task<RawResponse> UnassignDidFromSubaccountAsyncCore(
        UnassignDidFromSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Vobiz.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("force", request.Force)
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "api/v1/account/{0}/numbers/{1}/assign-subaccount",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.E164)
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
            return new Vobiz.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Vobiz.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 409:
                        throw new ConflictError(
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
    /// List all phone numbers on your account.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.ListNumbersAsync(new ListNumbersRequest { AuthId = "MA_XXXXXX" });
    /// </code></example>
    public WithRawResponseTask<ListNumbersResponse> ListNumbersAsync(
        ListNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListNumbersResponse>(
            ListNumbersAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Release a phone number from your account.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.UnrentNumberAsync(
    ///     new UnrentNumberRequest { AuthId = "MA_XXXXXX", E164 = "919876543210" }
    /// );
    /// </code></example>
    public WithRawResponseTask UnrentNumberAsync(
        UnrentNumberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(UnrentNumberAsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Browse available phone numbers in inventory that are not assigned to
    /// any account. Only numbers with `status='active'` and `auth_id=NULL`
    /// are returned. These numbers are ready to be purchased.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.ListInventoryNumbersAsync(
    ///     new ListInventoryNumbersRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         Country = "IN",
    ///         Exclude = "9180,9192",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ListInventoryNumbersResponse> ListInventoryNumbersAsync(
        ListInventoryNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListInventoryNumbersResponse>(
            ListInventoryNumbersAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Purchase a phone number from inventory and assign it to your account.
    /// Debits your account balance for the setup fee and monthly fee. For
    /// sub-accounts (SA_), the parent master account (MA_) is charged.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.PurchaseFromInventoryAsync(
    ///     new PurchaseFromInventoryRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         E164 = "+919876543210",
    ///         Currency = "USD",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<object> PurchaseFromInventoryAsync(
        PurchaseFromInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<object>(
            PurchaseFromInventoryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Assign a phone number to a specific SIP trunk. Once assigned, all
    /// inbound calls to that phone number will be routed through the
    /// designated trunk. The phone number must be URL-encoded; use `%2B`
    /// instead of `+` (e.g., `%2B912271264217`).
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.AssignNumberToTrunkAsync(
    ///     new AssignNumberToTrunkRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         PhoneNumber = "%2B912271264217",
    ///         TrunkGroupId = "e3e55a78-1234-5678-90ab-cdef12345678",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask AssignNumberToTrunkAsync(
        AssignNumberToTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            AssignNumberToTrunkAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Remove the assignment between a phone number and a SIP trunk. After
    /// unassignment, the number remains in your account inventory but will
    /// no longer route inbound calls through the previously assigned trunk.
    /// URL-encode the phone number (use `%2B` instead of `+`).
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.UnassignNumberFromTrunkAsync(
    ///     new UnassignNumberFromTrunkRequest { AuthId = "MA_XXXXXX", PhoneNumber = "%2B912271264217" }
    /// );
    /// </code></example>
    public WithRawResponseTask UnassignNumberFromTrunkAsync(
        UnassignNumberFromTrunkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            UnassignNumberFromTrunkAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the health & analytics dashboard for one of your numbers: current
    /// status, spam flag, and call metrics over the selected window (total and
    /// answered calls, answer rate, minutes, average duration) plus a per-period
    /// time series of snapshots.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.GetNumberHealthAsync(
    ///     new GetNumberHealthRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         E164 = "%2B919876543210",
    ///         Days = 30,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetNumberHealthResponse> GetNumberHealthAsync(
        GetNumberHealthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetNumberHealthResponse>(
            GetNumberHealthAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Assign a parent-pool DID to a sub-account.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.AssignDidToSubaccountAsync(
    ///     new AssignDidToSubaccountRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         E164 = "%2B919876543210",
    ///         SubAccountId = "SA_XXXXXX",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask AssignDidToSubaccountAsync(
        AssignDidToSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            AssignDidToSubaccountAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Move the DID back to the parent pool.
    ///
    /// A **15-day cool-off** is enforced: if the DID had a call within the last
    /// 15 days, the request is rejected with `409` and a
    /// `did_cool_off_in_effect` error that includes `cool_off_until` and
    /// `cool_off_remaining_seconds`. Never-used DIDs (`last_call_at` is `NULL`)
    /// move back immediately.
    ///
    /// Admins can bypass the cool-off with `?force=true` (see below); the
    /// bypass writes a `did_assignment_audit` row and requires an
    /// admin-role account.
    /// </summary>
    /// <example><code>
    /// await client.PhoneNumbers.UnassignDidFromSubaccountAsync(
    ///     new UnassignDidFromSubaccountRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         E164 = "%2B919876543210",
    ///         Force = true,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask UnassignDidFromSubaccountAsync(
        UnassignDidFromSubaccountRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            UnassignDidFromSubaccountAsyncCore(request, options, cancellationToken)
        );
    }
}
