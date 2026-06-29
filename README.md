# Vobiz C# SDK

The official C#/.NET SDK for [Vobiz](https://vobiz.ai) — the AI-first voice & telephony API platform for builders. Integrate powerful telephony features directly into your .NET applications to make and control calls, manage SIP trunks, provision phone numbers, coordinate conferences, and handle call recordings with ease.

## Quick links

- 📚 **Documentation:** [docs.vobiz.ai](https://docs.vobiz.ai)
- 🔑 **Dashboard & credentials:** [console.vobiz.ai](https://console.vobiz.ai)
- 🧾 **Full API reference:** [`./reference.md`](./reference.md)
- ⚡ **Usage cheat-sheet:** [`./USAGE.md`](./USAGE.md)

## Features

The Vobiz C# SDK provides comprehensive access to the Vobiz platform's capabilities:

- **Programmatic Call Control:** Initiate outbound calls, manage live calls, and hang up calls.
- **In-Call Actions:** Play audio, convert text to speech, send DTMF tones, and control call recordings dynamically.
- **Call Detail Records (CDRs):** Retrieve and search historical call records with extensive filtering options.
- **Recording Management:** List, retrieve, and delete call recordings.
- **Phone Number Management:** List available numbers, purchase from inventory, and assign/unassign numbers to SIP trunks or sub-accounts.
- **SIP Trunk & Endpoint Management:** Configure SIP trunks, manage credentials, and control IP access lists.
- **Conference Management:** Create, list, retrieve, and terminate conference rooms, and manage individual conference members.
- **Sub-Account & KYC Management:** Create and manage sub-accounts, and perform KYC verifications.

## Requirements

The Vobiz C# SDK targets **.NET Standard 2.0**, making it compatible with:

- .NET Core 2.0+ / .NET 5.0+
- .NET Framework 4.6.1+
- Mono 5.4+
- Xamarin.iOS 10.14+
- Xamarin.Android 8.0+
- UWP 10.0.16299+

## Installation

Install the Vobiz C# SDK from NuGet using the .NET CLI:

```sh
dotnet add package Vobiz
```

Alternatively, you can add a `PackageReference` directly to your `.csproj` file:

```xml
<PackageReference Include="Vobiz" Version="*" />
```

## Authentication

To authenticate your requests with the Vobiz API, you need your **Auth Token** and **Auth ID**. These credentials can be found in your [Vobiz Dashboard](https://console.vobiz.ai). The SDK uses these credentials to set the `X-Auth-Token` and `X-Auth-ID` HTTP headers for each API request.

It is highly recommended to load your credentials from environment variables rather than hardcoding them in your application.

```csharp
using Vobiz;
using System;

// Load credentials from environment variables
string authToken = Environment.GetEnvironmentVariable("VOBIZ_AUTH_TOKEN") ?? "YOUR_AUTH_TOKEN";
string authId = Environment.GetEnvironmentVariable("VOBIZ_AUTH_ID") ?? "YOUR_AUTH_ID";

// Initialize the VobizApiClient
var client = new VobizApiClient(authToken, authId);
```

## Quickstart

This example demonstrates how to initiate an outbound call using the `MakeCallAsync` method. When the recipient answers, Vobiz will fetch the `AnswerUrl` you provide, which should return VobizXML to define the call flow.

```csharp
using Vobiz;
using System;
using System.Threading.Tasks;

public class Quickstart
{
    public static async Task Main(string[] args)
    {
        string authToken = Environment.GetEnvironmentVariable("VOBIZ_AUTH_TOKEN") ?? "YOUR_AUTH_TOKEN";
        string authId = Environment.GetEnvironmentVariable("VOBIZ_AUTH_ID") ?? "YOUR_AUTH_ID";

        var client = new VobizApiClient(authToken, authId);

        try
        {
            Console.WriteLine("Initiating call...");
            var response = await client.Calls.MakeCallAsync(
                new MakeCallRequest
                {
                    AuthId = authId,
                    From = "14155551234", // Your Vobiz-enabled phone number
                    To = "+919876543210", // Recipient's phone number
                    AnswerUrl = "https://example.com/answer", // URL for VobizXML
                    AnswerMethod = "POST",
                }
            );
            
            // The response object contains details like the CallUuid
            Console.WriteLine($"Call initiated successfully. Call UUID: {response.CallUuid}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error making call: {ex.Message}");
        }
    }
}
```

## Common operations

Below are several examples of common operations. For a complete list of methods and their parameters, see [`reference.md`](./reference.md).

### Convert Text to Speech (TTS) on a Live Call

Convert text to speech and play it to a live call leg using the `SpeakText.CallAsync` method.

```csharp
using Vobiz;
using System;
using System.Threading.Tasks;

var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");
const string authId = "YOUR_AUTH_ID";

await client.SpeakText.CallAsync(
    new SpeakTextCallRequest
    {
        AuthId = authId,
        CallUuid = "call_uuid_here",
        Text = "Hello, your appointment is confirmed for tomorrow at 3 PM.",
        Voice = "WOMAN",
        Language = "en-US",
    }
);
```

### Create a SIP Trunk

Configure a new SIP trunk for inbound or outbound calling.

```csharp
using Vobiz;
using System;
using System.Threading.Tasks;

var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");
const string authId = "YOUR_AUTH_ID";

var trunkResponse = await client.Trunks.CreateTrunkAsync(
    new CreateTrunkRequest
    {
        AuthId = authId,
        Name = "My Outbound Trunk",
        TrunkType = "OUTBOUND",
        MaxConcurrentCalls = 10,
    }
);

Console.WriteLine($"Trunk created with ID: {trunkResponse.TrunkId}");
```

### List Call Recordings

Retrieve all call recordings associated with your account.

```csharp
using Vobiz;
using System;
using System.Threading.Tasks;

var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");
const string authId = "YOUR_AUTH_ID";

var recordingsResponse = await client.Recordings.ListRecordingsAsync(
    new ListRecordingsRequest 
    { 
        AuthId = authId 
    }
);

foreach (var recording in recordingsResponse.Recordings)
{
    Console.WriteLine($"Recording ID: {recording.RecordingId}");
}
```

### Send DTMF Tones

Send DTMF (keypad) tones on an active call. You can use `w` for a 0.5s pause and `W` for a 1s pause.

```csharp
using Vobiz;
using System;
using System.Threading.Tasks;

var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");
const string authId = "YOUR_AUTH_ID";

await client.Dtmf.SendDtmfAsync(
    new SendDtmfRequest
    {
        AuthId = authId,
        CallUuid = "call_uuid_here",
        Digits = "1234",
        Leg = SendDtmfRequestLeg.Aleg,
    }
);
```

## Async Operations

All network-bound methods in the Vobiz C# SDK are fully asynchronous and return a `Task` or `Task<T>`. They are designed to be used with the `async` and `await` keywords, ensuring that your application's threads are not blocked while waiting for HTTP responses from the Vobiz API.

```csharp
// All API operations are non-blocking and awaitable
var accountDetails = await client.Account.RetrieveAccountAsync();
```

## Error handling

The SDK throws a standard `Exception` if a network error occurs or if the Vobiz API returns a non-success HTTP status code. It is best practice to wrap your API calls in a `try/catch` block to handle these errors gracefully.

```csharp
try
{
    await client.LiveCalls.HangupCallAsync(
        new HangupCallRequest 
        { 
            AuthId = authId, 
            CallUuid = "invalid_uuid" 
        }
    );
}
catch (Exception ex)
{
    // Handle the error (e.g., log it, retry, or notify the user)
    Console.WriteLine($"API request failed: {ex.Message}");
}
```

## Other Vobiz SDKs

If you are building services in other languages, check out our official sibling SDKs:

| Language | Repository |
|---|---|
| **Node.js / TypeScript** | [vobiz-ai/Vobiz-Node-SDK](https://github.com/vobiz-ai/Vobiz-Node-SDK) |
| **Python** | [vobiz-ai/Vobiz-Python-SDK](https://github.com/vobiz-ai/Vobiz-Python-SDK) |
| **Go** | [vobiz-ai/Vobiz-Go-SDK](https://github.com/vobiz-ai/Vobiz-Go-SDK) |
| **Ruby** | [vobiz-ai/Vobiz-Ruby-SDK](https://github.com/vobiz-ai/Vobiz-Ruby-SDK) |
| **Java** | [vobiz-ai/Vobiz-Java-SDK](https://github.com/vobiz-ai/Vobiz-Java-SDK) |
| **PHP** | [vobiz-ai/Vobiz-PHP-SDK](https://github.com/vobiz-ai/Vobiz-PHP-SDK) |

## Support

- **Documentation:** [docs.vobiz.ai](https://docs.vobiz.ai)
- **Dashboard:** [console.vobiz.ai](https://console.vobiz.ai)

## License

This project is licensed under the MIT License.
