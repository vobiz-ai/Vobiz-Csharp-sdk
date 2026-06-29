using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccounts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListSubaccountsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "sub_accounts": [
                {
                  "name": "name",
                  "email": "email",
                  "phone": {
                    "key": "value"
                  },
                  "description": {
                    "key": "value"
                  },
                  "permissions": {
                    "key": "value"
                  },
                  "rate_limit": 1,
                  "id": "id",
                  "parent_account_id": "parent_account_id",
                  "parent_auth_id": "parent_auth_id",
                  "auth_id": "auth_id",
                  "auth_token": "auth_token",
                  "api_id": "api_id",
                  "email_verified": true,
                  "enabled": true,
                  "created": "created",
                  "modified": "modified",
                  "is_active": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "last_used": "last_used",
                  "account": "account",
                  "resource_uri": "resource_uri"
                },
                {
                  "name": "name",
                  "email": "email",
                  "phone": {
                    "key": "value"
                  },
                  "description": {
                    "key": "value"
                  },
                  "permissions": {
                    "key": "value"
                  },
                  "rate_limit": 1,
                  "id": "id",
                  "parent_account_id": "parent_account_id",
                  "parent_auth_id": "parent_auth_id",
                  "auth_id": "auth_id",
                  "auth_token": "auth_token",
                  "api_id": "api_id",
                  "email_verified": true,
                  "enabled": true,
                  "created": "created",
                  "modified": "modified",
                  "is_active": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "last_used": "last_used",
                  "account": "account",
                  "resource_uri": "resource_uri"
                }
              ],
              "total": 1,
              "page": 1,
              "size": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/auth_id/sub-accounts/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccounts.ListSubaccountsAsync(
            new ListSubaccountsRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "sub_accounts": [
                {
                  "name": "Acme Corp",
                  "rate_limit": 1000,
                  "id": "500001",
                  "parent_account_id": "500000",
                  "parent_auth_id": "MA_XXXXXXXX",
                  "auth_id": "SA_XXXXXXXX",
                  "auth_token": "<redacted>",
                  "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "email_verified": false,
                  "enabled": true,
                  "created": "2026-03-25",
                  "modified": "2026-03-25",
                  "is_active": true,
                  "created_at": "2026-03-25T08:33:24.700542Z",
                  "updated_at": "2026-03-25T08:33:24.700542Z",
                  "account": "/v1/Account/MA_XXXXXXXX/",
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/Subaccount/SA_XXXXXXXX/"
                },
                {
                  "name": "John Doe",
                  "email": "john@example.com",
                  "permissions": {
                    "cdr": true,
                    "calls": true
                  },
                  "rate_limit": 5000,
                  "id": "500002",
                  "parent_account_id": "500000",
                  "parent_auth_id": "MA_XXXXXXXX",
                  "auth_id": "SA_YYYYYYYY",
                  "auth_token": "<redacted>",
                  "api_id": "11223344-5566-7788-99aa-bbccddeeff00",
                  "email_verified": false,
                  "enabled": true,
                  "created": "2026-03-25",
                  "modified": "2026-03-25",
                  "is_active": true,
                  "created_at": "2026-03-25T11:56:03.796409Z",
                  "updated_at": "2026-03-25T11:56:03.796409Z",
                  "account": "/v1/Account/MA_XXXXXXXX/",
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/Subaccount/SA_YYYYYYYY/"
                }
              ],
              "total": 28,
              "page": 1,
              "size": 10
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/MA_XXXXXX/sub-accounts/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccounts.ListSubaccountsAsync(
            new ListSubaccountsRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
