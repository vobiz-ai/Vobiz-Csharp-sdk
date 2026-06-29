using global::System.Text.Json;
using Vobiz.Core;

namespace Vobiz;

public partial class CallsClient : ICallsClient
{
    private readonly RawClient _client;

    internal CallsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<MakeCallResponse>> MakeCallAsyncCore(
        MakeCallRequest request,
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
                        "api/v1/Account/{0}/Call/",
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
                var responseData = JsonUtils.Deserialize<MakeCallResponse>(responseBody)!;
                return new WithRawResponse<MakeCallResponse>()
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
    /// Initiate an outbound call to a PSTN number or SIP endpoint.
    /// Use `&lt;` to separate multiple destinations (max 1000).
    /// </summary>
    /// <example><code>
    /// await client.Calls.MakeCallAsync(
    ///     new MakeCallRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         From = "14155551234",
    ///         To = "+919876543210",
    ///         AnswerUrl = "https://example.com/answer",
    ///         AnswerMethod = "POST",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<MakeCallResponse> MakeCallAsync(
        MakeCallRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<MakeCallResponse>(
            MakeCallAsyncCore(request, options, cancellationToken)
        );
    }
}
