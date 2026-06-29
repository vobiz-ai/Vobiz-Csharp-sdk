using Vobiz.Core;

namespace Vobiz;

public partial class ConferenceMembersClient : IConferenceMembersClient
{
    private readonly RawClient _client;

    internal ConferenceMembersClient(RawClient client)
    {
        _client = client;
    }

    private async Task<RawResponse> MuteMemberAsyncCore(
        MuteMemberRequest request,
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
                        "api/v1/Account/{0}/Conference/{1}/Member/{2}/Mute/",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.ConferenceName),
                        ValueConvert.ToPathParameterString(request.MemberId)
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

    private async Task<RawResponse> UnmuteMemberAsyncCore(
        UnmuteMemberRequest request,
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
                        "api/v1/Account/{0}/Conference/{1}/Member/{2}/Mute/",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.ConferenceName),
                        ValueConvert.ToPathParameterString(request.MemberId)
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
    /// Prevent a member from speaking. Use `all` as member_id to mute everyone.
    /// </summary>
    /// <example><code>
    /// await client.ConferenceMembers.MuteMemberAsync(
    ///     new MuteMemberRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         ConferenceName = "conference_name",
    ///         MemberId = "member_id",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask MuteMemberAsync(
        MuteMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(MuteMemberAsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Allow a muted member to speak again.
    /// </summary>
    /// <example><code>
    /// await client.ConferenceMembers.UnmuteMemberAsync(
    ///     new UnmuteMemberRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         ConferenceName = "conference_name",
    ///         MemberId = "member_id",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask UnmuteMemberAsync(
        UnmuteMemberRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(UnmuteMemberAsyncCore(request, options, cancellationToken));
    }
}
