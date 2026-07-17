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

Retrieve paginated transaction history for the account.
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
await client.Balance.ListTransactionsAsync(new ListTransactionsRequest { AuthId = "MA_XXXXXX" });
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

<details><summary><code>client.PhoneNumbers.<a href="/src/Vobiz/PhoneNumbers/PhoneNumbersClient.cs">UnrentNumberAsync</a>(UnrentNumberRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Release a phone number from your account.
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
    new UnrentNumberRequest { AuthId = "MA_XXXXXX", E164 = "919876543210" }
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

Creates a new customer sub-account under your partner account. VoBiz
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

Triggers VoBiz to email a KYC link to the customer. KYC is OTP-based
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

