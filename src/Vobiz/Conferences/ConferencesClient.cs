using global::System.Text.Json;
using OneOf;
using Vobiz.Core;

namespace Vobiz;

public partial class ConferencesClient : IConferencesClient
{
    private readonly RawClient _client;

    internal ConferencesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<ListConferencesResponse>> ListConferencesAsyncCore(
        ListConferencesRequest request,
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
                        "api/v1/Account/{0}/Conference/",
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
                var responseData = JsonUtils.Deserialize<ListConferencesResponse>(responseBody)!;
                return new WithRawResponse<ListConferencesResponse>()
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

    private async Task<RawResponse> DeleteAllConferencesAsyncCore(
        DeleteAllConferencesRequest request,
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
                        "api/v1/Account/{0}/Conference/",
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

    private async Task<
        WithRawResponse<
            OneOf<GetConferenceResponseConferenceMemberCount, GetConferenceResponseError>
        >
    > GetConferenceAsyncCore(
        GetConferenceRequest request,
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
                        "api/v1/Account/{0}/Conference/{1}/",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.ConferenceName)
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
                var responseData = JsonUtils.Deserialize<
                    OneOf<GetConferenceResponseConferenceMemberCount, GetConferenceResponseError>
                >(responseBody)!;
                return new WithRawResponse<
                    OneOf<GetConferenceResponseConferenceMemberCount, GetConferenceResponseError>
                >()
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

    private async Task<RawResponse> DeleteConferenceAsyncCore(
        DeleteConferenceRequest request,
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
                        "api/v1/Account/{0}/Conference/{1}/",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.ConferenceName)
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

    /// <summary>
    /// Retrieve conference room names reported by the API. An empty array is inconclusive and can occur while conferences are active. Maintain your own room registry for authoritative discovery, billing, cleanup, and destructive workflows.
    /// </summary>
    /// <example><code>
    /// await client.Conferences.ListConferencesAsync(new ListConferencesRequest { AuthId = "MA_XXXXXX" });
    /// </code></example>
    public WithRawResponseTask<ListConferencesResponse> ListConferencesAsync(
        ListConferencesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListConferencesResponse>(
            ListConferencesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Terminate all active conference rooms.
    /// </summary>
    /// <example><code>
    /// await client.Conferences.DeleteAllConferencesAsync(
    ///     new DeleteAllConferencesRequest { AuthId = "MA_XXXXXX" }
    /// );
    /// </code></example>
    public WithRawResponseTask DeleteAllConferencesAsync(
        DeleteAllConferencesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            DeleteAllConferencesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a specific conference room. A live conference can currently return a 200 response with an error payload instead of conference details.
    /// </summary>
    /// <example><code>
    /// await client.Conferences.GetConferenceAsync(
    ///     new GetConferenceRequest { AuthId = "MA_XXXXXX", ConferenceName = "My Conf Room" }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        OneOf<GetConferenceResponseConferenceMemberCount, GetConferenceResponseError>
    > GetConferenceAsync(
        GetConferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            OneOf<GetConferenceResponseConferenceMemberCount, GetConferenceResponseError>
        >(GetConferenceAsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Terminate a specific conference room and disconnect all members.
    /// </summary>
    /// <example><code>
    /// await client.Conferences.DeleteConferenceAsync(
    ///     new DeleteConferenceRequest { AuthId = "MA_XXXXXX", ConferenceName = "conference_name" }
    /// );
    /// </code></example>
    public WithRawResponseTask DeleteConferenceAsync(
        DeleteConferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            DeleteConferenceAsyncCore(request, options, cancellationToken)
        );
    }
}
