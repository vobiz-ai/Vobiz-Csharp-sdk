# Vobiz C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=Vobiz%2FC%23)

The Vobiz C# library provides convenient access to the Vobiz APIs from C#.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Reference](#reference)
- [Usage](#usage)
- [Environments](#environments)
- [Exception Handling](#exception-handling)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Raw Response](#raw-response)
  - [Additional Headers](#additional-headers)
  - [Additional Query Parameters](#additional-query-parameters)
  - [Forward Compatible Enums](#forward-compatible-enums)
- [Contributing](#contributing)

## Requirements

This SDK requires the .NET 8 SDK or later. The library targets `net8.0`, `netstandard2.0` and `net462`.

## Installation

The SDK is distributed from this GitHub repo, not NuGet. Clone it **next to** your project (not inside the project folder) and add a project reference:

```sh
dotnet new console -o MyApp        # or use your existing project
git clone https://github.com/vobiz-ai/Vobiz-Csharp-sdk.git
dotnet add MyApp reference Vobiz-Csharp-sdk/src/Vobiz/Vobiz.csproj
dotnet build MyApp
```

If you clone it inside your project folder, your project compiles the SDK's source files a second time and the build fails.

## Reference

A full reference for this library is available [here](./reference.md).

## Usage

Create the client with your Auth Token and Auth ID from the [Vobiz Console](https://console.vobiz.ai). Constructor order is `(authToken, authId)`:

```csharp
using Vobiz;

string authToken = Environment.GetEnvironmentVariable("VOBIZ_AUTH_TOKEN") ?? "YOUR_AUTH_TOKEN";
string authId = Environment.GetEnvironmentVariable("VOBIZ_AUTH_ID") ?? "MA_XXXXXXXX";

var client = new VobizApiClient(authToken, authId);

var recordings = await client.Recordings.ListRecordingsAsync(
    new ListRecordingsRequest { AuthId = authId }
);

foreach (var recording in recordings.Objects)
{
    Console.WriteLine(recording.CallUuid);
}
```

Full guide: [vobiz.ai/docs/integrations/csharp-sdk](https://www.vobiz.ai/docs/integrations/csharp-sdk).

## Environments

This SDK allows you to configure different environments for API requests.

```csharp
using Vobiz;

var client = new VobizApiClient(new ClientOptions
{
    BaseUrl = VobizApiEnvironment.Production
});
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using Vobiz;

try {
    var response = await client.Account.CreateChannelSubscriptionAsync(...);
} catch (VobizApiApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);

    // Access the raw HTTP response (status code, URL, headers) off the exception
    var rawResponse = e.RawResponse;
    if (rawResponse != null)
    {
        System.Console.WriteLine(rawResponse.Url);
        if (rawResponse.Headers.TryGetValue("X-Request-Id", out var requestId))
        {
            System.Console.WriteLine($"Request ID: {requestId}");
        }
    }
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

Which status codes are retried depends on the `retryStatusCodes` generator configuration:

**`legacy`** (current default): retries on
- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#server_error_responses) (All server errors, including 500)

**`recommended`**: retries on
- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [502](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/502) (Bad Gateway)
- [503](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/503) (Service Unavailable)
- [504](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/504) (Gateway Timeout)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Account.CreateChannelSubscriptionAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Account.CreateChannelSubscriptionAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using Vobiz;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.Account.CreateChannelSubscriptionAsync(...).WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    System.Console.WriteLine($"Request ID: {requestId}");
}

// For the default behavior, simply await without .WithRawResponse()
var data = await client.Account.CreateChannelSubscriptionAsync(...);

// .WithRawResponse() also works on streaming endpoints (returns IAsyncEnumerable<T> + RawResponse)
// and on endpoints with no response body (returns RawResponse only).
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.Account.CreateChannelSubscriptionAsync(
    ...,
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.Account.CreateChannelSubscriptionAsync(
    ...,
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully.

```csharp
using Vobiz;

// Using a built-in value
var listTransactionsRequestStatus = ListTransactionsRequestStatus.Completed;

// Using a custom value
var customListTransactionsRequestStatus = ListTransactionsRequestStatus.FromCustom("custom-value");

// Using in a switch statement
switch (listTransactionsRequestStatus.Value)
{
    case ListTransactionsRequestStatus.Values.Completed:
        Console.WriteLine("Completed");
        break;
    default:
        Console.WriteLine($"Unknown value: {listTransactionsRequestStatus.Value}");
        break;
}

// Explicit casting
string listTransactionsRequestStatusString = (string)ListTransactionsRequestStatus.Completed;
ListTransactionsRequestStatus listTransactionsRequestStatusFromString = (ListTransactionsRequestStatus)"completed";
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
