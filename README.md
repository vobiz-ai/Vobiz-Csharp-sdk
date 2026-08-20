# Vobiz C# Library

Typed .NET client for the Vobiz programmable voice and SIP-trunking API, with a
`Vobiz.Xml` builder for call-control documents.

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)
[![.NET](https://img.shields.io/badge/.NET-net8.0%20%7C%20net9.0%20%7C%20netstandard2.0%20%7C%20net462-512BD4.svg)](https://dotnet.microsoft.com/)
[![Docs](https://img.shields.io/badge/docs-docs.vobiz.ai-3b82f6.svg)](https://docs.vobiz.ai)
[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=Vobiz%2FC%23)

## Overview

The Vobiz C# library is the official .NET client for the Vobiz REST API. It covers the
whole platform surface: placing and controlling calls, live-call inspection, in-call
actions such as text-to-speech, audio playback and DTMF, recordings, call detail
records, phone-number inventory, SIP trunks and endpoints, conferences, applications,
sub-accounts and KYC, IP access control lists, balance and the partner API.

The client is generated from the Vobiz OpenAPI specification with
[Fern](https://buildwithfern.com), so every sub-client, method, request record and
response model tracks the published API. Requests are `record` types with `required`
properties, so the compiler catches a missing `AnswerUrl` rather than the server
returning a 400. Every sub-client is exposed through an interface — `ICallsClient`,
`ICdrClient` and friends — which makes the whole surface straightforward to mock in
unit tests and to register with a DI container.

The package multi-targets `net8.0`, `net9.0`, `netstandard2.0` and `net462`, so it
works in modern ASP.NET Core services and in older .NET Framework applications alike.
Serialisation goes through `System.Text.Json`, with `OneOf` for union types and
`PolySharp` filling in language features on the older targets.

Alongside the API client the package ships `Vobiz.Xml`, a self-contained builder for
VobizXML — the XML call-control documents Vobiz fetches from your `answer_url` when a
call connects. It mirrors the `plivoxml` builder shape and emits XML byte-identical to
the Python, Node, Ruby and Go builders.

At the end of a first integration you should be able to place an outbound call from
C#, serve a VobizXML document that speaks a prompt and collects a DTMF digit, watch
the call in the live-calls list, and read the resulting CDR.

## Installation

The package is not yet on NuGet. Build it from source and reference the project:

```sh
git clone https://github.com/vobiz-ai/Vobiz-Csharp-sdk.git
cd Vobiz-Csharp-sdk
dotnet build
```

Then add a project reference from your application:

```sh
dotnet add reference ../Vobiz-Csharp-sdk/src/Vobiz/Vobiz.csproj
```

Or pack it locally and consume it as a package:

```sh
dotnet pack src/Vobiz/Vobiz.csproj -c Release -o ./nupkg
dotnet nuget add source ./nupkg --name vobiz-local
dotnet add package Vobiz
```

Supported target frameworks: `net8.0`, `net9.0`, `netstandard2.0` and `net462`. On the
`netstandard2.0` and `net462` targets the package pulls in
`Portable.System.DateTimeOnly` and a standalone `System.Text.Json`.

Once the package is published, `dotnet add package Vobiz` will resolve from
nuget.org — see [Roadmap](#roadmap).

## Authentication

Vobiz identifies your account with an **Auth ID** and an **Auth Token**, and
authorises the request with a **bearer token**. All three are constructor arguments,
and `VobizApiClient` sets them as headers on every request:

| Header | Constructor argument | Purpose |
| --- | --- | --- |
| `X-Auth-ID` | `authId` (1st, required) | Identifies the account or sub-account |
| `X-Auth-Token` | `authToken` (2nd, required) | Account secret paired with the Auth ID |
| `Authorization: Bearer <token>` | `token` (3rd, optional) | Bearer credential for the request |

```csharp
using Vobiz;

var client = new VobizApiClient(
    Environment.GetEnvironmentVariable("VOBIZ_AUTH_ID")!,
    Environment.GetEnvironmentVariable("VOBIZ_AUTH_TOKEN")!,
    Environment.GetEnvironmentVariable("VOBIZ_TOKEN")!
);
```

The constructor signature is
`VobizApiClient(string authId, string authToken, string? token = null, ClientOptions? clientOptions = null)`.
`authId` and `authToken` are positional and required; pass `clientOptions` as the
fourth argument when you need to change the base URL, HTTP client, retry count or
timeout:

```csharp
var client = new VobizApiClient(
    authId,
    authToken,
    token,
    new ClientOptions
    {
        BaseUrl = VobizApiEnvironment.Production,
        Timeout = TimeSpan.FromSeconds(60),
        MaxRetries = 3,
    }
);
```

Registering it with the ASP.NET Core DI container, so `IVobizApiClient` can be
injected and mocked in tests:

```csharp
builder.Services.AddSingleton<IVobizApiClient>(_ => new VobizApiClient(
    builder.Configuration["Vobiz:AuthId"]!,
    builder.Configuration["Vobiz:AuthToken"]!,
    builder.Configuration["Vobiz:Token"]!
));
```

Note the separate `AuthId` property on every request record. That is the account the
operation acts on and it goes into the URL path, which lets a parent account drive its
sub-accounts. It is usually the same value as the `X-Auth-ID` header.

Keep credentials in environment variables, user secrets or a secrets manager — never
in source. Sign up and find your credentials at [vobiz.ai](https://vobiz.ai); the
credential model is documented at
[docs.vobiz.ai/api-reference](https://docs.vobiz.ai/api-reference).

## Quickstart

Place an outbound call. Vobiz dials `To`, and when the callee answers it fetches your
`AnswerUrl` for a VobizXML document describing what should happen next.

```csharp
using Vobiz;

var authId = Environment.GetEnvironmentVariable("VOBIZ_AUTH_ID")!;

var client = new VobizApiClient(
    authId,
    Environment.GetEnvironmentVariable("VOBIZ_AUTH_TOKEN")!,
    Environment.GetEnvironmentVariable("VOBIZ_TOKEN")!
);

var response = await client.Calls.MakeCallAsync(
    new MakeCallRequest
    {
        AuthId = authId,
        From = "14155551234",
        To = "+15550003333",
        AnswerUrl = "https://example.com/answer",
        AnswerMethod = "POST",
    }
);

Console.WriteLine(response);
```

Conventions worth internalising before you write the second call:

- **Properties are PascalCase** — `AuthId`, `CallUuid`, `AnswerUrl`, `PerPage`. The
  snake_case JSON names underneath are handled by `[JsonPropertyName]` attributes.
- **Every method is `…Async` and takes a request record**, plus an optional
  `RequestOptions` and an optional `CancellationToken`.
- **Required properties use the C# `required` modifier**, so omitting `AnswerUrl` is a
  compile error rather than a runtime 400.
- `To` accepts multiple destinations separated by `<`, fanning a single request out to
  up to 1000 destinations, for example `"+15550003333<+15550004444"`.

## Common operations

Every snippet below reuses `client` and `authId` from the quickstart. Signatures come
from the generated sub-clients under [`src/Vobiz/`](./src/Vobiz); the exhaustive list
is in [`reference.md`](./reference.md).

### List live calls

`Status` is required. The generated enums are forward-compatible string enums.

```csharp
var live = await client.LiveCalls.ListLiveCallsAsync(
    new ListLiveCallsRequest
    {
        AuthId = authId,
        Status = ListLiveCallsRequestStatus.Live,   // or .Queued
    }
);

var detail = await client.LiveCalls.GetLiveCallAsync(
    new GetLiveCallRequest
    {
        AuthId = authId,
        CallUuid = "cdr_XXXXXXXXXX",
        Status = GetLiveCallRequestStatus.Live,
    }
);
```

`ListQueuedCallsAsync` and `GetQueuedCallAsync` mirror these for the queued set.

### Hang up a call

```csharp
await client.LiveCalls.HangupCallAsync(
    new HangupCallRequest { AuthId = authId, CallUuid = "cdr_XXXXXXXXXX" }
);
```

`HangupCallAsync` returns a `WithRawResponseTask` with no payload — a successful
termination has no response body.

### Speak text and play audio into a live call

```csharp
await client.SpeakText.CallAsync(
    new SpeakTextCallRequest
    {
        AuthId = authId,
        CallUuid = "cdr_XXXXXXXXXX",
        Text = "Your driver is two minutes away.",
        Legs = SpeakTextCallRequestLegs.Aleg,
        Voice = "female",
        Language = "en-US",
    }
);

await client.PlayAudio.CallAsync(
    new PlayAudioCallRequest
    {
        AuthId = authId,
        CallUuid = "cdr_XXXXXXXXXX",
        Urls = "https://cdn.example.com/hold-music.mp3",
        Loop = true,
    }
);

await client.SpeakText.StopSpeakCallAsync(
    new StopSpeakCallRequest { AuthId = authId, CallUuid = "cdr_XXXXXXXXXX" }
);
await client.PlayAudio.StopAudioCallAsync(
    new StopAudioCallRequest { AuthId = authId, CallUuid = "cdr_XXXXXXXXXX" }
);
```

### Send DTMF

```csharp
await client.Dtmf.SendDtmfAsync(
    new SendDtmfRequest
    {
        AuthId = authId,
        CallUuid = "cdr_XXXXXXXXXX",
        Digits = "1234#",
        Leg = SendDtmfRequestLeg.Aleg,   // Aleg | Bleg | Both
    }
);
```

### Record a call and fetch the recording

```csharp
await client.RecordCalls.StartRecordingAsync(
    new StartRecordingRequest
    {
        AuthId = authId,
        CallUuid = "cdr_XXXXXXXXXX",
        FileFormat = StartRecordingRequestFileFormat.Mp3,           // Mp3 | Wav
        RecordChannelType = StartRecordingRequestRecordChannelType.Stereo,
        TimeLimit = 600,
        TranscriptionType = "auto",
        CallbackUrl = "https://example.com/recording-ready",
    }
);

await client.RecordCalls.StopRecordingAsync(
    new StopRecordingRequest { AuthId = authId, CallUuid = "cdr_XXXXXXXXXX" }
);

var recordings = await client.Recordings.ListRecordingsAsync(
    new ListRecordingsRequest { AuthId = authId, Limit = 20, Offset = 0 }
);
await client.Recordings.GetRecordingAsync(
    new GetRecordingRequest { AuthId = authId, RecordingId = "REC_ID" }
);
await client.Recordings.DeleteRecordingAsync(
    new DeleteRecordingRequest { AuthId = authId, RecordingId = "REC_ID" }
);
```

`StartRecordingAsync` returns `object` because the response shape is not modelled;
`StopRecordingAsync` and `DeleteRecordingAsync` return no payload.

### Query call detail records

`StartDate` and `EndDate` are `DateOnly?` values serialised as `YYYY-MM-DD`, and each
is required when the other is set.

```csharp
var page = await client.Cdr.ListCdrsAsync(
    new ListCdrsRequest
    {
        AuthId = authId,
        StartDate = new DateOnly(2026, 1, 1),
        EndDate = new DateOnly(2026, 1, 31),
        CallDirection = ListCdrsRequestCallDirection.Outbound,
        MinDuration = 30,
        Page = 1,
        PerPage = 100,   // max 100
    }
);

var recent = await client.Cdr.ListRecentCdrsAsync(
    new ListRecentCdrsRequest { AuthId = authId, Limit = 25 }
);
var one = await client.Cdr.GetCdrAsync(
    new GetCdrRequest { AuthId = authId, CallId = "CALL_ID" }
);
```

`SearchCdrsAsync` takes the same filters as `ListCdrsAsync`. `ExportCdrsAsync` takes
the same filters without the paging properties and returns a `System.IO.Stream`, so
stream it straight to disk rather than buffering it:

```csharp
await using var export = await client.Cdr.ExportCdrsAsync(
    new ExportCdrsRequest { AuthId = authId, StartDate = new DateOnly(2026, 1, 1) }
);
await using var file = File.Create("cdrs.csv");
await export.CopyToAsync(file);
```

Other filters on all three: `FromNumber`, `ToNumber`, `SipCallId`, `BridgeUuid`,
`HangupCause`, `HangupDisposition`, `Context`, `CampaignId` and free-text `Search`.

### Other resource groups

The same pattern — `client.<Group>.<Method>Async(new <Method>Request { ... })` —
covers `Account`, `Balance`, `PhoneNumbers`, `Applications`, `Trunks`, `Endpoints`,
`Credentials`, `Conference`, `Conferences`, `ConferenceMembers`,
`ConferenceRecording`, `AudioStreams`, `SubAccounts`, `SubAccountKyc`,
`SubAccountKycTestMode`, `BulkOperations`, `IpAccessControlList`, `OriginationUri` and
`PartnerApi`. See [`reference.md`](./reference.md) for every signature.

## VobizXML

`Vobiz.Xml` builds the call-control documents Vobiz fetches from your `answer_url`. It
is a single self-contained file with no dependency on the rest of the SDK, so you can
use it in a controller without constructing an API client.

```csharp
using Vobiz.Xml;

var response = new ResponseElement();

var gather = response.AddGather(new Attrs
{
    { "action", "https://example.com/menu" },
    { "method", "POST" },
    { "inputType", "dtmf" },
    { "numDigits", 1 },
    { "executionTimeout", 10 },
});
gather.AddSpeak("Press 1 for sales, or 2 for support.");

response.AddSpeak("We did not receive any input. Goodbye.");
response.AddHangup();

Console.WriteLine(response.ToString());
```

That prints:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Response>
    <Gather action="https://example.com/menu" method="POST" inputType="dtmf" numDigits="1" executionTimeout="10">
        <Speak>Press 1 for sales, or 2 for support.</Speak>
    </Gather>
    <Speak>We did not receive any input. Goodbye.</Speak>
    <Hangup/>
</Response>
```

Points worth knowing:

- **`Attrs` is an ordered collection, not a `Dictionary`.** It supports
  collection-initialiser syntax and preserves insertion order, so the rendered
  attribute order is deterministic.
- **Attribute keys are the camelCase VobizXML names, used verbatim** — `inputType`,
  `executionTimeout`, `numDigits`, `callerId`, `startConferenceOnEnter`, `sendDigits`,
  `audioTrack`. `<Gather>` uses `executionTimeout`, never `timeout`.
- **Values are `object?`.** Booleans render as `true`/`false`, `null` entries are
  skipped at render time, and text plus attribute values are XML escaped for you.
- **`Add*` helpers return the child element**, so you can keep nesting:
  `response.AddDial().AddNumber("+15550003333")`.
- **`ssml:` injects raw, unescaped content** into `<Speak>` when you need SSML markup.
- **`ToString(pretty: false)` emits the document on a single line**, and `ToXml(bool)`
  is a convenience alias for the same thing.

Builder classes: `ResponseElement`, `SpeakElement`, `PlayElement`, `WaitElement`,
`GatherElement`, `DialElement`, `NumberElement`, `UserElement`, `RecordElement`,
`ConferenceElement`, `DtmfElement`, `RedirectElement`, `HangupElement`,
`PreAnswerElement` and `StreamElement`.

Migrating from Plivo? `AddGetDigits()` and `AddGetInput()` are kept as aliases for
`AddGather()`.

Serving it from ASP.NET Core:

```csharp
app.MapPost("/answer", () =>
{
    var r = new ResponseElement();
    r.AddSpeak("Thanks for calling. Connecting you now.");
    r.AddDial().AddNumber("+15550003333");

    return Results.Content(r.ToString(pretty: false), "application/xml");
});
```

## Configuration

### Environments and base URL

The client targets production by default. Set `BaseUrl` on `ClientOptions` to point at
a proxy, a gateway or a local mock:

```csharp
var client = new VobizApiClient(authId, authToken, token, new ClientOptions
{
    BaseUrl = VobizApiEnvironment.Production,   // https://api.vobiz.ai
});

var local = new VobizApiClient(authId, authToken, token, new ClientOptions
{
    BaseUrl = "http://localhost:8080",
});
```

### `ClientOptions`

| Property | Type | Default | Description |
| --- | --- | --- | --- |
| `BaseUrl` | `string` | `VobizApiEnvironment.Production` | API base URL |
| `HttpClient` | `HttpClient` | `new HttpClient()` | Bring your own, e.g. from `IHttpClientFactory` |
| `AdditionalHeaders` | `IEnumerable<KeyValuePair<string, string?>>` | empty | Extra headers on every request |
| `MaxRetries` | `int` | `2` | Default retry attempts |
| `Timeout` | `TimeSpan` | 30 seconds | Default per-request timeout |

Supplying an `HttpClient` from `IHttpClientFactory` is worth doing in a long-running
service, so socket handles are pooled and DNS changes are picked up:

```csharp
builder.Services.AddHttpClient("vobiz");

builder.Services.AddSingleton<IVobizApiClient>(sp => new VobizApiClient(
    authId,
    authToken,
    token,
    new ClientOptions
    {
        HttpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("vobiz"),
    }
));
```

### `RequestOptions`

Every method takes an optional `RequestOptions` as its second argument, overriding the
client-level value for that call only.

| Property | Type | Description |
| --- | --- | --- |
| `BaseUrl` | `string?` | Override the base URL for this request |
| `HttpClient` | `HttpClient?` | Override the HTTP client for this request |
| `AdditionalHeaders` | `IEnumerable<KeyValuePair<string, string?>>` | Extra headers |
| `AdditionalQueryParameters` | `IEnumerable<KeyValuePair<string, string>>` | Extra query parameters |
| `AdditionalBodyProperties` | `object?` | Extra JSON body properties |
| `MaxRetries` | `int?` | Override the retry count |
| `Timeout` | `TimeSpan?` | Override the timeout |

```csharp
var response = await client.Cdr.ListCdrsAsync(
    new ListCdrsRequest { AuthId = authId, PerPage = 100 },
    new RequestOptions
    {
        Timeout = TimeSpan.FromSeconds(120),
        MaxRetries = 1,
        AdditionalHeaders = new Dictionary<string, string?> { { "X-Trace-Id", traceId } },
    },
    cancellationToken
);
```

### Retries

Requests are retried with exponential backoff on **408**, **429** and all **5xx**
responses, twice by default. Set `MaxRetries = 0` to disable retries — worth doing for
non-idempotent operations where a duplicate would be worse than a failure.

### Cancellation

Every method takes a `CancellationToken` as its final argument, so a request
participates in the caller's cancellation chain:

```csharp
await client.Calls.MakeCallAsync(request, options: null, cancellationToken);
```

### Forward-compatible enums

Generated enums are `readonly record struct` types implementing `IStringEnum`, so an
unrecognised value from the server round-trips instead of throwing:

```csharp
// Built-in value
var status = ListQueuedCallsRequestStatus.Live;

// Custom value
var custom = ListQueuedCallsRequestStatus.FromCustom("custom-value");

// Switching
switch (status.Value)
{
    case ListQueuedCallsRequestStatus.Values.Live:
        Console.WriteLine("Live");
        break;
    default:
        Console.WriteLine($"Unknown value: {status.Value}");
        break;
}

// Explicit casting both ways
string asString = (string)ListQueuedCallsRequestStatus.Live;
ListQueuedCallsRequestStatus fromString = (ListQueuedCallsRequestStatus)"live";
```

## Error handling

Every exception thrown by the SDK derives from `VobizApiException`. Non-2xx responses
throw `VobizApiApiException`, which carries `StatusCode`, `Body` and the raw response:

```csharp
using Vobiz;

try
{
    var response = await client.Calls.MakeCallAsync(request);
}
catch (VobizApiApiException e)
{
    Console.WriteLine(e.StatusCode);
    Console.WriteLine(e.Body);

    var rawResponse = e.RawResponse;
    if (rawResponse != null)
    {
        Console.WriteLine(rawResponse.Url);
        if (rawResponse.Headers.TryGetValue("X-Request-Id", out var requestId))
        {
            Console.WriteLine($"Request ID: {requestId}");
        }
    }
}
```

Status-specific subclasses let you branch without inspecting `StatusCode`:

| Exception | Status | Typical cause |
| --- | --- | --- |
| `BadRequestError` | 400 | Malformed or missing parameters |
| `UnauthorizedError` | 401 | Wrong Auth ID, Auth Token or bearer token |
| `ForbiddenError` | 403 | Credentials valid, operation not permitted |
| `NotFoundError` | 404 | Unknown call UUID, recording ID or account |
| `ConflictError` | 409 | Resource already exists or is in use |
| `UnprocessableEntityError` | 422 | Understood but semantically invalid |
| `TooManyRequestsError` | 429 | Rate limited |
| `InternalServerError` | 500 | Server-side failure |

```csharp
try
{
    await client.LiveCalls.GetLiveCallAsync(request);
}
catch (NotFoundError)
{
    // the call has already ended
}
catch (TooManyRequestsError e)
{
    // back off; inspect e.RawResponse?.Headers for retry hints
}
```

Order the `catch` blocks narrowest first — `VobizApiApiException` catches all of the
above, and `VobizApiException` catches everything the SDK throws.

### Raw response data

Every method returns a `WithRawResponseTask<T>`. Await it directly for the parsed
payload, or call `.WithRawResponse()` to get the status code, headers and URL as well:

```csharp
var result = await client.Cdr
    .ListCdrsAsync(new ListCdrsRequest { AuthId = authId, PerPage = 10 })
    .WithRawResponse();

var data = result.Data;
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    Console.WriteLine($"Request ID: {requestId}");
}
```

`.WithRawResponse()` also works on streaming endpoints, where it returns an
`IAsyncEnumerable<T>` alongside the raw response, and on endpoints with no response
body, where it returns the raw response only.

## Pagination and async

The SDK is asynchronous throughout; there is no synchronous variant.

Listing methods paginate explicitly; there is no auto-paging iterator, so you drive
the loop yourself. Two conventions are in use:

- **`Page` / `PerPage`** — `Cdr.ListCdrsAsync`, `Cdr.SearchCdrsAsync` (`PerPage` max 100)
- **`Limit` / `Offset`** — `Recordings.ListRecordingsAsync`;
  `Cdr.ListRecentCdrsAsync` takes `Limit` only

`ListCdrsResponse.Data` is an `IEnumerable<ListCdrsResponseDataItem>`, so enumerate it
rather than indexing into it:

```csharp
for (var page = 1; ; page++)
{
    var result = await client.Cdr.ListCdrsAsync(
        new ListCdrsRequest { AuthId = authId, Page = page, PerPage = 100 }
    );

    if (!result.Data.Any())
    {
        break;
    }

    foreach (var row in result.Data)
    {
        // ...
    }
}
```

Build one client and reuse it so the underlying `HttpClient` pools connections. When
fanning out, bound the concurrency so you do not trip the rate limit:

```csharp
await Parallel.ForEachAsync(
    callUuids,
    new ParallelOptions { MaxDegreeOfParallelism = 8 },
    async (callUuid, ct) =>
        await client.LiveCalls.HangupCallAsync(
            new HangupCallRequest { AuthId = authId, CallUuid = callUuid },
            options: null,
            ct
        )
);
```

## Troubleshooting

| Symptom | Likely cause | Fix |
| --- | --- | --- |
| `CS7036: There is no argument given that corresponds to the required parameter 'authId'` | The constructor takes `authId` and `authToken` positionally before `clientOptions` | Use `new VobizApiClient(authId, authToken, token, clientOptions)` |
| `CS9035: Required member 'MakeCallRequest.AnswerUrl' must be set` | Request records use the C# `required` modifier | Set every required property in the object initialiser |
| `401` on every request | Auth ID, Auth Token or bearer token is wrong, or the `token` argument was omitted so `Authorization: Bearer` is sent empty | Pass all three; confirm `BaseUrl` targets the intended host |
| `404` from `GetLiveCallAsync` or `HangupCallAsync` | The call has already ended, so it is no longer in the live-call set | Treat 404 as "already finished"; look it up with `client.Cdr.GetCdrAsync(...)` instead |
| `TaskCanceledException` on a long CDR export | Default 30 second timeout is shorter than the server needs | Raise it: `new RequestOptions { Timeout = TimeSpan.FromMinutes(5) }` |
| `TooManyRequestsError` during a bulk loop | Requests are issued faster than the account's rate allowance | Bound `MaxDegreeOfParallelism`; the SDK already retries twice |
| `SocketException` or stale DNS in a long-running service | A `new HttpClient()` per client instance, or a client rebuilt per request | Reuse one `VobizApiClient`, and supply an `HttpClient` from `IHttpClientFactory` |
| `CS0246: The type or namespace name 'ResponseElement' could not be found` | The XML builder lives in its own namespace | Add `using Vobiz.Xml;` |
| `DateOnly` unavailable on `net462` / `netstandard2.0` | Those targets use `Portable.System.DateTimeOnly` | The package reference is already declared; ensure NuGet restore has run |
| `<Gather>` never fires the `action` callback | `timeout` was used instead of `executionTimeout` | Use `{ "executionTimeout", 10 }` in the `Attrs` initialiser |
| VobizXML renders as escaped text in the browser | The response was served as `text/html` | Return `Results.Content(xml, "application/xml")` |

## Other Vobiz SDKs

| Language | Repository | Package name |
| --- | --- | --- |
| Python | [Vobiz-Python-SDK](https://github.com/vobiz-ai/Vobiz-Python-SDK) | `vobiz` |
| Node.js / TypeScript | [Vobiz-Node-SDK](https://github.com/vobiz-ai/Vobiz-Node-SDK) | `@vobiz/sdk` |
| Go | [Vobiz-Go-SDK](https://github.com/vobiz-ai/Vobiz-Go-SDK) | `github.com/vobiz-ai/Vobiz-Go-SDK` |
| Ruby | [Vobiz-Ruby-SDK](https://github.com/vobiz-ai/Vobiz-Ruby-SDK) | `vobiz` |

All of them are generated from the same OpenAPI specification, so resource groups and
method names line up across languages once you allow for naming conventions.

## Versioning and stability

`Vobiz.Version.Current` is `0.0.0`, and there are no published releases yet. Reference
the project directly, or pin an exact commit, and review the diff before upgrading.

The API surface is regenerated from the Vobiz OpenAPI specification, so sub-client and
method names can change when the specification changes. `Vobiz.Xml` is hand-written
and follows the `plivoxml` shape; it is the more stable half of the package.

## Roadmap

> Planned improvements to this library. Ideas and pull requests are welcome —
> open an issue to discuss anything here.

- [ ] Publish the `Vobiz` package to NuGet with real package metadata — version,
      authors, description, repository URL and release notes — so
      `dotnet add package Vobiz` resolves from nuget.org.
- [ ] Adopt semantic versioning guarantees from `1.0.0` onward, with a documented
      deprecation window for generated method renames.
- [ ] A `services.AddVobiz(...)` extension for `IServiceCollection`, wiring the client
      to `IHttpClientFactory` and configuration binding in one call.
- [ ] Auto-paging `IAsyncEnumerable<T>` helpers for `Cdr.ListCdrsAsync` and
      `Recordings.ListRecordingsAsync`, so callers stop hand-rolling loops.
- [ ] Model the `StartRecordingAsync` response instead of returning `object`.
- [ ] Webhook signature verification helpers, so `answer_url` and callback handlers
      can validate that a request genuinely came from Vobiz.
- [ ] Extend [`src/Vobiz.Test`](./src/Vobiz.Test) to cover the `Vobiz.Xml` builder
      alongside the generated request and response tests.

## Contributing

While we value open-source contributions to this SDK, this library is generated
programmatically. Additions made directly to this library would have to be moved over
to our generation code, otherwise they would be overwritten upon the next generated
release. Feel free to open a PR as a proof of concept, but know that we will not be
able to merge it as-is. We suggest opening an issue first to discuss with us!

On the other hand, contributions to the README and to the hand-written
[`src/Vobiz/Xml/VobizXml.cs`](./src/Vobiz/Xml/VobizXml.cs) builder are always very
welcome. See [CONTRIBUTING.md](./CONTRIBUTING.md) for details.

To check your changes locally:

```sh
dotnet build
dotnet test
```

## License

Released under the [MIT License](./LICENSE) © Vobiz.

MIT is permissive: you may use, modify, and redistribute this code, including in
closed-source commercial products, provided the copyright notice and licence text
are retained. There is no warranty. If your organisation needs a different
licensing arrangement, contact [piyush@vobiz.ai](mailto:piyush@vobiz.ai).

## Built by Team Vobiz

[Vobiz](https://vobiz.ai) is a programmable voice and SIP-trunking platform for
voice APIs, SIP trunking, and AI voice agents. This repository is built and
maintained by the Vobiz team.

**Maintainer:** Piyush Sahoo — [piyush@vobiz.ai](mailto:piyush@vobiz.ai) · [LinkedIn](https://www.linkedin.com/in/piyush-s713/)

Questions, or want to talk through an integration? Open an issue on this repo,
or reach out directly at [piyush@vobiz.ai](mailto:piyush@vobiz.ai).

**Useful links:** [Docs](https://docs.vobiz.ai) · [API reference](https://docs.vobiz.ai/api-reference) · [Sign up](https://vobiz.ai)
