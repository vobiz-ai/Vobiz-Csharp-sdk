using Vobiz.Core;

namespace Vobiz;

public partial class PlayAudioClient : IPlayAudioClient
{
    private readonly RawClient _client;

    internal PlayAudioClient(RawClient client)
    {
        _client = client;
    }

    private async Task<RawResponse> CallAsyncCore(
        PlayAudioCallRequest request,
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
                        "api/v1/Account/{0}/Call/{1}/Play/",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.CallUuid)
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

    private async Task<RawResponse> StopAudioCallAsyncCore(
        StopAudioCallRequest request,
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
                        "api/v1/Account/{0}/Call/{1}/Play/",
                        ValueConvert.ToPathParameterString(request.AuthId),
                        ValueConvert.ToPathParameterString(request.CallUuid)
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
    /// Play an audio file to a live call leg.
    /// </summary>
    /// <example><code>
    /// await client.PlayAudio.CallAsync(
    ///     new PlayAudioCallRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         CallUuid = "call_uuid",
    ///         Urls = "https://example.com/audio.mp3",
    ///         Legs = PlayAudioCallRequestLegs.Aleg,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask CallAsync(
        PlayAudioCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(CallAsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Stop audio playing on a live call.
    /// </summary>
    /// <example><code>
    /// await client.PlayAudio.StopAudioCallAsync(
    ///     new StopAudioCallRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
    /// );
    /// </code></example>
    public WithRawResponseTask StopAudioCallAsync(
        StopAudioCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(StopAudioCallAsyncCore(request, options, cancellationToken));
    }
}
