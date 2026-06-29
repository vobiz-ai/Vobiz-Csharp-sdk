using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccounts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateSubaccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "name": "name",
              "email": {
                "key": "value"
              },
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
              "last_used": {
                "key": "value"
              },
              "account": "account",
              "resource_uri": "resource_uri"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/auth_id/sub-accounts/sub_auth_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccounts.UpdateSubaccountAsync(
            new UpdateSubaccountRequest
            {
                AuthId = "auth_id",
                SubAuthId = "sub_auth_id",
                Name = null,
                Enabled = null,
                KycMode = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "kyc_mode": "customer_use"
            }
            """;

        const string mockResponse = """
            {
              "name": "Acme Sub-Account Updated",
              "rate_limit": 1000,
              "id": "500001",
              "parent_account_id": "510762",
              "parent_auth_id": "MA_XXXXXXXX",
              "auth_id": "SA_XXXXXXXX",
              "auth_token": "<redacted>",
              "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "email_verified": false,
              "enabled": false,
              "created": "2026-03-25",
              "modified": "2026-03-25",
              "is_active": true,
              "created_at": "2026-03-25T10:00:00Z",
              "updated_at": "2026-03-25T10:30:00Z",
              "account": "/v1/Account/MA_XXXXXXXX/",
              "resource_uri": "/v1/Account/MA_XXXXXXXX/Subaccount/SA_XXXXXXXX/"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/MA_XXXXXX/sub-accounts/sub_auth_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccounts.UpdateSubaccountAsync(
            new UpdateSubaccountRequest
            {
                AuthId = "MA_XXXXXX",
                SubAuthId = "sub_auth_id",
                KycMode = UpdateSubaccountRequestKycMode.CustomerUse,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
