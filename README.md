# Vobiz C# SDK

The official C#/.NET SDK for [Vobiz](https://vobiz.ai) — the AI-first voice & telephony API platform for builders. Make and control calls, manage SIP trunks, phone numbers, conferences, and recordings directly from .NET, with async methods and built-in retries.

## Quick links

- 📚 **Documentation:** https://docs.vobiz.ai
- 🔑 **Dashboard & credentials:** https://console.vobiz.ai
- 🧾 **Full API reference:** [`./reference.md`](./reference.md)
- ⚡ **Usage cheat-sheet:** [`./USAGE.md`](./USAGE.md)

## Installation

Install from NuGet:

```sh
dotnet add package Vobiz
```

Or add a `PackageReference` to your `.csproj`:

```xml
<PackageReference Include="Vobiz" Version="*" />
```

## Authentication

Authenticate with your account **Auth Token** and **Auth ID** (from the
[dashboard](https://console.vobiz.ai)) — they map to the `X-Auth-Token` and
`X-Auth-ID` headers.

```csharp
using Vobiz;

// constructor order: (authToken, authId)
var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");
```

## Quickstart — make a call

```csharp
using Vobiz;

var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");

await client.Calls.MakeCallAsync(
    new MakeCallRequest
    {
        AuthId = "YOUR_AUTH_ID",
        From = "14155551234",
        To = "+919876543210",
        AnswerUrl = "https://example.com/answer", // returns VobizXML
        AnswerMethod = "POST",
    }
);
```

When the callee answers, Vobiz fetches `AnswerUrl`, which should return
[VobizXML](https://docs.vobiz.ai/xml-builder) describing the call flow.

## What you can do

| Area | Client property |
|------|-----------------|
| Calls & live calls | `client.Calls`, `client.LiveCalls` |
| In-call actions | `client.PlayAudio`, `client.SpeakText`, `client.Dtmf`, `client.RecordCalls` |
| Call detail records | `client.Cdr` |
| Recordings | `client.Recordings` |
| Phone numbers | `client.PhoneNumbers` |
| Trunks / endpoints / credentials | `client.Trunks`, `client.Endpoints`, `client.Credentials` |
| Conferences | `client.Conference`, `client.Conferences`, `client.ConferenceMembers` |
| Applications | `client.Applications` |
| Sub-accounts & KYC | `client.SubAccounts`, `client.SubAccountKyc` |
| Account & balance | `client.Account`, `client.Balance` |

All methods are asynchronous (`...Async`) and return a `Task`. See
[`USAGE.md`](./USAGE.md) for more examples.

## Error handling

Automatic retries with exponential backoff are built in. Use standard
`try`/`catch` around `await` calls to handle API errors:

```csharp
try
{
    await client.Account.RetrieveAccountAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## Other SDKs

Vobiz ships official SDKs across languages — all under
[github.com/vobiz-ai](https://github.com/vobiz-ai/):

| Language | Repository |
|----------|------------|
| TypeScript / Node | [Vobiz-Node-SDK](https://github.com/vobiz-ai/Vobiz-Node-SDK) |
| Python | [Vobiz-Python-SDK](https://github.com/vobiz-ai/Vobiz-Python-SDK) |
| Go | [Vobiz-Go-SDK](https://github.com/vobiz-ai/Vobiz-Go-SDK) |
| Java | [Vobiz-Java-SDK](https://github.com/vobiz-ai/Vobiz-Java-SDK) |
| Ruby | [Vobiz-Ruby-SDK](https://github.com/vobiz-ai/Vobiz-Ruby-SDK) |
| PHP | [Vobiz-PHP-SDK](https://github.com/vobiz-ai/Vobiz-PHP-SDK) |

## License

MIT
