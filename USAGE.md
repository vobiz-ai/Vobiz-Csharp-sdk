# Vobiz C# SDK — Usage Sheet

Common operations. Full reference: [`reference.md`](./reference.md).

All snippets assume:

```csharp
using Vobiz;

var client = new VobizApiClient("YOUR_AUTH_TOKEN", "YOUR_AUTH_ID");
const string authId = "YOUR_AUTH_ID";
```

All methods are asynchronous and return a `Task`.

## Calls

```csharp
await client.Calls.MakeCallAsync(new MakeCallRequest {
    AuthId = authId, From = "14155551234", To = "+919876543210",
    AnswerUrl = "https://example.com/answer", AnswerMethod = "POST",
});

await client.LiveCalls.ListLiveCallsAsync(...);   // in-progress calls
await client.LiveCalls.GetLiveCallAsync(...);      // one live call
await client.LiveCalls.HangupCallAsync(...);       // hang up
```

## In-call actions

```csharp
await client.PlayAudio.CallAsync(...);
await client.SpeakText.CallAsync(...);
await client.Dtmf.SendDtmfAsync(...);
await client.RecordCalls.StartRecordingAsync(...);
await client.RecordCalls.StopRecordingAsync(...);
```

## CDRs & Recordings

```csharp
await client.Cdr.ListCdrsAsync(...);
await client.Cdr.SearchCdrsAsync(...);
await client.Cdr.GetCdrAsync(...);
await client.Recordings.ListRecordingsAsync(...);
await client.Recordings.GetRecordingAsync(...);
```

## Phone Numbers

```csharp
await client.PhoneNumbers.ListNumbersAsync(...);
await client.PhoneNumbers.ListInventoryNumbersAsync(...);
await client.PhoneNumbers.PurchaseFromInventoryAsync(...);
await client.PhoneNumbers.AssignNumberToTrunkAsync(...);
```

## Applications, Trunks, Endpoints

```csharp
await client.Applications.ListApplicationsAsync(...);
await client.Applications.CreateApplicationAsync(...);
await client.Trunks.ListTrunksAsync(...);
await client.Endpoints.ListEndpointsAsync(...);
```

## Conferences

```csharp
await client.Conferences.ListConferencesAsync(...);
await client.ConferenceMembers.MuteMemberAsync(...);
await client.Conference.KickMemberAsync(...);
```

## Account & Balance

```csharp
await client.Account.RetrieveAccountAsync();
await client.Balance.GetBalanceAsync(...);
await client.Balance.ListTransactionsAsync(...);
```

> Exact request fields per method are in [`reference.md`](./reference.md) and at
> https://docs.vobiz.ai.
