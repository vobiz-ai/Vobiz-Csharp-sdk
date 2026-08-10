using global::System.Text.Json;
using Vobiz.Core;

namespace Vobiz;

public partial class BulkOperationsClient : IBulkOperationsClient
{
    private readonly RawClient _client;

    internal BulkOperationsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<BulkExportRecordingsResponse>> BulkExportRecordingsAsyncCore(
        BulkExportRecordingsRequest request,
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
                        "api/v1/Account/{0}/export/recording/",
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
                var responseData = JsonUtils.Deserialize<BulkExportRecordingsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<BulkExportRecordingsResponse>()
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
                    case 403:
                        throw new ForbiddenError(
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
    /// Queue a bulk export of the recordings matching your filter criteria. The request is
    /// validated and accepted for background processing, and the resulting archive is emailed
    /// as a download link to every address in `recipient.customer_account`. The archive is
    /// typically available within 15-60 minutes depending on volume.
    ///
    /// Results are delivered by email only; the export runs to completion in the background
    /// after the `202` response.
    ///
    /// One export runs at a time per account. While an export is in progress, further requests
    /// return `403`.
    ///
    /// Filter rules:
    /// - Use either `from`/`to` or the `recording_storage_duration*` filters, not both.
    /// - Use one of `__gt` or `__gte`, and one of `__lt` or `__lte`.
    /// - When using range filters (`__gte`/`__lte`), provide both.
    /// - Maximum date range is 1 year (366 days); maximum storage duration range is 30 days.
    /// - The additional filters (`from_number`, `to_number`, `call_uuid`, `conference_name`,
    ///   `recording_format`, `recording_id`) apply when the range is 30 days or less.
    /// </summary>
    /// <example><code>
    /// await client.BulkOperations.BulkExportRecordingsAsync(
    ///     new BulkExportRecordingsRequest
    ///     {
    ///         AuthId = "MA_XXXXXX",
    ///         Recipient = new BulkExportRecordingsRequestRecipient
    ///         {
    ///             CustomerAccount = new List&lt;string&gt;() { "admin@example.com" },
    ///         },
    ///         From = "2025-01-23 00:00:00",
    ///         To = "2025-01-30 23:59:59",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkExportRecordingsResponse> BulkExportRecordingsAsync(
        BulkExportRecordingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkExportRecordingsResponse>(
            BulkExportRecordingsAsyncCore(request, options, cancellationToken)
        );
    }
}
