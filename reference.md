# Reference
## Account
<details><summary><code>client.Account.<a href="/src/Vobiz/Account/AccountClient.cs">RetrieveAccountAsync</a>() -> WithRawResponseTask&lt;RetrieveAccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve complete account details including pricing tier and credentials.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Account.RetrieveAccountAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Account.<a href="/src/Vobiz/Account/AccountClient.cs">GetConcurrencyAsync</a>(GetConcurrencyRequest { ... }) -> WithRawResponseTask&lt;GetConcurrencyResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the current concurrent call usage and configured limits.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Account.GetConcurrencyAsync(new GetConcurrencyRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetConcurrencyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Account.<a href="/src/Vobiz/Account/AccountClient.cs">PreviewChannelPricingAsync</a>(PreviewChannelPricingRequest { ... }) -> WithRawResponseTask&lt;ChannelPricingPreview&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Calculate the monthly price for CPS or concurrent-call capacity without purchasing capacity or debiting the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Account.PreviewChannelPricingAsync(
    new PreviewChannelPricingRequest
    {
        AuthId = "MA_XXXX",
        ResourceType = CapacityResourceType.ConcurrentCalls,
        Quantity = 30,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PreviewChannelPricingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Account.<a href="/src/Vobiz/Account/AccountClient.cs">CreateChannelSubscriptionAsync</a>(ChannelSubscriptionRequest { ... }) -> WithRawResponseTask&lt;ChannelSubscription&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Purchase recurring CPS or concurrent-call capacity. A successful request immediately debits the first monthly charge and activates a subscription that renews every 30 days.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Account.CreateChannelSubscriptionAsync(
    new ChannelSubscriptionRequest
    {
        AuthId = "MA_XXXX",
        ResourceType = CapacityResourceType.ConcurrentCalls,
        Quantity = 30,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ChannelSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Balance
<details><summary><code>client.Balance.<a href="/src/Vobiz/Balance/BalanceClient.cs">GetBalanceAsync</a>(GetBalanceRequest { ... }) -> WithRawResponseTask&lt;GetBalanceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the current account balance for a specific currency.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Balance.GetBalanceAsync(
    new GetBalanceRequest { AuthId = "MA_XXXXXX", Currency = "INR" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBalanceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Balance.<a href="/src/Vobiz/Balance/BalanceClient.cs">ListTransactionsAsync</a>(ListTransactionsRequest { ... }) -> WithRawResponseTask&lt;ListTransactionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve paginated transaction history for the account, ordered by
`created_at` descending. Filter to a single day by setting `from_date`
and `to_date` to the same date - a bare `YYYY-MM-DD` in `to_date` is
expanded to `23:59:59`, so both bounds are inclusive. Bare dates resolve
in the server timezone (UTC); send an explicit offset such as
`2026-08-28T00:00:00+05:30` to pin a local calendar day.

`limit` and `offset` are not supported - unknown parameters are silently
dropped. `total` and `summary` are computed over the whole filtered set
and ignore pagination, so `per_page=1` returns full-window totals.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Balance.ListTransactionsAsync(
    new ListTransactionsRequest
    {
        AuthId = "MA_XXXXXX",
        FromDate = "2026-08-25",
        ToDate = "2026-08-25",
        Type = "debit",
        Currency = "INR",
        ReferenceType = "cdr",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Balance.<a href="/src/Vobiz/Balance/BalanceClient.cs">ListTransactionReferenceTypesAsync</a>(ListTransactionReferenceTypesRequest { ... }) -> WithRawResponseTask&lt;ListTransactionReferenceTypesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the distinct `reference_type` values present on the account's ledger. Use it to discover valid values for the `reference_type` filter on the transactions endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Balance.ListTransactionReferenceTypesAsync(
    new ListTransactionReferenceTypesRequest { AuthId = "MA_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTransactionReferenceTypesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Live Calls
<details><summary><code>client.LiveCalls.<a href="/src/Vobiz/LiveCalls/LiveCallsClient.cs">ListQueuedCallsAsync</a>(ListQueuedCallsRequest { ... }) -> WithRawResponseTask&lt;ListQueuedCallsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all queued (pending, not yet connected) calls on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LiveCalls.ListQueuedCallsAsync(
    new ListQueuedCallsRequest { AuthId = "MA_XXXXXX", Status = ListQueuedCallsRequestStatus.Live }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListQueuedCallsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LiveCalls.<a href="/src/Vobiz/LiveCalls/LiveCallsClient.cs">ListLiveCallsAsync</a>(ListLiveCallsRequest { ... }) -> WithRawResponseTask&lt;ListLiveCallsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all currently active (live) calls on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LiveCalls.ListLiveCallsAsync(
    new ListLiveCallsRequest { AuthId = "MA_XXXXXX", Status = ListLiveCallsRequestStatus.Live }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListLiveCallsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LiveCalls.<a href="/src/Vobiz/LiveCalls/LiveCallsClient.cs">GetLiveCallAsync</a>(GetLiveCallRequest { ... }) -> WithRawResponseTask&lt;GetLiveCallResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of a specific live or queued call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LiveCalls.GetLiveCallAsync(
    new GetLiveCallRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "cdr_XXXXXXXXXX",
        Status = GetLiveCallRequestStatus.Live,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetLiveCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LiveCalls.<a href="/src/Vobiz/LiveCalls/LiveCallsClient.cs">HangupCallAsync</a>(HangupCallRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Terminate an active call by its UUID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LiveCalls.HangupCallAsync(
    new HangupCallRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `HangupCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LiveCalls.<a href="/src/Vobiz/LiveCalls/LiveCallsClient.cs">GetQueuedCallAsync</a>(GetQueuedCallRequest { ... }) -> WithRawResponseTask&lt;GetQueuedCallResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of a specific queued (pending) call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LiveCalls.GetQueuedCallAsync(
    new GetQueuedCallRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "cdr_XXXXXXXXXX",
        Status = GetQueuedCallRequestStatus.Live,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetQueuedCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Calls
<details><summary><code>client.Calls.<a href="/src/Vobiz/Calls/CallsClient.cs">MakeCallAsync</a>(MakeCallRequest { ... }) -> WithRawResponseTask&lt;MakeCallResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Initiate an outbound call to a PSTN number or SIP endpoint.
Use `<` to separate multiple destinations (max 1000).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Calls.MakeCallAsync(
    new MakeCallRequest
    {
        AuthId = "MA_XXXXXX",
        From = "14155551234",
        To = "+919876543210",
        AnswerUrl = "https://example.com/answer",
        AnswerMethod = "POST",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MakeCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## CDR
<details><summary><code>client.Cdr.<a href="/src/Vobiz/Cdr/CdrClient.cs">ListCdrsAsync</a>(ListCdrsRequest { ... }) -> WithRawResponseTask&lt;ListCdrsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns all CDRs for your account. Supports filtering by phone numbers,
date range, call direction, duration, and pagination.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cdr.ListCdrsAsync(
    new ListCdrsRequest
    {
        AuthId = "MA_XXXXXX",
        FromNumber = "9876543210",
        ToNumber = "1234567890",
        StartDate = new DateOnly(2026, 3, 1),
        EndDate = new DateOnly(2026, 3, 17),
        MinDuration = 10,
        SipCallId = "dD1qwu5VZ5iK3ed5u3uspjY5RKL",
        BridgeUuid = "4b7ae653-f40d-42f1-b582-6b05dfcd0c0a",
        HangupCause = "NORMAL_CLEARING",
        HangupDisposition = "send_refuse",
        Context = "sip-trunking",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCdrsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cdr.<a href="/src/Vobiz/Cdr/CdrClient.cs">SearchCdrsAsync</a>(SearchCdrsRequest { ... }) -> WithRawResponseTask&lt;SearchCdrsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Identical filters to the list endpoint, but the response also includes a
`filter_summary` object describing the active filters applied.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cdr.SearchCdrsAsync(
    new SearchCdrsRequest
    {
        AuthId = "MA_XXXXXX",
        FromNumber = "9876543210",
        ToNumber = "1234567890",
        StartDate = new DateOnly(2026, 3, 1),
        EndDate = new DateOnly(2026, 3, 17),
        MinDuration = 10,
        SipCallId = "dD1qwu5VZ5iK3ed5u3uspjY5RKL",
        BridgeUuid = "4b7ae653-f40d-42f1-b582-6b05dfcd0c0a",
        HangupCause = "NORMAL_CLEARING",
        HangupDisposition = "send_refuse",
        Context = "sip-trunking",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchCdrsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cdr.<a href="/src/Vobiz/Cdr/CdrClient.cs">ListRecentCdrsAsync</a>(ListRecentCdrsRequest { ... }) -> WithRawResponseTask&lt;ListRecentCdrsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the most recent CDRs for your account without requiring a date range.
Default 20 records; use `limit` to retrieve more.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cdr.ListRecentCdrsAsync(
    new ListRecentCdrsRequest { AuthId = "MA_XXXXXX", Limit = 50 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListRecentCdrsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cdr.<a href="/src/Vobiz/Cdr/CdrClient.cs">GetCdrAsync</a>(GetCdrRequest { ... }) -> WithRawResponseTask&lt;GetCdrResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the CDR for a specific completed call using its `call_id`.
Useful when you have a `call_id` from a callback or previous API response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cdr.GetCdrAsync(
    new GetCdrRequest { AuthId = "MA_XXXXXX", CallId = "abc123-def456-ghi789" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCdrRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Sub-Accounts
<details><summary><code>client.SubAccounts.<a href="/src/Vobiz/SubAccounts/SubAccountsClient.cs">ListSubaccountsAsync</a>(ListSubaccountsRequest { ... }) -> WithRawResponseTask&lt;ListSubaccountsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all sub-accounts under the master account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccounts.ListSubaccountsAsync(new ListSubaccountsRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListSubaccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccounts.<a href="/src/Vobiz/SubAccounts/SubAccountsClient.cs">CreateSubaccountAsync</a>(CreateSubaccountRequest { ... }) -> WithRawResponseTask&lt;CreateSubaccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new sub-account under the master account.

Set `kyc_mode` to control how the sub-account is verified:

- `personal_use` *(default)* - the sub-account inherits the parent's
  KYC; no separate verification is required.
- `customer_use` - the sub-account must complete its own KYC before it
  can place calls. A fresh `customer_use` sub-account is returned with
  `kyc_calls_blocked: true`. `customer_use` **requires** `email`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccounts.CreateSubaccountAsync(
    new CreateSubaccountRequest
    {
        AuthId = "MA_XXXXXX",
        Name = "Customer Co",
        Email = "customer@example.com",
        Password = "Customer@12345",
        KycMode = CreateSubaccountRequestKycMode.CustomerUse,
        BusinessType = CreateSubaccountRequestBusinessType.PrivateLimited,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateSubaccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccounts.<a href="/src/Vobiz/SubAccounts/SubAccountsClient.cs">RetrieveSubaccountAsync</a>(RetrieveSubaccountRequest { ... }) -> WithRawResponseTask&lt;RetrieveSubaccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of a specific sub-account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccounts.RetrieveSubaccountAsync(
    new RetrieveSubaccountRequest { AuthId = "MA_XXXXXX", SubAuthId = "SA_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RetrieveSubaccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccounts.<a href="/src/Vobiz/SubAccounts/SubAccountsClient.cs">UpdateSubaccountAsync</a>(UpdateSubaccountRequest { ... }) -> WithRawResponseTask&lt;UpdateSubaccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the name or status of a sub-account, or change its `kyc_mode`.

Promoting an existing sub-account to `customer_use` requires the
sub-account to already have an `email` (otherwise `400`). On any
`kyc_mode` change, `kyc_calls_blocked` is re-derived from the
sub-account's current KYC state.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccounts.UpdateSubaccountAsync(
    new UpdateSubaccountRequest
    {
        AuthId = "MA_XXXXXX",
        SubAuthId = "sub_auth_id",
        KycMode = UpdateSubaccountRequestKycMode.CustomerUse,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateSubaccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccounts.<a href="/src/Vobiz/SubAccounts/SubAccountsClient.cs">DeleteSubaccountAsync</a>(DeleteSubaccountRequest { ... }) -> WithRawResponseTask&lt;DeleteSubaccountResponse?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete a sub-account and revoke its credentials.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccounts.DeleteSubaccountAsync(
    new DeleteSubaccountRequest { AuthId = "MA_XXXXXX", SubAuthId = "sub_auth_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteSubaccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Sub-Account KYC
<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">GetSubaccountKycStatusAsync</a>(GetSubaccountKycStatusRequest { ... }) -> WithRawResponseTask&lt;SubAccountKycStatus&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the aggregated KYC state for a `customer_use` sub-account —
which verifications have passed, whether calls are still blocked, and
the business type. The caller must be the parent main account that owns
the sub-account (or an admin).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.GetSubaccountKycStatusAsync(
    new GetSubaccountKycStatusRequest { SubAuthId = "SA_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetSubaccountKycStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">VerifySubaccountPanAsync</a>(VerifySubaccountPanRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Runs a real PAN verification (Perfios) for the sub-account. `pan` must
be exactly 10 characters. Persists a `kyc_verifications` row and
recomputes the sub-account's aggregated `kyc_status`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.VerifySubaccountPanAsync(
    new VerifySubaccountPanRequest { SubAuthId = "SA_XXXXXX", Pan = "ABCDE1234F" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VerifySubaccountPanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">VerifySubaccountGstAsync</a>(VerifySubaccountGstRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Runs a real GSTIN verification. `gstin` must be a 15-character GSTIN.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.VerifySubaccountGstAsync(
    new VerifySubaccountGstRequest { SubAuthId = "SA_XXXXXX", Gstin = "29AAJCN5983D1Z0" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VerifySubaccountGstRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">SearchSubaccountCinAsync</a>(SearchSubaccountCinRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Name-based CIN lookup. Returns candidate company matches; pick one and
pass it to [CIN confirm](#operation/confirm-subaccount-cin).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.SearchSubaccountCinAsync(
    new SearchSubaccountCinRequest { SubAuthId = "SA_XXXXXX", CompanyName = "ACME PRIVATE LIMITED" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchSubaccountCinRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">ConfirmSubaccountCinAsync</a>(ConfirmSubaccountCinRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Confirm the CIN selected from the search results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.ConfirmSubaccountCinAsync(
    new ConfirmSubaccountCinRequest
    {
        SubAuthId = "SA_XXXXXX",
        CompanyName = "ACME PRIVATE LIMITED",
        SelectedCin = "U72900KA2024PTC123456",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ConfirmSubaccountCinRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">SubaccountDigilockerInitiateAsync</a>(SubaccountDigilockerInitiateRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the DigiLocker authorization link and an `access_request_id`.
The customer completes the OAuth flow on the DigiLocker portal, after
which you finalize with
[DigiLocker verify](#operation/subaccount-digilocker-verify).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.SubaccountDigilockerInitiateAsync(
    new SubaccountDigilockerInitiateRequest
    {
        SubAuthId = "SA_XXXXXX",
        RedirectUrl = "https://partner.example.com/kyc/callback",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SubaccountDigilockerInitiateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">SubaccountDigilockerVerifyAsync</a>(SubaccountDigilockerVerifyRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Finalize Aadhaar via DigiLocker after the customer completes OAuth.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.SubaccountDigilockerVerifyAsync(
    new SubaccountDigilockerVerifyRequest
    {
        SubAuthId = "SA_XXXXXX",
        AccessRequestId = "AR_xxxxxxxx",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SubaccountDigilockerVerifyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKyc.<a href="/src/Vobiz/SubAccountKyc/SubAccountKycClient.cs">CreateSubaccountKycSessionAsync</a>(CreateSubaccountKycSessionRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a Vobiz-hosted KYC session for the sub-account. With
`flow_type=email` (default) Vobiz emails the customer a signed link
(from `kyc@vobiz.ai`, hosted at `kyc.vobiz.ai`) and `customer_email` is
required. With `flow_type=redirect`, omit `customer_email`, pass a
`redirect_url`, and the `widget_url` is returned directly for an inline
redirect.

This is the sub-account–scoped equivalent of the partner-level
[KYC Sessions](/partner/api/kyc-sessions) endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKyc.CreateSubaccountKycSessionAsync(
    new CreateSubaccountKycSessionRequest
    {
        SubAuthId = "SA_XXXXXX",
        AccountAuthId = "SA_XXXXXX",
        FlowType = CreateSubaccountKycSessionRequestFlowType.Email,
        CustomerEmail = "customer@example.com",
        WebhookUrl = "https://your-app.example.com/kyc/webhook",
        ExpiresInDays = 30,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateSubaccountKycSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Sub-Account KYC (Test Mode)
<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockVerifySubaccountPanAsync</a>(MockVerifySubaccountPanRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Mock PAN verification - never hits the provider. Magic `pan` inputs:

| Input | Outcome |
|---|---|
| `TESTSUCCESS0001` | verified |
| `TESTFAIL0001` | failed |
| `TESTERROR0001` | HTTP 500 |
| `TESTPENDING001` | pending (finalize as verified) |
| `TESTPENDING_FAIL` | pending (finalize as failed) |

Persists a real `kyc_verifications` row and recomputes `kyc_status`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockVerifySubaccountPanAsync(
    new MockVerifySubaccountPanRequest { SubAuthId = "SA_XXXXXX", Pan = "TESTSUCCESS0001" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockVerifySubaccountPanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockVerifySubaccountGstAsync</a>(MockVerifySubaccountGstRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Mock GST verification. Same magic-input matrix as [Mock verify PAN](#operation/mock-verify-subaccount-pan).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockVerifySubaccountGstAsync(
    new MockVerifySubaccountGstRequest { SubAuthId = "SA_XXXXXX", Gstin = "TESTSUCCESS0001GST" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockVerifySubaccountGstRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockSearchSubaccountCinAsync</a>(MockSearchSubaccountCinRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns deterministic fake company matches.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockSearchSubaccountCinAsync(
    new MockSearchSubaccountCinRequest { SubAuthId = "SA_XXXXXX", CompanyName = "ACME" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockSearchSubaccountCinRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockConfirmSubaccountCinAsync</a>(MockConfirmSubaccountCinRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Succeeds when `selected_cin` starts with `U72900KA2024PTC123456`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockConfirmSubaccountCinAsync(
    new MockConfirmSubaccountCinRequest
    {
        SubAuthId = "SA_XXXXXX",
        CompanyName = "ACME",
        SelectedCin = "U72900KA2024PTC123456",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockConfirmSubaccountCinRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockSubaccountDigilockerInitiateAsync</a>(MockSubaccountDigilockerInitiateRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a deterministic `access_request_id`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockSubaccountDigilockerInitiateAsync(
    new MockSubaccountDigilockerInitiateRequest
    {
        SubAuthId = "SA_XXXXXX",
        RedirectUrl = "https://partner.example.com/kyc/callback",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockSubaccountDigilockerInitiateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockSubaccountDigilockerVerifyAsync</a>(MockSubaccountDigilockerVerifyRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

`access_request_id` `MOCK_AR_SUCCESS` → verified; `MOCK_AR_FAIL` → failed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockSubaccountDigilockerVerifyAsync(
    new MockSubaccountDigilockerVerifyRequest
    {
        SubAuthId = "SA_XXXXXX",
        AccessRequestId = MockSubaccountDigilockerVerifyRequestAccessRequestId.MockArSuccess,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockSubaccountDigilockerVerifyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SubAccountKycTestMode.<a href="/src/Vobiz/SubAccountKycTestMode/SubAccountKycTestModeClient.cs">MockFinalizePendingKycAsync</a>(MockFinalizePendingKycRequest { ... }) -> WithRawResponseTask&lt;KycVerificationResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Promotes the most recent **pending** mock verification of the given
type to a terminal outcome - this drives the async (`TESTPENDING…`)
path without webhooks. `verification_type` ∈ `pan | aadhaar | gst | cin`;
`outcome` ∈ `verified | failed`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubAccountKycTestMode.MockFinalizePendingKycAsync(
    new MockFinalizePendingKycRequest
    {
        SubAuthId = "SA_XXXXXX",
        VerificationType = MockFinalizePendingKycRequestVerificationType.Pan,
        Outcome = MockFinalizePendingKycRequestOutcome.Verified,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MockFinalizePendingKycRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Phone Numbers
<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">ListNumbersAsync</a>(ListNumbersRequest { ... }) -> WithRawResponseTask&lt;ListNumbersResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all phone numbers on your account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.ListNumbersAsync(
    new ListNumbersRequest { AuthId = "MA_XXXXXX", Search = "+919876543210" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">UnrentNumberAsync</a>(UnrentNumberRequest { ... }) -> WithRawResponseTask&lt;UnrentNumberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Release a phone number from your account. Releasing a number incurs the
number-release fee configured for the account; the response returns the
charged amount in `release_fee`. By default, the number enters
`pending_release` for a 24-hour cooldown. Cancelling during that window
refunds the release fee. Set `immediate=true` to skip the cooldown; an
immediate release cannot be cancelled.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.UnrentNumberAsync(
    new UnrentNumberRequest { AuthId = "MA_XXXXXX", E164 = "%2B919876543210" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UnrentNumberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">CancelNumberReleaseAsync</a>(CancelNumberReleaseRequest { ... }) -> WithRawResponseTask&lt;CancelNumberReleaseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancel a pending number release during the 24-hour cooldown. The number is
restored to `active`, the cooldown timer is cleared, and the release fee is
refunded in full to the account balance. Any trunk or voice application
detached by the release is not re-attached automatically.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.CancelNumberReleaseAsync(
    new CancelNumberReleaseRequest { AccountId = "MA_XXXXXX", E164 = "%2B919876543210" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CancelNumberReleaseRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">ListInventoryNumbersAsync</a>(ListInventoryNumbersRequest { ... }) -> WithRawResponseTask&lt;ListInventoryNumbersResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Browse available phone numbers in inventory that are not assigned to
any account. Only numbers with `status='active'` and `auth_id=NULL`
are returned. These numbers are ready to be purchased.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.ListInventoryNumbersAsync(
    new ListInventoryNumbersRequest
    {
        AuthId = "MA_XXXXXX",
        Country = "IN",
        Exclude = "9180,9192",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListInventoryNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">PurchaseFromInventoryAsync</a>(PurchaseFromInventoryRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Purchase a phone number from inventory and assign it to your account.
Debits your account balance for the setup fee and monthly fee. For
sub-accounts (SA_), the parent master account (MA_) is charged.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.PurchaseFromInventoryAsync(
    new PurchaseFromInventoryRequest
    {
        AuthId = "MA_XXXXXX",
        E164 = "+919876543210",
        Currency = "USD",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PurchaseFromInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">AssignNumberToTrunkAsync</a>(AssignNumberToTrunkRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assign a phone number to a specific SIP trunk. Once assigned, all
inbound calls to that phone number will be routed through the
designated trunk. The phone number must be URL-encoded; use `%2B`
instead of `+` (e.g., `%2B912271264217`).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.AssignNumberToTrunkAsync(
    new AssignNumberToTrunkRequest
    {
        AuthId = "MA_XXXXXX",
        PhoneNumber = "%2B912271264217",
        TrunkGroupId = "e3e55a78-1234-5678-90ab-cdef12345678",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AssignNumberToTrunkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">UnassignNumberFromTrunkAsync</a>(UnassignNumberFromTrunkRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove the assignment between a phone number and a SIP trunk. After
unassignment, the number remains in your account inventory but will
no longer route inbound calls through the previously assigned trunk.
URL-encode the phone number (use `%2B` instead of `+`).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.UnassignNumberFromTrunkAsync(
    new UnassignNumberFromTrunkRequest { AuthId = "MA_XXXXXX", PhoneNumber = "%2B912271264217" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UnassignNumberFromTrunkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">GetNumberHealthAsync</a>(GetNumberHealthRequest { ... }) -> WithRawResponseTask&lt;GetNumberHealthResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the health & analytics dashboard for one of your numbers: current
status, spam flag, and call metrics over the selected window (total and
answered calls, answer rate, minutes, average duration) plus a per-period
time series of snapshots.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.GetNumberHealthAsync(
    new GetNumberHealthRequest
    {
        AuthId = "MA_XXXXXX",
        E164 = "%2B919876543210",
        Days = 30,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetNumberHealthRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">AssignDidToSubaccountAsync</a>(AssignDidToSubaccountRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assign a parent-pool DID to a sub-account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.AssignDidToSubaccountAsync(
    new AssignDidToSubaccountRequest
    {
        AuthId = "MA_XXXXXX",
        E164 = "%2B919876543210",
        SubAccountId = "SA_XXXXXX",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AssignDidToSubaccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">UnassignDidFromSubaccountAsync</a>(UnassignDidFromSubaccountRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Move the DID back to the parent pool.

A **15-day cool-off** is enforced: if the DID had a call within the last
15 days, the request is rejected with `409` and a
`did_cool_off_in_effect` error that includes `cool_off_until` and
`cool_off_remaining_seconds`. Never-used DIDs (`last_call_at` is `NULL`)
move back immediately.

Admins can bypass the cool-off with `?force=true` (see below); the
bypass writes a `did_assignment_audit` row and requires an
admin-role account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneNumbers.UnassignDidFromSubaccountAsync(
    new UnassignDidFromSubaccountRequest
    {
        AuthId = "MA_XXXXXX",
        E164 = "%2B919876543210",
        Force = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UnassignDidFromSubaccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Trunks
<details><summary><code>client.Trunks.<a href="/src/Vobiz/Trunks/TrunksClient.cs">ListTrunksAsync</a>(ListTrunksRequest { ... }) -> WithRawResponseTask&lt;ListTrunksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all SIP trunks configured on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Trunks.ListTrunksAsync(new ListTrunksRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTrunksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Trunks.<a href="/src/Vobiz/Trunks/TrunksClient.cs">CreateTrunkAsync</a>(CreateTrunkRequest { ... }) -> WithRawResponseTask&lt;CreateTrunkResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new SIP trunk for inbound or outbound calling.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Trunks.CreateTrunkAsync(
    new CreateTrunkRequest
    {
        AuthId = "MA_XXXXXX",
        Name = "Retell AI SIP",
        TrunkDirection = CreateTrunkRequestTrunkDirection.Outbound,
        Transport = CreateTrunkRequestTransport.Udp,
        ConcurrentCallsLimit = 50,
        CpsLimit = 15,
        CredentialUuid = "b1e2...",
        IpaclUuid = "c3d4...",
        Recording = true,
        EnableTranscription = true,
        WebhookUrl = "https://example.com/vobiz/webhook",
        WebhookMethod = CreateTrunkRequestWebhookMethod.Post,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateTrunkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Trunks.<a href="/src/Vobiz/Trunks/TrunksClient.cs">RetrieveTrunkAsync</a>(RetrieveTrunkRequest { ... }) -> WithRawResponseTask&lt;RetrieveTrunkResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get details of a specific SIP trunk.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Trunks.RetrieveTrunkAsync(
    new RetrieveTrunkRequest { AuthId = "MA_XXXXXX", TrunkId = "trunk_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RetrieveTrunkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Trunks.<a href="/src/Vobiz/Trunks/TrunksClient.cs">UpdateTrunkAsync</a>(UpdateTrunkRequest { ... }) -> WithRawResponseTask&lt;UpdateTrunkResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a SIP trunk's name, configuration, or status.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Trunks.UpdateTrunkAsync(
    new UpdateTrunkRequest { AuthId = "MA_XXXXXX", TrunkId = "trunk_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateTrunkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Trunks.<a href="/src/Vobiz/Trunks/TrunksClient.cs">DeleteTrunkAsync</a>(DeleteTrunkRequest { ... }) -> WithRawResponseTask&lt;string?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete a SIP trunk.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Trunks.DeleteTrunkAsync(
    new DeleteTrunkRequest { AuthId = "MA_XXXXXX", TrunkId = "trunk_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteTrunkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Conference
<details><summary><code>client.Conference.<a href="/src/Vobiz/Conference/ConferenceClient.cs">KickMemberAsync</a>(KickMemberRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove one or more participants from a conference while allowing their XML flow to continue.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conference.KickMemberAsync(
    new KickMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `KickMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conference.<a href="/src/Vobiz/Conference/ConferenceClient.cs">HangupMemberAsync</a>(HangupMemberRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Terminate one or more active conference member calls. A normal active-member request disconnects the member. If a member was kicked, continued its XML flow, and rejoined with the same numeric member ID, confirm removal through conference exit or call hangup callbacks.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conference.HangupMemberAsync(
    new HangupMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `HangupMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conference.<a href="/src/Vobiz/Conference/ConferenceClient.cs">PlayAudioMemberAsync</a>(PlayAudioMemberRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Play an audio file to a specific conference member.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conference.PlayAudioMemberAsync(
    new PlayAudioMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
        Url = "https://example.com/audio.mp3",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PlayAudioMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conference.<a href="/src/Vobiz/Conference/ConferenceClient.cs">StopAudioMemberAsync</a>(StopAudioMemberRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stop audio playback for a specific conference member.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conference.StopAudioMemberAsync(
    new StopAudioMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StopAudioMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conference.<a href="/src/Vobiz/Conference/ConferenceClient.cs">DeafMemberAsync</a>(DeafMemberRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Prevent a conference member from hearing other participants.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conference.DeafMemberAsync(
    new DeafMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeafMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conference.<a href="/src/Vobiz/Conference/ConferenceClient.cs">UndeafMemberAsync</a>(UndeafMemberRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Restore a conference member's ability to hear other participants.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conference.UndeafMemberAsync(
    new UndeafMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UndeafMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## RecordCalls
<details><summary><code>client.RecordCalls.<a href="/src/Vobiz/RecordCalls/RecordCallsClient.cs">StartRecordingAsync</a>(StartRecordingRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Begin recording an active call. Set format, enable transcription, and configure a callback URL.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RecordCalls.StartRecordingAsync(
    new StartRecordingRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "cdr_XXXXXXXXXX",
        TimeLimit = 120,
        FileFormat = StartRecordingRequestFileFormat.Mp3,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StartRecordingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RecordCalls.<a href="/src/Vobiz/RecordCalls/RecordCallsClient.cs">StopRecordingAsync</a>(StopRecordingRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stop an active recording on an in-progress call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RecordCalls.StopRecordingAsync(
    new StopRecordingRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StopRecordingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## PlayAudio
<details><summary><code>client.PlayAudio.<a href="/src/Vobiz/PlayAudio/PlayAudioClient.cs">CallAsync</a>(PlayAudioCallRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Play an audio file to a live call leg.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PlayAudio.CallAsync(
    new PlayAudioCallRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "call_uuid",
        Urls = "https://example.com/audio.mp3",
        Legs = PlayAudioCallRequestLegs.Aleg,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PlayAudioCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PlayAudio.<a href="/src/Vobiz/PlayAudio/PlayAudioClient.cs">StopAudioCallAsync</a>(StopAudioCallRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stop audio playing on a live call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PlayAudio.StopAudioCallAsync(
    new StopAudioCallRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StopAudioCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## SpeakText
<details><summary><code>client.SpeakText.<a href="/src/Vobiz/SpeakText/SpeakTextClient.cs">CallAsync</a>(SpeakTextCallRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Convert text to speech and play it on a live call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SpeakText.CallAsync(
    new SpeakTextCallRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "call_uuid",
        Text = "Hello, your appointment is confirmed for tomorrow at 3 PM.",
        Voice = "WOMAN",
        Language = "en-US",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SpeakTextCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SpeakText.<a href="/src/Vobiz/SpeakText/SpeakTextClient.cs">StopSpeakCallAsync</a>(StopSpeakCallRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stop ongoing TTS playback on a live call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SpeakText.StopSpeakCallAsync(
    new StopSpeakCallRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StopSpeakCallRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Dtmf
<details><summary><code>client.Dtmf.<a href="/src/Vobiz/Dtmf/DtmfClient.cs">SendDtmfAsync</a>(SendDtmfRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Send DTMF (keypad) tones on an active call. Use `w` for 0.5s pause, `W` for 1s pause.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Dtmf.SendDtmfAsync(
    new SendDtmfRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "call_uuid",
        Digits = "1234",
        Leg = SendDtmfRequestLeg.Aleg,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SendDtmfRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AudioStreams
<details><summary><code>client.AudioStreams.<a href="/src/Vobiz/AudioStreams/AudioStreamsClient.cs">ListStreamsAsync</a>(ListStreamsRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all audio streams on a live call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AudioStreams.ListStreamsAsync(
    new ListStreamsRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListStreamsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AudioStreams.<a href="/src/Vobiz/AudioStreams/AudioStreamsClient.cs">StartStreamAsync</a>(StartStreamRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Start streaming raw audio from a live call to a WebSocket URL.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AudioStreams.StartStreamAsync(
    new StartStreamRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "call_uuid",
        ServiceUrl = "wss://your-server.com/ws",
        Bidirectional = true,
        AudioTrack = StartStreamRequestAudioTrack.Both,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StartStreamRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AudioStreams.<a href="/src/Vobiz/AudioStreams/AudioStreamsClient.cs">GetStreamAsync</a>(GetStreamRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get details of a specific audio stream.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AudioStreams.GetStreamAsync(
    new GetStreamRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "call_uuid",
        StreamId = "stream_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetStreamRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AudioStreams.<a href="/src/Vobiz/AudioStreams/AudioStreamsClient.cs">StopStreamAsync</a>(StopStreamRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stop a specific audio stream on a live call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AudioStreams.StopStreamAsync(
    new StopStreamRequest
    {
        AuthId = "MA_XXXXXX",
        CallUuid = "call_uuid",
        StreamId = "stream_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StopStreamRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Conferences
<details><summary><code>client.Conferences.<a href="/src/Vobiz/Conferences/ConferencesClient.cs">ListConferencesAsync</a>(ListConferencesRequest { ... }) -> WithRawResponseTask&lt;ListConferencesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve conference room names reported by the API. An empty array is inconclusive and can occur while conferences are active. Maintain your own room registry for authoritative discovery, billing, cleanup, and destructive workflows.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conferences.ListConferencesAsync(new ListConferencesRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListConferencesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conferences.<a href="/src/Vobiz/Conferences/ConferencesClient.cs">DeleteAllConferencesAsync</a>(DeleteAllConferencesRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Terminate all active conference rooms.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conferences.DeleteAllConferencesAsync(
    new DeleteAllConferencesRequest { AuthId = "MA_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteAllConferencesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conferences.<a href="/src/Vobiz/Conferences/ConferencesClient.cs">GetConferenceAsync</a>(GetConferenceRequest { ... }) -> WithRawResponseTask&lt;OneOf&lt;GetConferenceResponseConferenceMemberCount, GetConferenceResponseError&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific conference room. A live conference can currently return a 200 response with an error payload instead of conference details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conferences.GetConferenceAsync(
    new GetConferenceRequest { AuthId = "MA_XXXXXX", ConferenceName = "My Conf Room" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetConferenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Conferences.<a href="/src/Vobiz/Conferences/ConferencesClient.cs">DeleteConferenceAsync</a>(DeleteConferenceRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Terminate a specific conference room and disconnect all members.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Conferences.DeleteConferenceAsync(
    new DeleteConferenceRequest { AuthId = "MA_XXXXXX", ConferenceName = "conference_name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteConferenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ConferenceMembers
<details><summary><code>client.ConferenceMembers.<a href="/src/Vobiz/ConferenceMembers/ConferenceMembersClient.cs">MuteMemberAsync</a>(MuteMemberRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Prevent a member from speaking. Use `all` as member_id to mute everyone.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConferenceMembers.MuteMemberAsync(
    new MuteMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MuteMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConferenceMembers.<a href="/src/Vobiz/ConferenceMembers/ConferenceMembersClient.cs">UnmuteMemberAsync</a>(UnmuteMemberRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Allow a muted member to speak again.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConferenceMembers.UnmuteMemberAsync(
    new UnmuteMemberRequest
    {
        AuthId = "MA_XXXXXX",
        ConferenceName = "conference_name",
        MemberId = "member_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UnmuteMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ConferenceRecording
<details><summary><code>client.ConferenceRecording.<a href="/src/Vobiz/ConferenceRecording/ConferenceRecordingClient.cs">StartConferenceRecordingAsync</a>(StartConferenceRecordingRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Queue recording for all audio in a conference room. The response does not include a recording ID or download URL.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConferenceRecording.StartConferenceRecordingAsync(
    new StartConferenceRecordingRequest { AuthId = "MA_XXXXXX", ConferenceName = "conference_name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StartConferenceRecordingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConferenceRecording.<a href="/src/Vobiz/ConferenceRecording/ConferenceRecordingClient.cs">StopConferenceRecordingAsync</a>(StopConferenceRecordingRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stop recording a conference room.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConferenceRecording.StopConferenceRecordingAsync(
    new StopConferenceRecordingRequest { AuthId = "MA_XXXXXX", ConferenceName = "conference_name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `StopConferenceRecordingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Recordings
<details><summary><code>client.Recordings.<a href="/src/Vobiz/Recordings/RecordingsClient.cs">ListRecordingsAsync</a>(ListRecordingsRequest { ... }) -> WithRawResponseTask&lt;ListRecordingsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all call recordings on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Recordings.ListRecordingsAsync(new ListRecordingsRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListRecordingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Recordings.<a href="/src/Vobiz/Recordings/RecordingsClient.cs">GetRecordingAsync</a>(GetRecordingRequest { ... }) -> WithRawResponseTask&lt;GetRecordingResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get details and download URL for a specific recording.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Recordings.GetRecordingAsync(
    new GetRecordingRequest { AuthId = "MA_XXXXXX", RecordingId = "rec_XXXXXXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetRecordingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Recordings.<a href="/src/Vobiz/Recordings/RecordingsClient.cs">DeleteRecordingAsync</a>(DeleteRecordingRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete a recording from the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Recordings.DeleteRecordingAsync(
    new DeleteRecordingRequest { AuthId = "MA_XXXXXX", RecordingId = "recording_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteRecordingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bulk Operations
<details><summary><code>client.BulkOperations.<a href="/src/Vobiz/BulkOperations/BulkOperationsClient.cs">BulkExportRecordingsAsync</a>(BulkExportRecordingsRequest { ... }) -> WithRawResponseTask&lt;BulkExportRecordingsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Queue a bulk export of the recordings matching your filter criteria. The request is
validated and accepted for background processing, and the resulting archive is emailed
as a download link to every address in `recipient.customer_account`. The archive is
typically available within 15-60 minutes depending on volume.

Results are delivered by email only; the export runs to completion in the background
after the `202` response.

One export runs at a time per account. While an export is in progress, further requests
return `403`.

Filter rules:
- Use either `from`/`to` or the `recording_storage_duration*` filters, not both.
- Use one of `__gt` or `__gte`, and one of `__lt` or `__lte`.
- When using range filters (`__gte`/`__lte`), provide both.
- Maximum date range is 1 year (366 days); maximum storage duration range is 30 days.
- The additional filters (`from_number`, `to_number`, `call_uuid`, `conference_name`,
  `recording_format`, `recording_id`) apply when the range is 30 days or less.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkOperations.BulkExportRecordingsAsync(
    new BulkExportRecordingsRequest
    {
        AuthId = "MA_XXXXXX",
        Recipient = new BulkExportRecordingsRequestRecipient
        {
            CustomerAccount = new List<string>() { "admin@example.com" },
        },
        From = "2025-01-23 00:00:00",
        To = "2025-01-30 23:59:59",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkExportRecordingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Credentials
<details><summary><code>client.Credentials.<a href="/src/Vobiz/Credentials/CredentialsClient.cs">CreateCredentialAsync</a>(CreateCredentialRequest { ... }) -> WithRawResponseTask&lt;CreateCredentialResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create SIP credentials for trunk authentication.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.CreateCredentialAsync(
    new CreateCredentialRequest
    {
        AuthId = "MA_XXXXXX",
        Username = "myuser",
        Password = "securepassword123",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateCredentialRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Credentials.<a href="/src/Vobiz/Credentials/CredentialsClient.cs">ListCredentialsAsync</a>(ListCredentialsRequest { ... }) -> WithRawResponseTask&lt;ListCredentialsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all SIP credentials on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.ListCredentialsAsync(new ListCredentialsRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCredentialsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Credentials.<a href="/src/Vobiz/Credentials/CredentialsClient.cs">UpdateCredentialAsync</a>(UpdateCredentialRequest { ... }) -> WithRawResponseTask&lt;UpdateCredentialResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the password for an existing SIP credential.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.UpdateCredentialAsync(
    new UpdateCredentialRequest
    {
        AuthId = "MA_XXXXXX",
        CredentialId = "credential_id",
        Password = "password",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateCredentialRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Credentials.<a href="/src/Vobiz/Credentials/CredentialsClient.cs">DeleteCredentialAsync</a>(DeleteCredentialRequest { ... }) -> WithRawResponseTask&lt;string?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an existing SIP credential.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Credentials.DeleteCredentialAsync(
    new DeleteCredentialRequest { AuthId = "MA_XXXXXX", CredentialId = "credential_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteCredentialRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## IpAccessControlList
<details><summary><code>client.IpAccessControlList.<a href="/src/Vobiz/IpAccessControlList/IpAccessControlListClient.cs">CreateIpAclAsync</a>(CreateIpAclRequest { ... }) -> WithRawResponseTask&lt;CreateIpAclResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add an IP access control rule to restrict SIP trunk access.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IpAccessControlList.CreateIpAclAsync(
    new CreateIpAclRequest
    {
        AuthId = "MA_XXXXXX",
        Name = "Office IP",
        IpAddress = "ip_address",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateIpAclRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.IpAccessControlList.<a href="/src/Vobiz/IpAccessControlList/IpAccessControlListClient.cs">ListIpAclsAsync</a>(ListIpAclsRequest { ... }) -> WithRawResponseTask&lt;ListIpAclsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all IP access control rules on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IpAccessControlList.ListIpAclsAsync(new ListIpAclsRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListIpAclsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.IpAccessControlList.<a href="/src/Vobiz/IpAccessControlList/IpAccessControlListClient.cs">UpdateIpAclAsync</a>(UpdateIpAclRequest { ... }) -> WithRawResponseTask&lt;UpdateIpAclResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing IP access control rule.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IpAccessControlList.UpdateIpAclAsync(
    new UpdateIpAclRequest
    {
        AuthId = "MA_XXXXXX",
        IpAclId = "ip_acl_id",
        Name = "name",
        IpAddress = "ip_address",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateIpAclRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.IpAccessControlList.<a href="/src/Vobiz/IpAccessControlList/IpAccessControlListClient.cs">DeleteIpAclAsync</a>(DeleteIpAclRequest { ... }) -> WithRawResponseTask&lt;string?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove an IP access control rule.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IpAccessControlList.DeleteIpAclAsync(
    new DeleteIpAclRequest { AuthId = "MA_XXXXXX", IpAclId = "ip_acl_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteIpAclRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## OriginationUri
<details><summary><code>client.OriginationUri.<a href="/src/Vobiz/OriginationUri/OriginationUriClient.cs">CreateOriginationUriAsync</a>(CreateOriginationUriRequest { ... }) -> WithRawResponseTask&lt;CreateOriginationUriResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add an inbound SIP endpoint (origination URI) to a trunk.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OriginationUri.CreateOriginationUriAsync(
    new CreateOriginationUriRequest
    {
        AuthId = "MA_XXXXXX",
        Name = "Primary SBC",
        SipUri = "sip:sbc.example.com",
        Priority = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateOriginationUriRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OriginationUri.<a href="/src/Vobiz/OriginationUri/OriginationUriClient.cs">ListOriginationUrisAsync</a>(ListOriginationUrisRequest { ... }) -> WithRawResponseTask&lt;ListOriginationUrisResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all origination URIs on the account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OriginationUri.ListOriginationUrisAsync(
    new ListOriginationUrisRequest { AuthId = "MA_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListOriginationUrisRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OriginationUri.<a href="/src/Vobiz/OriginationUri/OriginationUriClient.cs">UpdateOriginationUriAsync</a>(UpdateOriginationUriRequest { ... }) -> WithRawResponseTask&lt;UpdateOriginationUriResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing origination URI.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OriginationUri.UpdateOriginationUriAsync(
    new UpdateOriginationUriRequest
    {
        AuthId = "MA_XXXXXX",
        UriId = "uri_id",
        Name = "name",
        Priority = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateOriginationUriRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OriginationUri.<a href="/src/Vobiz/OriginationUri/OriginationUriClient.cs">DeleteOriginationUriAsync</a>(DeleteOriginationUriRequest { ... }) -> WithRawResponseTask&lt;string?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an origination URI from a trunk.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OriginationUri.DeleteOriginationUriAsync(
    new DeleteOriginationUriRequest { AuthId = "MA_XXXXXX", UriId = "uri_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteOriginationUriRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Applications
<details><summary><code>client.Applications.<a href="/src/Vobiz/Applications/ApplicationsClient.cs">ListApplicationsAsync</a>(ListApplicationsRequest { ... }) -> WithRawResponseTask&lt;ListApplicationsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get details of all applications created under your Vobiz account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Applications.ListApplicationsAsync(
    new ListApplicationsRequest { AuthId = "MA_XXXXXX" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListApplicationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Applications.<a href="/src/Vobiz/Applications/ApplicationsClient.cs">CreateApplicationAsync</a>(CreateApplicationRequest { ... }) -> WithRawResponseTask&lt;CreateApplicationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates an Application with webhook URLs for call handling.
Creating an application is usually a first step, after which you
attach the application to either a number or an endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Applications.CreateApplicationAsync(
    new CreateApplicationRequest
    {
        AuthId = "MA_XXXXXX",
        AppName = "My Voice Application",
        AnswerUrl = "https://example.com/answer",
        AnswerMethod = "POST",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateApplicationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Applications.<a href="/src/Vobiz/Applications/ApplicationsClient.cs">RetrieveApplicationAsync</a>(RetrieveApplicationRequest { ... }) -> WithRawResponseTask&lt;RetrieveApplicationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get details of a particular application by passing the app_id.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Applications.RetrieveApplicationAsync(
    new RetrieveApplicationRequest { AuthId = "MA_XXXXXX", AppId = "12345678" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RetrieveApplicationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Applications.<a href="/src/Vobiz/Applications/ApplicationsClient.cs">UpdateApplicationAsync</a>(UpdateApplicationRequest { ... }) -> WithRawResponseTask&lt;UpdateApplicationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify an application using this API. You can update any subset of
fields (partial update). Fields not provided will remain unchanged.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Applications.UpdateApplicationAsync(
    new UpdateApplicationRequest
    {
        AuthId = "MA_XXXXXX",
        AppId = "12345678",
        AppName = "Updated Application Name",
        DefaultNumberApp = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateApplicationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Applications.<a href="/src/Vobiz/Applications/ApplicationsClient.cs">DeleteApplicationAsync</a>(DeleteApplicationRequest { ... }) -> WithRawResponseTask&lt;string?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete an Application. If the application is associated
with phone numbers, the deletion may be blocked unless those
associations are removed first.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Applications.DeleteApplicationAsync(
    new DeleteApplicationRequest { AuthId = "MA_XXXXXX", AppId = "12345678" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteApplicationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Endpoints
<details><summary><code>client.Endpoints.<a href="/src/Vobiz/Endpoints/EndpointsClient.cs">ListEndpointsAsync</a>(ListEndpointsRequest { ... }) -> WithRawResponseTask&lt;ListEndpointsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a paginated list of all SIP endpoints in your account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Endpoints.ListEndpointsAsync(new ListEndpointsRequest { AuthId = "MA_XXXXXX" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListEndpointsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Endpoints.<a href="/src/Vobiz/Endpoints/EndpointsClient.cs">CreateEndpointAsync</a>(CreateEndpointRequest { ... }) -> WithRawResponseTask&lt;CreateEndpointResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new SIP endpoint that can be used to make and receive calls
through IP phones, softphones, or SIP clients. Each endpoint is
assigned a unique SIP URI and endpoint ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Endpoints.CreateEndpointAsync(
    new CreateEndpointRequest
    {
        AuthId = "MA_XXXXXX",
        Username = "john_doe",
        Password = "SecurePassword123!",
        Alias = "John's Desktop Phone",
        Application = 12345678,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateEndpointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Endpoints.<a href="/src/Vobiz/Endpoints/EndpointsClient.cs">RetrieveEndpointAsync</a>(RetrieveEndpointRequest { ... }) -> WithRawResponseTask&lt;RetrieveEndpointResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the details of an existing endpoint. The response includes
all endpoint attributes and, if the endpoint is currently registered
on a SIP client, additional registration details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Endpoints.RetrieveEndpointAsync(
    new RetrieveEndpointRequest { AuthId = "MA_XXXXXX", EndpointId = "87654321" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RetrieveEndpointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Endpoints.<a href="/src/Vobiz/Endpoints/EndpointsClient.cs">UpdateEndpointAsync</a>(UpdateEndpointRequest { ... }) -> WithRawResponseTask&lt;string&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing endpoint's configuration. You can change the
password, alias, or attached application. The fields `username`,
`endpoint_id`, `domain`, `allow_same_domain`, `allow_other_domains`,
`allow_phones`, and `allow_apps` are locked after creation.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Endpoints.UpdateEndpointAsync(
    new UpdateEndpointRequest
    {
        AuthId = "MA_XXXXXX",
        EndpointId = "87654321",
        Alias = "John's Updated Desktop Phone",
        Password = "NewSecurePassword456!",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateEndpointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Endpoints.<a href="/src/Vobiz/Endpoints/EndpointsClient.cs">DeleteEndpointAsync</a>(DeleteEndpointRequest { ... }) -> WithRawResponseTask&lt;string?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete an endpoint from your Vobiz account. Once deleted,
the SIP URI will no longer be accessible, and any devices registered
with this endpoint will be disconnected.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Endpoints.DeleteEndpointAsync(
    new DeleteEndpointRequest { AuthId = "MA_XXXXXX", EndpointId = "87654321" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteEndpointRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Partner API
<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">GetPartnerProfileAsync</a>() -> WithRawResponseTask&lt;GetPartnerProfileResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the authenticated partner's profile and balance.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.GetPartnerProfileAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">GetPartnerDashboardAsync</a>() -> WithRawResponseTask&lt;GetPartnerDashboardResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Aggregated partner metrics - total customers, active accounts, balance
held across the partner ecosystem, MTD revenue, etc.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.GetPartnerDashboardAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">ListCustomerAccountsAsync</a>(ListCustomerAccountsRequest { ... }) -> WithRawResponseTask&lt;ListCustomerAccountsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns all customer sub-accounts under your partner account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.ListCustomerAccountsAsync(new ListCustomerAccountsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCustomerAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">CreateCustomerAccountAsync</a>(CreateCustomerAccountRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new customer sub-account under your partner account. Vobiz
emails the customer their login credentials and (separately) a KYC link
via the kyc-sessions endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.CreateCustomerAccountAsync(
    new CreateCustomerAccountRequest
    {
        Name = "John Doe",
        Email = "john@example.com",
        Phone = "+919876543210",
        Password = "SecurePass123!",
        Country = "IN",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateCustomerAccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">PartnerTransferBalanceAsync</a>(PartnerTransferBalanceRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Atomically debits your partner master balance and credits the customer's
wallet. Both legs are recorded in each account's ledger. Transfers are
**permanent and cannot be reversed.**
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.PartnerTransferBalanceAsync(
    new PartnerTransferBalanceRequest
    {
        CustomerAuthId = "MA_ZKITB8Z2",
        Amount = 500,
        Currency = "INR",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PartnerTransferBalanceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">ListCustomerTransactionsAsync</a>(ListCustomerTransactionsRequest { ... }) -> WithRawResponseTask&lt;ListCustomerTransactionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the customer's transaction ledger. Filter by date range or
transaction type. Useful for billing reconciliation.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.ListCustomerTransactionsAsync(
    new ListCustomerTransactionsRequest
    {
        CustomerAuthId = "customer_auth_id",
        FromDate = new DateOnly(2026, 3, 1),
        ToDate = new DateOnly(2026, 3, 31),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCustomerTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">ListCustomerCdrsAsync</a>(ListCustomerCdrsRequest { ... }) -> WithRawResponseTask&lt;ListCustomerCdrsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Look up any customer's call history. Same filter set as the
customer-side CDR endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.ListCustomerCdrsAsync(
    new ListCustomerCdrsRequest { CustomerAuthId = "customer_auth_id", HangupCause = "NO_ANSWER" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCustomerCdrsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">ListCustomerNumbersAsync</a>(ListCustomerNumbersRequest { ... }) -> WithRawResponseTask&lt;ListCustomerNumbersResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Phone numbers currently assigned to a customer account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.ListCustomerNumbersAsync(
    new ListCustomerNumbersRequest { CustomerAuthId = "customer_auth_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCustomerNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">ListKycSessionsAsync</a>(ListKycSessionsRequest { ... }) -> WithRawResponseTask&lt;ListKycSessionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the authenticated partner's KYC sessions. Filter the list by
session status or customer account, and use `page` and `size` to
paginate the results.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.ListKycSessionsAsync(new ListKycSessionsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListKycSessionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">CreateKycSessionAsync</a>(CreateKycSessionRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Triggers Vobiz to email a KYC link to the customer. KYC is OTP-based
(PAN + Aadhaar via DigiLocker for individuals, PAN + GSTIN for
companies). No document uploads required.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.CreateKycSessionAsync(
    new CreateKycSessionRequest { AccountAuthId = "MA_ZKITB8Z2" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateKycSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">GetKycSessionAsync</a>(GetKycSessionRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the current status and available details for one KYC session
owned by the authenticated partner.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.GetKycSessionAsync(new GetKycSessionRequest { SessionId = "session_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetKycSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">RevokeKycSessionAsync</a>(RevokeKycSessionRequest { ... }) -> WithRawResponseTask&lt;object&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels an outstanding KYC session. Customer can no longer use the link.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.RevokeKycSessionAsync(
    new RevokeKycSessionRequest { SessionId = "session_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RevokeKycSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PartnerApi.<a href="/src/Vobiz/PartnerApi/PartnerApiClient.cs">ResendKycSessionAsync</a>(ResendKycSessionRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Re-dispatches the KYC link to the customer. Rate-limited to once per 30 minutes.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PartnerApi.ResendKycSessionAsync(
    new ResendKycSessionRequest { SessionId = "session_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ResendKycSessionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Messages
<details><summary><code>client.Sms.Messages.<a href="/src/Vobiz/Sms/Messages/MessagesClient.cs">ListMessagesAsync</a>(ListMessagesRequest { ... }) -> WithRawResponseTask&lt;MessageList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the messages on your account, sent and received, newest first. Combine the filters to find a message you did not keep the `id` for, such as the other recipients of a multi-recipient send (filter by `tag` or `to`). Every filter is an exact match, and filters you omit are not applied. Page through results with `limit` and `offset`, and use `total` to know when to stop.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Messages.ListMessagesAsync(new ListMessagesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListMessagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Messages.<a href="/src/Vobiz/Sms/Messages/MessagesClient.cs">SendMessageAsync</a>(SendMessageRequest { ... }) -> WithRawResponseTask&lt;Message&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sends an SMS, MMS or RCS message from one of your numbers or RCS senders to one or more recipients. Each number in `to` becomes its own message, with its own `id`, status and conversation, and the response body is the first recipient's message. Every recipient is checked against your opt-out list first, and a send with a future `scheduledAt` is stored with status `scheduled`.

- `201` when every recipient was accepted, including an idempotent replay and a successful SMS fallback.
- `202` when at least one recipient was recorded and at least one errored. Find the other recipients with `GET /messages` filtered by `tag` or `to`.
- `422` when the recipient has opted out and nothing was recorded.
- `502` when the send was rejected before a message was recorded. Retry with the same `idempotencyKey`.

Track delivery with `GET /messages/{id}`, your webhooks (callbacks) or the WebSocket.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Messages.SendMessageAsync(
    new SendMessageRequest
    {
        From = "+14155550100",
        To = new List<string>() { "+14155550123" },
        Channel = SendMessageRequestChannel.Sms,
        Text = "Your verification code is 482913",
        IdempotencyKey = "otp-482913-user-77",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SendMessageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Messages.<a href="/src/Vobiz/Sms/Messages/MessagesClient.cs">PreviewMessageCostAsync</a>(PreviewMessageCostRequest { ... }) -> WithRawResponseTask&lt;CostPreview&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Prices a message before you send it, without sending anything. It splits `text` into segments for the chosen channel and returns the segment count, the price per segment and the total in your account currency. Use it to show a cost estimate in your app or to keep long messages within a budget. The figures are for one recipient; multiply `totalCost` by the number of recipients for a multi-recipient send.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Messages.PreviewMessageCostAsync(
    new PreviewMessageCostRequest { From = "+14155550100", To = "+14155550123" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PreviewMessageCostRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Messages.<a href="/src/Vobiz/Sms/Messages/MessagesClient.cs">CheckRcsReachabilityAsync</a>(CheckRcsReachabilityRequest { ... }) -> WithRawResponseTask&lt;RcsReachability&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Checks whether a phone number can receive RCS messages from your RCS sender, without sending anything. Call it before an RCS send to choose between RCS and SMS for that contact. If `reachable` is `false`, send with `channel: "sms"` instead, or send RCS with `failoverToSms: true` so Vobiz falls back to SMS automatically.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Messages.CheckRcsReachabilityAsync(
    new CheckRcsReachabilityRequest { From = "YOUR_RCS_SENDER_NAME", To = "+14155550123" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CheckRcsReachabilityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Messages.<a href="/src/Vobiz/Sms/Messages/MessagesClient.cs">GetMessageAsync</a>(GetMessageRequest { ... }) -> WithRawResponseTask&lt;MessageWithHistory&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one message with its full status history. Use it to follow a message from `sent` to `delivered` or `failed`, and to read `errorCode` and `errorMessage` when it fails. The `statusHistory` array lists every status change, oldest first. For real-time updates, subscribe to webhooks (callbacks) or the WebSocket instead of polling.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Messages.GetMessageAsync(
    new GetMessageRequest { Id = "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetMessageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Numbers
<details><summary><code>client.Sms.Numbers.<a href="/src/Vobiz/Sms/Numbers/NumbersClient.cs">ListNumbersAsync</a>() -> WithRawResponseTask&lt;SmsNumberList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns every number on your account that is routed for SMS or MMS, sorted by `countryCode` and then `e164`. Each number carries its US registration state, the last message it sent and a `sendable` summary of where it can send right now. Check `sendable.usDomestic` before you send to US recipients from a US number. To add numbers, search with `GET /numbers/available` and buy with `POST /numbers/purchase`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Numbers.ListNumbersAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Numbers.<a href="/src/Vobiz/Sms/Numbers/NumbersClient.cs">ListCountriesAsync</a>() -> WithRawResponseTask&lt;NumberCountries&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the countries where you can buy messaging numbers, with the number types and capabilities in stock in each. The list is a snapshot that refreshes in the background: while `ready` is `false`, `countries` is empty and you retry shortly. India is not listed, because traffic to Indian recipients is sent from DLT-registered sender IDs. Pass a returned `country` to `GET /numbers/available` to see individual numbers.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Numbers.ListCountriesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Numbers.<a href="/src/Vobiz/Sms/Numbers/NumbersClient.cs">SearchAvailableNumbersAsync</a>(SearchAvailableNumbersRequest { ... }) -> WithRawResponseTask&lt;AvailableNumbersResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches the inventory for numbers you can buy in one country, with their setup and monthly prices in your wallet currency. Each search returns up to 10 numbers. Pass the chosen `e164`, the `country` and any non-empty `numberKey` to `POST /numbers/purchase`. For `country=IN` the list is empty and `hint` explains that Indian traffic uses DLT-registered sender IDs. A country outside the set Vobiz sells numbers in returns `422`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Numbers.SearchAvailableNumbersAsync(
    new SearchAvailableNumbersRequest
    {
        Country = "US",
        Capabilities = "SMS,MMS",
        AreaCode = "415",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchAvailableNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Numbers.<a href="/src/Vobiz/Sms/Numbers/NumbersClient.cs">PurchaseNumberAsync</a>(PurchaseNumberRequest { ... }) -> WithRawResponseTask&lt;PurchaseNumberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Buys a number returned by `GET /numbers/available` and routes it to your account for messaging. This call spends money: it debits the setup fee and the first month's rental from your wallet before the number is bought, and the rental renews monthly until you release the number. If the purchase cannot complete after the debit, your wallet is refunded and the error message says so. Run it only with your own credentials once you have confirmed the number and price. A `numbers.updated` WebSocket event is published when the number goes live; a US number then needs a 10DLC campaign or toll-free verification before it can send to US recipients.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Numbers.PurchaseNumberAsync(
    new PurchaseNumberRequest { E164 = "+14155550100", Country = "US" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PurchaseNumberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Numbers.<a href="/src/Vobiz/Sms/Numbers/NumbersClient.cs">ListPurchasesAsync</a>() -> WithRawResponseTask&lt;NumberPurchaseList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the numbers you have bought through Vobiz, newest first, each with its full list of wallet charges. Released numbers stay in the list with `status: released`, so this is the billing history of every number you have owned. Use `nextBillingAt` to see when each active number renews and `charges` to reconcile setup and rental debits.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Numbers.ListPurchasesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Numbers.<a href="/src/Vobiz/Sms/Numbers/NumbersClient.cs">ReleaseNumberAsync</a>(ReleaseNumberRequest { ... }) -> WithRawResponseTask&lt;ReleaseNumberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels a number you bought through Vobiz and removes it from your account. The number stops sending and receiving messages immediately, and monthly rental stops. The setup fee and the current month are not refunded, and a released number cannot be restored. The call has no request body and returns the purchase with `status: released`. Run it only with your own credentials once you are sure you no longer need the number.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Numbers.ReleaseNumberAsync(new ReleaseNumberRequest { E164 = "+14155550100" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReleaseNumberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Coverage
<details><summary><code>client.Sms.Coverage.<a href="/src/Vobiz/Sms/Coverage/CoverageClient.cs">ListCoverageAsync</a>(ListCoverageRequest { ... }) -> WithRawResponseTask&lt;CoverageList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one summary row per destination country, sorted by country name: the sender types it accepts, whether sender registration is required, two-way support, opt-out rules and whether a sending window applies. Use it to plan where to send and which sender to use before you buy numbers or register. Filters combine, so `region` plus `twoWay=true` returns only two-way countries in that region. For the full record of one country, call `GET /coverage/{country}`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Coverage.ListCoverageAsync(
    new ListCoverageRequest { Q = "united", Region = "Northern America" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCoverageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Coverage.<a href="/src/Vobiz/Sms/Coverage/CoverageClient.cs">GetCoverageAsync</a>(GetCoverageRequest { ... }) -> WithRawResponseTask&lt;CoverageDetail&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the full coverage record for one country: accepted sender types, registration requirements and lead time, link rules, prohibited topics, the permitted sending window and free-text market notes. Read it before your first send to a new country so your sender, content and send times match the local rules. An unknown code returns `404` with `country not found`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Coverage.GetCoverageAsync(new GetCoverageRequest { Country = "US" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCoverageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Conversations
<details><summary><code>client.Sms.Conversations.<a href="/src/Vobiz/Sms/Conversations/ConversationsClient.cs">ListConversationsAsync</a>(ListConversationsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;Conversation&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns your conversations, most recently active first (ordered by `lastMessageAt`). A conversation is the thread between one of your numbers and one contact on one channel, and Vobiz creates it with the first message in either direction. The response is a bare JSON array, `[]` when you have none. Page with `limit` and `offset`; when a page returns fewer items than `limit`, you have reached the end.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Conversations.ListConversationsAsync(new ListConversationsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListConversationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Conversations.<a href="/src/Vobiz/Sms/Conversations/ConversationsClient.cs">UnreadCountAsync</a>() -> WithRawResponseTask&lt;UnreadCount&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the total of `unreadCount` across all your conversations. Use it for an inbox badge, then call `GET /conversations` to see which threads are unread. The total drops when you mark a conversation read with `POST /conversations/{id}/read`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Conversations.UnreadCountAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Conversations.<a href="/src/Vobiz/Sms/Conversations/ConversationsClient.cs">GetConversationAsync</a>(GetConversationRequest { ... }) -> WithRawResponseTask&lt;Conversation&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one conversation with its participants, channel and counters. Use it to refresh a thread's `unreadCount` or `lastMessageAt` after a new message arrives. To read the messages themselves, call `GET /conversations/{id}/messages`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Conversations.GetConversationAsync(
    new GetConversationRequest { Id = "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetConversationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Conversations.<a href="/src/Vobiz/Sms/Conversations/ConversationsClient.cs">ListConversationMessagesAsync</a>(ListConversationMessagesRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;Message&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the messages in one conversation, in both directions, newest first. Use it to render a chat thread: reverse the page to show it oldest to newest. The response is a bare JSON array of message objects without `statusHistory`; call `GET /messages/{id}` for one message's history. Page with `limit` and `offset`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Conversations.ListConversationMessagesAsync(
    new ListConversationMessagesRequest { Id = "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListConversationMessagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Conversations.<a href="/src/Vobiz/Sms/Conversations/ConversationsClient.cs">MarkConversationReadAsync</a>(MarkConversationReadRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Marks a conversation as read: it sets `unreadCount` to `0` and `lastReadAt` to the current time. Call it when a user opens the thread in your inbox. It takes no request body, and calling it on a thread that is already read is harmless. The account-wide total from `GET /conversations/unread-count` drops by the thread's previous `unreadCount`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Conversations.MarkConversationReadAsync(
    new MarkConversationReadRequest { Id = "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MarkConversationReadRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Opt-outs
<details><summary><code>client.Sms.OptOuts.<a href="/src/Vobiz/Sms/OptOuts/OptOutsClient.cs">ListOptOutsAsync</a>(ListOptOutsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;OptOut&gt;?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the numbers on your opt-out list, newest first, including entries created from STOP, START and HELP keyword replies and the ones you added. Pass both `limit` and `offset` on every call: the response is a bare JSON array, and it is `null` when the page has no records (including when `limit` is missing). Page by increasing `offset` until a page returns fewer items than `limit` or `null`. To check a single number, use `GET /opt-outs/{phoneNumber}` instead.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.OptOuts.ListOptOutsAsync(new ListOptOutsRequest { Limit = 1, Offset = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListOptOutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.OptOuts.<a href="/src/Vobiz/Sms/OptOuts/OptOutsClient.cs">CreateOptOutAsync</a>(CreateOptOutRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds a phone number to your opt-out list for one channel, so Vobiz stops messages to it. After this, `POST /messages` to that number on that channel returns `422` and broadcasts skip it. An `sms` opt-out also blocks `mms`. Use it to record consent withdrawn outside a keyword reply, for example on a call or a web form. Creating the same number and channel again updates the stored `reason` instead of adding a second record.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.OptOuts.CreateOptOutAsync(
    new CreateOptOutRequest
    {
        PhoneNumber = "+14155550123",
        Channel = "sms",
        Reason = "customer request",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateOptOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.OptOuts.<a href="/src/Vobiz/Sms/OptOuts/OptOutsClient.cs">CheckOptOutAsync</a>(CheckOptOutRequest { ... }) -> WithRawResponseTask&lt;OptOutCheck&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Tells you whether a phone number is on your opt-out list for a channel. Call it before a send to skip a blocked contact instead of handling a `422` from `POST /messages`. The response is always `200` with `optedOut` set to `true` or `false`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.OptOuts.CheckOptOutAsync(
    new CheckOptOutRequest { PhoneNumber = "+14155550123", Channel = "sms" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CheckOptOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.OptOuts.<a href="/src/Vobiz/Sms/OptOuts/OptOutsClient.cs">DeleteOptOutAsync</a>(DeleteOptOutRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes a phone number from your opt-out list for one channel, so you can message it again on that channel. Do this only after the contact has given consent again, for example after they reply `START`. The response is `200` whether or not a record existed, so it is safe to retry. Removing an opt-out on one channel leaves entries on other channels in place; delete each one separately.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.OptOuts.DeleteOptOutAsync(
    new DeleteOptOutRequest { PhoneNumber = "+14155550123", Channel = "sms" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteOptOutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Webhooks
<details><summary><code>client.Sms.Webhooks.<a href="/src/Vobiz/Sms/Webhooks/WebhooksClient.cs">ListWebhooksAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;WebhookSubscription&gt;?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns all of your webhook subscriptions, newest first, as a bare JSON array. The body is `null` rather than `[]` when you have none, so treat `null` as an empty list. The response includes each subscription's `secret`, so keep it out of logs and client-side code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Webhooks.ListWebhooksAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Webhooks.<a href="/src/Vobiz/Sms/Webhooks/WebhooksClient.cs">CreateWebhookAsync</a>(CreateWebhookRequest { ... }) -> WithRawResponseTask&lt;WebhookSubscription&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Registers an HTTPS endpoint that receives the events you subscribe to as signed `POST` requests. Only `url` is required; omit `events` to subscribe to `message.received`, `message.delivered` and `message.failed`. Every delivery carries `X-Webhook-ID`, `X-Webhook-Event` and `X-Webhook-Signature`, a lower-case hex HMAC-SHA256 of the raw body keyed with your `secret`. The subscription is active as soon as it is created; see the Webhooks guide for the payload envelope and a verification example.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Webhooks.CreateWebhookAsync(
    new CreateWebhookRequest
    {
        Url = "https://example.com/vobiz/webhooks",
        Secret = "YOUR_WEBHOOK_SECRET",
        Events = new List<WebhookEvent>()
        {
            WebhookEvent.MessageReceived,
            WebhookEvent.MessageDelivered,
            WebhookEvent.MessageFailed,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateWebhookRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Webhooks.<a href="/src/Vobiz/Sms/Webhooks/WebhooksClient.cs">GetWebhookAsync</a>(GetWebhookRequest { ... }) -> WithRawResponseTask&lt;WebhookSubscription&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one webhook subscription with its URL, events, `active` flag and signing secret. Use it to confirm the result of an update, since `PUT /webhooks/{id}` returns only `{"status":"ok"}`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Webhooks.GetWebhookAsync(
    new GetWebhookRequest { Id = "2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetWebhookRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Webhooks.<a href="/src/Vobiz/Sms/Webhooks/WebhooksClient.cs">UpdateWebhookAsync</a>(UpdateWebhookRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes any subset of `url`, `secret`, `events` and `active`. Fields you omit keep their current value; a field you send, including an empty string, replaces it. Set `active` to `false` to pause deliveries without losing the subscription, and back to `true` to resume. The response is `{"status":"ok"}`, so call `GET /webhooks/{id}` to read the updated subscription.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Webhooks.UpdateWebhookAsync(
    new UpdateWebhookRequest
    {
        Id = "2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e",
        Events = new List<WebhookEvent>()
        {
            WebhookEvent.MessageDelivered,
            WebhookEvent.MessageFailed,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateWebhookRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Webhooks.<a href="/src/Vobiz/Sms/Webhooks/WebhooksClient.cs">DeleteWebhookAsync</a>(DeleteWebhookRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes the subscription and stops all deliveries to its URL. The response is `200` with `{"status":"ok"}`. To stop deliveries temporarily and keep the configuration, set `active` to `false` with `PUT /webhooks/{id}` instead.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Webhooks.DeleteWebhookAsync(
    new DeleteWebhookRequest { Id = "2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteWebhookRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Broadcasts
<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">ListBroadcastsAsync</a>(ListBroadcastsRequest { ... }) -> WithRawResponseTask&lt;BroadcastList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the broadcasts on your account, newest first, each with freshly counted `stats`. The response wraps the page in `broadcasts` and gives the account-wide count in `total`, so you can page with `limit` and `offset` until `offset` reaches `total`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.ListBroadcastsAsync(new ListBroadcastsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBroadcastsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">CreateBroadcastAsync</a>(BroadcastInput { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a broadcast in `draft` status with zero `stats` and no recipients. Only `name` and `from` are required; `channel` defaults to `sms` and `ratePerSecond` to 5. Nothing is sent when you create a broadcast. Next, upload recipients with `POST /broadcasts/{id}/recipients`, check the rendered text with `GET /broadcasts/{id}/preview`, then start sending with `POST /broadcasts/{id}/launch`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.CreateBroadcastAsync(
    new BroadcastInput
    {
        Name = "October pricing update",
        From = "+14155550100",
        Template = "Hi {{name}}, your refund of {{amount}} is on its way.",
        RatePerSecond = 5,
        Tag = "pricing-oct",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BroadcastInput` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">GetBroadcastAsync</a>(GetBroadcastRequest { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one broadcast with its configuration, current `status` and freshly counted `stats`. Poll it while a broadcast runs to follow progress, or subscribe to the `broadcast.updated` WebSocket event. For per-recipient results, use `GET /broadcasts/{id}/recipients` or `GET /broadcasts/{id}/export`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.GetBroadcastAsync(
    new GetBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">UpdateBroadcastAsync</a>(UpdateBroadcastRequest { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes a `draft` broadcast. Send only the fields you want to change; fields you leave out, or send as `null`, keep their value, except `scheduledAt`, where `null` or `""` clears a scheduled start. The same validation as create applies, so `name` and `from` cannot be set to an empty string. A broadcast in any other status returns `409` with `cannot edit a broadcast that is <status>`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.UpdateBroadcastAsync(
    new UpdateBroadcastRequest
    {
        Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
        Body = new BroadcastUpdateInput
        {
            Template = "Hi {{name}}, your refund of {{amount}} has been issued.",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">DeleteBroadcastAsync</a>(DeleteBroadcastRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently removes a `draft` or `cancelled` broadcast together with its recipient list and returns `204` with no body. Any other status returns `409` with `cannot delete a broadcast that is <status>`, so cancel a scheduled, running or paused broadcast first. Completed broadcasts are kept as your sending record.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.DeleteBroadcastAsync(
    new DeleteBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">ListRecipientsAsync</a>(ListRecipientsRequest { ... }) -> WithRawResponseTask&lt;BroadcastRecipientList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the broadcast's recipients in upload order, each with its template `variables` and per-recipient send state. Filter by `status` to find failures, opted-out numbers or rows still waiting to send. The response gives the page in `recipients` and the count matching your filter in `total`. For a downloadable file of the same data, use `GET /broadcasts/{id}/export`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.ListRecipientsAsync(
    new ListRecipientsRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListRecipientsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">UploadRecipientsAsync</a>(UploadRecipientsJson { ... }) -> WithRawResponseTask&lt;UploadResult&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sets the recipient list of a `draft` broadcast; each upload replaces the previous list. Send `multipart/form-data` with a `.csv` or `.xlsx` `file` (10 MB maximum) to use template variables from extra columns, or JSON with a `numbers` array for a plain list. Numbers without a country code are normalised to E.164 with `defaultCountry` (default `US`). Duplicates are dropped, invalid rows are reported in `invalid`, and numbers that opted out of SMS from you are kept with status `opted_out` and never sent. A broadcast can hold up to 10,000 recipients; a larger list returns `422`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.UploadRecipientsAsync(
    new UploadRecipientsJson
    {
        Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
        Numbers = new List<string>() { "+14155550123", "+14155550124", "415 555 0125" },
        DefaultCountry = UploadRecipientsJsonDefaultCountry.Us,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UploadRecipientsJson` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">PreviewBroadcastAsync</a>(PreviewBroadcastRequest { ... }) -> WithRawResponseTask&lt;BroadcastPreview&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Renders the template for the first pending recipients so you can check personalisation, encoding and segment counts before you launch. Nothing is sent and nothing is charged. `missingVariables` lists placeholders that have no matching upload column; they render as empty text, so fix the template or re-upload before launching. `estimatedSegments` totals the segments across every pending recipient, not only the samples shown.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.PreviewBroadcastAsync(
    new PreviewBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PreviewBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">ExportBroadcastAsync</a>(ExportBroadcastRequest { ... }) -> WithRawResponseTask&lt;string&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Downloads every recipient with its send result as a CSV file (`text/csv`), named `broadcast-<id>.csv`. The columns are `row`, `to`, `status`, `message_id`, `error_code`, `error_message` and `sent_at`, followed by one column per column of your upload. Text cells that start with `=`, `+`, `-`, `@`, a tab or a carriage return are prefixed with `'` so they open safely in spreadsheet applications. You can export a broadcast in any status, including a draft, to check the parsed list.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.ExportBroadcastAsync(new ExportBroadcastRequest { Id = "id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ExportBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">LaunchBroadcastAsync</a>(LaunchBroadcastRequest { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Starts sending. This sends real SMS to every `pending` recipient and charges your account per segment, so call it only with your own credentials on a list you have consent to message. Only a `draft` can be launched; it moves to `running`, or to `scheduled` when `scheduledAt` is in the future. Launch returns `422` when the template is empty, when no recipient is pending, or when a phone-number `from` is not an SMS number on your account. Each recipient is sent like `POST /messages` with the broadcast's `tag` and DLT IDs and the idempotency key `broadcast:<broadcastId>:<recipientId>`, so no recipient is messaged twice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.LaunchBroadcastAsync(
    new LaunchBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LaunchBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">PauseBroadcastAsync</a>(PauseBroadcastRequest { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Pauses a `running` broadcast. Sending stops after the messages already in flight, and pending recipients stay `pending` until you resume or cancel. Any other status returns `409` with `cannot pause a broadcast that is <status>`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.PauseBroadcastAsync(
    new PauseBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PauseBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">ResumeBroadcastAsync</a>(ResumeBroadcastRequest { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Continues sending to the pending recipients of a `paused` broadcast and moves it back to `running`. This sends real messages and charges your account per segment. It also resumes a broadcast paused with `pauseReason` `insufficient_balance` once you have topped up. Any other status returns `409` with `cannot resume a broadcast that is <status>`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.ResumeBroadcastAsync(
    new ResumeBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ResumeBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Broadcasts.<a href="/src/Vobiz/Sms/Broadcasts/BroadcastsClient.cs">CancelBroadcastAsync</a>(CancelBroadcastRequest { ... }) -> WithRawResponseTask&lt;Broadcast&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Stops a broadcast for good and sets `completedAt`. You can cancel from `draft`, `scheduled`, `running` or `paused`; a `completed`, `failed` or already `cancelled` broadcast returns `409`. Pending recipients become `skipped`, and messages already sent are unaffected. A cancelled broadcast cannot be resumed or edited, but it can be deleted.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Broadcasts.CancelBroadcastAsync(
    new CancelBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CancelBroadcastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## RCS Senders
<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">ListSendersAsync</a>(ListSendersRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;Sender&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the RCS senders on your account as a bare JSON array, without a total count. Page through them with `limit` and `offset`; an empty array means you have reached the end. `status` here is the last stored value, so call `GET /senders/{id}/status` for the latest state.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.ListSendersAsync(new ListSendersRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListSendersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">CreateSenderAsync</a>(CreateSenderRequest { ... }) -> WithRawResponseTask&lt;Sender&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Registers a new RCS sender (agent) with the RCS platform and stores it on your account with status `pending`. `provider` and `senderName` are required; the profile fields are reviewed by the RCS platform and the carriers before the sender can reach real users. Poll `GET /senders/{id}/status` until the platform reports it as launched, then send with its `senderName` as `from` and `channel: rcs` on `POST /messages`. A rejected request returns `400` with the platform's reason in `error`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.CreateSenderAsync(
    new CreateSenderRequest
    {
        Provider = "YOUR_ROUTING_IDENTIFIER",
        SenderName = "example-brand",
        DisplayName = "Example Brand",
        Description = "Order updates and support for Example Brand customers.",
        BillingCategory = "CONVERSATIONAL",
        UseCase = "TRANSACTIONAL",
        HostingRegion = "NORTH_AMERICA",
        Brand = new SenderBrand { BrandName = "Example Brand" },
        Color = "#1A73E8",
        Phones = new List<SenderPhone>()
        {
            new SenderPhone { PhoneNumber = "+14155550100", Label = "Support" },
        },
        Emails = new List<SenderEmail>()
        {
            new SenderEmail { Address = "support@example.com", Label = "Support" },
        },
        Websites = new List<SenderWebsite>()
        {
            new SenderWebsite { Url = "https://example.com", Label = "Website" },
        },
        BannerUrl = "https://example.com/rcs/banner.jpg",
        LogoUrl = "https://example.com/rcs/logo.png",
        Privacy = new SenderLink { Url = "https://example.com/privacy", Label = "Privacy policy" },
        TermsOfService = new SenderLink
        {
            Url = "https://example.com/terms",
            Label = "Terms of service",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateSenderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">GetSenderAsync</a>(GetSenderRequest { ... }) -> WithRawResponseTask&lt;Sender&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one RCS sender as stored on your account, including its full profile. `status` is the last value stored on your account; call `GET /senders/{id}/status` to refresh it from the RCS platform. An unknown id returns `404`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.GetSenderAsync(
    new GetSenderRequest { Id = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetSenderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">UpdateSenderAsync</a>(UpdateSenderRequest { ... }) -> WithRawResponseTask&lt;Sender&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the sender's profile on the RCS platform and then on your account, and returns the updated sender. Send only the fields you want to change; fields you leave out keep their value. `provider`, `senderName` and `hostingRegion` are fixed after creation. Every failure, including an unknown id, returns `400`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.UpdateSenderAsync(
    new UpdateSenderRequest
    {
        Id = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
        DisplayName = "Example Brand Support",
        Description = "Order updates, returns and support for Example Brand customers.",
        Websites = new List<SenderWebsite>()
        {
            new SenderWebsite { Url = "https://example.com/help", Label = "Help centre" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateSenderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">GetSenderStatusAsync</a>(GetSenderStatusRequest { ... }) -> WithRawResponseTask&lt;Sender&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Asks the RCS platform for the sender's current launch status, stores it on the sender and returns the full sender. Poll it after `POST /senders` or a profile update until `status` shows the sender is live, then start sending. Every failure, including an unknown id, returns `400`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.GetSenderStatusAsync(
    new GetSenderStatusRequest { Id = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetSenderStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">ListTemplatesAsync</a>(ListTemplatesRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;Template&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the templates registered on one RCS sender as a bare JSON array, without a total count. Page through them with `limit` and `offset`. `status` is the last stored value; refresh one template with its `/status` endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.ListTemplatesAsync(
    new ListTemplatesRequest { SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListTemplatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">CreateTemplateAsync</a>(CreateTemplateRequest { ... }) -> WithRawResponseTask&lt;Template&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Registers a message template on an RCS sender with the RCS platform and returns it with status `pending`. `templateName`, `type` and `content` are passed to the platform unchanged, so use the template types and content shapes the RCS platform defines. Call `GET /senders/{senderId}/templates/{templateName}/status` to follow approval. An unknown sender or a platform rejection returns `400`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.CreateTemplateAsync(
    new CreateTemplateRequest
    {
        SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
        TemplateName = "order-shipped",
        Type = "TEXT",
        Content = new Dictionary<string, object?>()
        {
            { "text", "Your order {{orderId}} has shipped and arrives on {{eta}}." },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateTemplateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">GetTemplateAsync</a>(GetTemplateRequest { ... }) -> WithRawResponseTask&lt;Template&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one template as stored on your account, including the `content` you submitted. For the latest approval state from the RCS platform, call `GET /senders/{senderId}/templates/{templateName}/status`. An unknown sender or template returns `404`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.GetTemplateAsync(
    new GetTemplateRequest
    {
        SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
        TemplateName = "appointment_reminder",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTemplateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">DeleteTemplateAsync</a>(DeleteTemplateRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes the template from the RCS platform and from your account, and returns `204` with no body. You cannot send with the template afterwards. An unknown sender or template returns `400`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.DeleteTemplateAsync(
    new DeleteTemplateRequest
    {
        SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
        TemplateName = "appointment_reminder",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteTemplateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.RcsSenders.<a href="/src/Vobiz/Sms/RcsSenders/RcsSendersClient.cs">GetTemplateStatusAsync</a>(GetTemplateStatusRequest { ... }) -> WithRawResponseTask&lt;Template&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Asks the RCS platform for the template's current approval status, stores it on the template and returns the full template. Poll it after `POST /senders/{senderId}/templates` until the template is approved. Every failure, including an unknown sender or template, returns `400`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.RcsSenders.GetTemplateStatusAsync(
    new GetTemplateStatusRequest
    {
        SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
        TemplateName = "appointment_reminder",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTemplateStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Brands
<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">ListBrandsAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;Brand&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns every brand on your account as a bare JSON array, newest first. The list is not paginated and reads the records stored on your account without contacting the registry; deleted brands are left out. Call `GET /10dlc/brands/{id}` for the latest registry state of one brand.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.ListBrandsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">CreateBrandAsync</a>(CreateBrandRequest { ... }) -> WithRawResponseTask&lt;Brand&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a brand, the business identity that US carriers associate with your 10DLC traffic, and mirrors it to the US 10DLC registry in `DRAFT` stage. `name` and `brandType` are required; send every other field your business has, because the registry reviews them when you register. Nothing is submitted for review until you call `POST /10dlc/brands/{id}/register`. Pass a `referenceId` so that a retried request (for example after a `502`) reconciles to the same brand instead of creating a second one. Next, register the brand, then create a campaign under it with `POST /10dlc/campaigns`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.CreateBrandAsync(
    new CreateBrandRequest
    {
        ReferenceId = "brand-example-corp-01",
        Name = "Example Corp",
        LegalName = "Example Corporation Inc.",
        BrandType = CreateBrandRequestBrandType.TendlcPrivateCompany,
        Website = "https://example.com",
        SupportEmail = "support@example.com",
        SupportPhone = "+14155550100",
        Vertical = "TECHNOLOGY",
        TaxId = "12-3456789",
        TaxIdIssuingCountry = "US",
        CountryCode = "US",
        Address = new BrandAddress
        {
            Street = "100 Example Street",
            City = "San Francisco",
            State = "CA",
            ZipCode = "94105",
        },
        BusinessContactFirstName = "Alex",
        BusinessContactLastName = "Doe",
        BusinessContactEmail = "alex.doe@example.com",
        LegalEntityType = "PRIVATE_COMPANY",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateBrandRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">GetBrandAsync</a>(GetBrandRequest { ... }) -> WithRawResponseTask&lt;Brand&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one brand after refreshing its `stage`, `registrationStatus`, `brandIdentityStatus` and `rejectionReasons` from the US 10DLC registry. The refresh is best-effort: if the registry is slow to answer, you get the stored record and `lastSyncedAt` tells you how fresh it is. Poll this endpoint (or listen for the `10dlc.brand.updated` WebSocket event) after registering to follow the review.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.GetBrandAsync(
    new GetBrandRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBrandRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">UpdateBrandAsync</a>(UpdateBrandRequest { ... }) -> WithRawResponseTask&lt;Brand&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replaces the brand with the body you send and pushes the change to the US 10DLC registry. This is a full replacement, not a patch: send the same shape as create, including `name` and `brandType`, and any field you leave out is cleared. `referenceId` is ignored on update. Use it to correct a brand before registering it, or to fix the points listed in `rejectionReasons` before resubmitting.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.UpdateBrandAsync(
    new UpdateBrandRequest
    {
        Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10",
        Body = new CreateBrandRequest
        {
            Name = "Example Corp",
            LegalName = "Example Corporation Inc.",
            BrandType = CreateBrandRequestBrandType.TendlcPrivateCompany,
            Website = "https://example.com",
            SupportEmail = "help@example.com",
            SupportPhone = "+14155550100",
            Vertical = "TECHNOLOGY",
            TaxId = "12-3456789",
            TaxIdIssuingCountry = "US",
            CountryCode = "US",
            Address = new BrandAddress
            {
                Street = "100 Example Street",
                City = "San Francisco",
                State = "CA",
                ZipCode = "94105",
            },
            BusinessContactFirstName = "Alex",
            BusinessContactLastName = "Doe",
            BusinessContactEmail = "alex.doe@example.com",
            LegalEntityType = "PRIVATE_COMPANY",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBrandRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">DeleteBrandAsync</a>(DeleteBrandRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes the brand from your account and from the US 10DLC registry and returns `204` with no body. A brand that still owns campaigns returns `409` with `conflict: brand still has N campaign(s); delete them first`, so delete or deregister its campaigns first. Deletion cannot be undone; a new brand needs a new registration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.DeleteBrandAsync(
    new DeleteBrandRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteBrandRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">RegisterBrandAsync</a>(RegisterBrandRequest { ... }) -> WithRawResponseTask&lt;Brand&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Submits the brand to the US 10DLC registry for identity verification. The brand moves from `DRAFT` to `SUBMITTED` and `registrationStatus` starts tracking the registrar's decision (`PENDING`, then `ACTIVE` or `REJECTED`). The request has no body and returns the refreshed brand. Submit only when the brand details are final and you intend to register this business. Follow progress with `GET /10dlc/brands/{id}` or `GET /10dlc/brands/{id}/registrar-statuses`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.RegisterBrandAsync(
    new RegisterBrandRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RegisterBrandRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">BrandRegistrarStatusesAsync</a>(BrandRegistrarStatusesRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BrandRegistrarStatus&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the brand's state at each registrar that has reviewed it, read live from the US 10DLC registry. Each entry carries the registrar's `state` and, when the registrar reports them, the identity result, the authentication status and a rejection reason. An empty array means no registrar has recorded a state yet. Use it to see why a brand is pending or rejected.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.BrandRegistrarStatusesAsync(
    new BrandRegistrarStatusesRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BrandRegistrarStatusesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">BrandAuthVerificationAsync</a>(BrandAuthVerificationRequest { ... }) -> WithRawResponseTask&lt;BrandAuthRequested&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Starts the registry's brand authentication for a brand whose `brandType` is `TENDLC_PUBLIC_COMPANY`. The registry sends a two-factor verification request to the brand's `businessContactEmail`, and the brand shows `registrationStatus` `PENDING_2FA` until the contact completes it. The request has no body and returns `202` with `{"status":"requested"}`. Any other brand type returns `400` with `invalid request: brand authentication is only available for TENDLC_PUBLIC_COMPANY brands`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.BrandAuthVerificationAsync(
    new BrandAuthVerificationRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BrandAuthVerificationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">Resend2FaAsync</a>(Resend2FaRequest { ... }) -> WithRawResponseTask&lt;BrandAuthRequested&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Asks the registry to send the brand-authentication verification again to the brand's `businessContactEmail`. Use it when a `TENDLC_PUBLIC_COMPANY` brand is `PENDING_2FA` and the contact did not receive or let the first request expire. The request has no body and returns `202` with `{"status":"requested"}`. Any other brand type returns `400`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.Resend2FaAsync(
    new Resend2FaRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `Resend2FaRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">VetBrandAsync</a>(BrandVetRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requests an external vet of a registered brand from the US 10DLC registry. A successful vet can raise the brand's trust tier and, with it, the throughput carriers grant its campaigns. `type` defaults to `STANDARD`; any value other than `STANDARD`, `ENHANCED` or `POLITICAL` returns `400`. Every call files a new vetting request, so send it only when you intend to. The response is the registry's vetting record, returned as received; list past vets with `GET /10dlc/brands/{id}/vets`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.VetBrandAsync(
    new BrandVetRequest
    {
        Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10",
        Type = BrandVetRequestType.Standard,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BrandVetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Brands.<a href="/src/Vobiz/Sms/Brands/BrandsClient.cs">ListBrandVetsAsync</a>(ListBrandVetsRequest { ... }) -> WithRawResponseTask&lt;BrandVetList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the brand's vetting records from the US 10DLC registry, one page at a time. The body is `{"results": [...], "paging": {...}}`, where each result is a registry vetting record passed through as received. `page` must be 0 or more and `size` between 0 and 100; other values return `400` with `page must be >= 0 and size between 0 and 100`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Brands.ListBrandVetsAsync(
    new ListBrandVetsRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBrandVetsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Campaigns
<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">ListCampaignsAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;Campaign&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns every 10DLC and toll-free campaign on your account as a bare JSON array, newest first. The list is not paginated and reads the records stored on your account without contacting the registry. Toll-free campaigns have `campaignType` `TOLL_FREE_UNIFIED_NUMBER` and no `brandId`. Call `GET /10dlc/campaigns/{id}` for the latest registry state of one campaign.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.ListCampaignsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">CreateCampaignAsync</a>(CreateCampaignRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a 10DLC campaign, the messaging program you run under one of your brands, and mirrors it to the US 10DLC registry in `DRAFT` stage. `name` and `brandId` are required; `campaignType` defaults to `TEN_DIGIT_LONG_CODE`. Upload any `supportingDocuments` or `mmsSampleFiles` with `POST /10dlc/documents` first. Pass a `referenceId` so a retried request reconciles to the same campaign. Next, submit the campaign with `POST /10dlc/campaigns/{id}/register`; toll-free verification uses `POST /10dlc/campaigns/toll-free` instead.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.CreateCampaignAsync(
    new CreateCampaignRequest
    {
        Name = "Example Corp account alerts",
        ProgramSummary =
            "Example Corp sends account and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
        ConfirmationMessage =
            "Example Corp: You are subscribed to account alerts. Msg frequency varies. Msg & data rates may apply. Reply HELP for help, STOP to opt out.",
        HelpMessage = "Example Corp: For help email support@example.com. Reply STOP to opt out.",
        StopMessage = "Example Corp: You have been unsubscribed. Reply HELP for help.",
        CustomerCarePhone = "+14155550100",
        CustomerCareEmail = "support@example.com",
        TermsAndConditionsUrl = "https://example.com/terms",
        PrivacyPolicyUrl = "https://example.com/privacy",
        ExampleMessages = new List<string>()
        {
            "Example Corp: Your support ticket #48213 was updated. View it at https://example.com/support. Reply STOP to opt out.",
            "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out.",
        },
        UseCases = new List<string>() { "ALERTS" },
        MessageTypes = new List<string>() { "SMS" },
        OptIns = new Dictionary<string, object?>()
        {
            {
                "web",
                new Dictionary<object, object?>()
                {
                    {
                        "callToAction",
                        "By checking this box you agree to receive account alerts from Example Corp. Msg frequency varies. Msg & data rates may apply. Reply STOP to opt out, HELP for help."
                    },
                    { "url", "https://example.com/signup" },
                }
            },
        },
        LowVolume = true,
        EmbeddedLink = true,
        Numbers = new List<string>() { "14155550100" },
        ReferenceId = "campaign-account-alerts-01",
        BrandId = "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
        CampaignType = CreateCampaignRequestCampaignType.TenDigitLongCode,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateCampaignRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">CreateTollFreeCampaignAsync</a>(TollFreeCampaignRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Starts toll-free verification for one or more toll-free numbers. The business details travel inside the request, so no brand is needed; only `name` is required, but the registry reviews every field you send. The campaign is created with `campaignType` `TOLL_FREE_UNIFIED_NUMBER` and no `brandId`. Pass a `referenceId` so a retried request reconciles to the same campaign, then submit it with `POST /10dlc/campaigns/{id}/register`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.CreateTollFreeCampaignAsync(
    new TollFreeCampaignRequest
    {
        ReferenceId = "tollfree-notifications-01",
        Name = "Example Corp toll-free notifications",
        PrivacyPolicyUrl = "https://example.com/privacy",
        TermsAndConditionsUrl = "https://example.com/terms",
        MessageVolume = "TEN_THOUSAND",
        Numbers = new List<string>() { "+18335550100" },
        UseCase = "NOTIFICATIONS",
        ProgramSummary =
            "Example Corp sends account and support notifications to customers who opted in on the contact form. Reply STOP to opt out, HELP for help.",
        ExampleMessage =
            "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out, HELP for help.",
        OptIns = new Dictionary<string, object?>()
        {
            {
                "web",
                new Dictionary<object, object?>()
                {
                    {
                        "callToAction",
                        "By checking this box you agree to receive account notifications from Example Corp. Reply STOP to opt out, HELP for help."
                    },
                    { "url", "https://example.com/contact" },
                }
            },
        },
        OptInImageUrLs = new List<string>() { "https://example.com/opt-in-screenshot.png" },
        CountryCode = "US",
        Address = new BrandAddress
        {
            Street = "100 Example Street",
            City = "San Francisco",
            State = "CA",
            ZipCode = "94105",
        },
        SupportPhone = "+14155550100",
        SupportEmail = "support@example.com",
        BusinessContactFirstName = "Alex",
        BusinessContactLastName = "Doe",
        LegalName = "Example Corporation Inc.",
        BusinessName = "Example Corp",
        BusinessWebsite = "https://example.com",
        CustomerCareEmail = "support@example.com",
        TaxId = "12-3456789",
        TaxIdIssuingCountry = "US",
        LegalEntityType = "PRIVATE_COMPANY",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TollFreeCampaignRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">CampaignPrioritiesAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;PriorityOption&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the priority options available to your account at the US 10DLC registry, as a JSON array. Pass an option's `id` as `priorityId` when you create or register a toll-free campaign. An empty array means no priority options apply to your account, and you can omit `priorityId`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.CampaignPrioritiesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">GetCampaignAsync</a>(GetCampaignRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one campaign after refreshing its `stage` and review feedback (`rejectionReasons`) from the US 10DLC registry. If the registry is slow to answer, you get the stored record and `lastSyncedAt` tells you how fresh it is. Poll this endpoint (or listen for the `10dlc.campaign.updated` WebSocket event) after registering until `stage` settles at `REGISTERED` or `REJECTED`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.GetCampaignAsync(
    new GetCampaignRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCampaignRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">UpdateCampaignAsync</a>(UpdateCampaignRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replaces the editable fields of a 10DLC campaign and pushes the change to the US 10DLC registry. This is a full replacement: `name` is required and any field you leave out is cleared. `campaignType` and the brand stay as created, and `referenceId` is ignored. The registry accepts updates while the campaign is `DRAFT` or `REJECTED`. Toll-free campaigns return `400` on this endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.UpdateCampaignAsync(
    new UpdateCampaignRequest
    {
        Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
        Name = "Example Corp account alerts",
        ProgramSummary =
            "Example Corp sends account, billing and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
        ConfirmationMessage =
            "Example Corp: You are subscribed to account alerts. Msg frequency varies. Msg & data rates may apply. Reply HELP for help, STOP to opt out.",
        HelpMessage = "Example Corp: For help email support@example.com. Reply STOP to opt out.",
        StopMessage = "Example Corp: You have been unsubscribed. Reply HELP for help.",
        CustomerCarePhone = "+14155550100",
        CustomerCareEmail = "support@example.com",
        TermsAndConditionsUrl = "https://example.com/terms",
        PrivacyPolicyUrl = "https://example.com/privacy",
        ExampleMessages = new List<string>()
        {
            "Example Corp: Your support ticket #48213 was updated. View it at https://example.com/support. Reply STOP to opt out.",
        },
        UseCases = new List<string>() { "ALERTS" },
        MessageTypes = new List<string>() { "SMS" },
        OptIns = new Dictionary<string, object?>()
        {
            {
                "web",
                new Dictionary<object, object?>()
                {
                    {
                        "callToAction",
                        "By checking this box you agree to receive account alerts from Example Corp. Msg frequency varies. Msg & data rates may apply. Reply STOP to opt out, HELP for help."
                    },
                    { "url", "https://example.com/signup" },
                }
            },
        },
        LowVolume = true,
        EmbeddedLink = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateCampaignRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">DeleteCampaignAsync</a>(DeleteCampaignRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes the campaign from your account and from the US 10DLC registry and returns `204` with no body. The registry accepts deletion while the campaign is `DRAFT`, `DEREGISTERED` or `REJECTED`; deregister a registered campaign with `POST /10dlc/campaigns/{id}/deregister` first. Delete all of a brand's campaigns before you delete the brand.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.DeleteCampaignAsync(
    new DeleteCampaignRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteCampaignRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">RegisterCampaignAsync</a>(CampaignRegisterRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Submits the campaign to the US 10DLC registry for review and returns the refreshed campaign. The `stage` moves out of `DRAFT`; poll `GET /10dlc/campaigns/{id}` until it settles at `REGISTERED` or `REJECTED`. The body is optional and carries a `priorityId` from `GET /10dlc/campaigns/priorities` for toll-free campaigns; a value that is not a UUID returns `400`. Submit only when the campaign details are final and you intend to run this program.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.RegisterCampaignAsync(
    new CampaignRegisterRequest
    {
        Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
        PriorityId = "2c9e4b7a-1d3f-4a5b-8c6d-0e9f8a7b6c5d",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CampaignRegisterRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">DeregisterCampaignAsync</a>(DeregisterCampaignRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Withdraws a registered campaign from the US 10DLC registry and returns the campaign. Once deregistration completes, traffic on the campaign's numbers is no longer covered by this registration, so move the numbers to another registered campaign first if you keep sending. The request has no body. A deregistered campaign can then be deleted with `DELETE /10dlc/campaigns/{id}`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.DeregisterCampaignAsync(
    new DeregisterCampaignRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeregisterCampaignRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">AppealCampaignAsync</a>(CampaignAppealRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Asks the US 10DLC registry to reconsider a `REJECTED` campaign and returns the campaign after the appeal is filed. Fix the campaign with `PUT /10dlc/campaigns/{id}` first, then explain what changed in `reason`, which is required (`400` with `invalid request: reason is required` otherwise). Follow the outcome with `GET /10dlc/campaigns/{id}`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.AppealCampaignAsync(
    new CampaignAppealRequest
    {
        Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
        Reason =
            "Updated the program summary and opt-in call to action to match the brand's registered details.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CampaignAppealRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">UpdateCampaignRegistrationAsync</a>(UpdateCampaignRegistrationRequest { ... }) -> WithRawResponseTask&lt;Campaign&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Asks the US 10DLC registry to update the set of numbers covered by a registered campaign, without deregistering it. Provide `numbers`, `numberKeys`, or both; if both are empty the call returns `400` with `invalid request: numbers or numberKeys is required`. The response is the campaign; the `numbers` list stored on your account is left as it was. Use `POST` and `DELETE /10dlc/campaigns/{id}/numbers` for incremental changes.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.UpdateCampaignRegistrationAsync(
    new UpdateCampaignRegistrationRequest
    {
        Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
        Body = new CampaignNumbersRequest
        {
            Numbers = new List<string>() { "14155550100", "14155550101" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateCampaignRegistrationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">CampaignNetworkStatusesAsync</a>(CampaignNetworkStatusesRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;CampaignNetworkStatus&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the campaign's status at each US carrier network, read live from the US 10DLC registry. Each entry names the network and its `state`, plus the message class, throughput and brand tier when the network reports them. Use it after the campaign reaches `REGISTERED` to see which networks have provisioned it and what throughput they grant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.CampaignNetworkStatusesAsync(
    new CampaignNetworkStatusesRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CampaignNetworkStatusesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">ListCampaignNumbersAsync</a>(ListCampaignNumbersRequest { ... }) -> WithRawResponseTask&lt;CampaignNumberList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the numbers attached to the campaign at the US 10DLC registry, as `{"numberPreviews": [...]}`. Each entry gives the number, its country and the registry `numberKey`, which you can pass in `numberKeys` on the number endpoints. Use it to confirm which numbers the registry associates with the campaign.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.ListCampaignNumbersAsync(
    new ListCampaignNumbersRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCampaignNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">AddCampaignNumbersAsync</a>(AddCampaignNumbersRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Attaches numbers to the campaign at the US 10DLC registry and adds the `numbers` values to the campaign's `numbers` list on your account. Provide `numbers`, `numberKeys`, or both; if both are empty the call returns `400`. Returns `200` with `{"status":"ok"}`. Attach only numbers on your account that you send this program from.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.AddCampaignNumbersAsync(
    new AddCampaignNumbersRequest
    {
        Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
        Body = new CampaignNumbersRequest { Numbers = new List<string>() { "14155550101" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AddCampaignNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">RemoveCampaignNumbersAsync</a>(RemoveCampaignNumbersRequest { ... }) -> WithRawResponseTask&lt;StatusOk&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Detaches numbers from the campaign at the US 10DLC registry and removes the `numbers` values from the campaign's `numbers` list on your account. Send `numbers`, `numberKeys`, or both in the `DELETE` request body; if both are empty the call returns `400`. Returns `200` with `{"status":"ok"}`. Messages from a detached number are no longer covered by this campaign.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.RemoveCampaignNumbersAsync(
    new RemoveCampaignNumbersRequest
    {
        Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
        Body = new CampaignNumbersRequest { Numbers = new List<string>() { "14155550101" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RemoveCampaignNumbersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">UploadDocumentAsync</a>(UploadDocumentRequest { ... }) -> WithRawResponseTask&lt;Document&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Uploads a supporting document or MMS sample file for campaign registration and stores it at the US 10DLC registry. Send `multipart/form-data` with the file in a part named `document` that carries a filename; the file can be up to 10 MB (`413` above that). The response is the document record; reference its `documentId` in a campaign's `supportingDocuments` or `mmsSampleFiles`, and use the same value to download it again.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.UploadDocumentAsync(new UploadDocumentRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UploadDocumentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sms.Campaigns.<a href="/src/Vobiz/Sms/Campaigns/CampaignsClient.cs">GetDocumentAsync</a>(GetDocumentRequest { ... }) -> WithRawResponseTask&lt;Stream&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Downloads a document you uploaded with `POST /10dlc/documents`. The response body is the file itself, with the file's own `Content-Type` and a `Content-Disposition: attachment` header that carries the original filename. Look the file up by its `documentId`, not by the record `id`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sms.Campaigns.GetDocumentAsync(new GetDocumentRequest { Id = "id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDocumentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

