using Vobiz.Core;

namespace Vobiz;

public partial class DtmfClient : IDtmfClient
{
    private readonly RawClient _client;

    internal DtmfClient(RawClient client)
    {
        _client = client;
    }

    private async Task<RawResponse> SendDtmfAsyncCore(
        SendDtmfRequest request,
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
                        "api/v1/Account/{0}/Call/{1}/DTMF/",
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

    /// <summary>
    /// Send DTMF (keypad) tones on an active call. Use `w` for 0.5s pause, `W` for 1s pause.
    /// </summary>
    /// <example><code>
    /// await client.Dtmf.SendDtmfAsync(
    ///     new SendDtmfRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         CallUuid = "call_uuid",
    ///         Digits = "1234",
    ///         Leg = SendDtmfRequestLeg.Aleg,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask SendDtmfAsync(
        SendDtmfRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(SendDtmfAsyncCore(request, options, cancellationToken));
    }
}
