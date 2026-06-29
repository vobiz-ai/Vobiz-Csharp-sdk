using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccounts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateSubaccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        const string mockResponse = """
            {
              "message": "message",
              "sub_account": {
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
              },
              "auth_credentials": {
                "auth_id": "auth_id",
                "auth_token": "auth_token"
              },
              "tokens": {
                "access_token": "access_token",
                "refresh_token": "refresh_token",
                "token_type": "token_type",
                "expires_in": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/auth_id/sub-accounts/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccounts.CreateSubaccountAsync(
            new CreateSubaccountRequest
            {
                AuthId = "auth_id",
                Name = "name",
                Email = null,
                Password = null,
                KycMode = null,
                BusinessType = null,
                Enabled = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "Customer Co",
              "email": "customer@example.com",
              "password": "Customer@12345",
              "kyc_mode": "customer_use",
              "business_type": "private_limited"
            }
            """;

        const string mockResponse = """
            {
              "message": "message",
              "sub_account": {
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
              },
              "auth_credentials": {
                "auth_id": "auth_id",
                "auth_token": "auth_token"
              },
              "tokens": {
                "access_token": "access_token",
                "refresh_token": "refresh_token",
                "token_type": "token_type",
                "expires_in": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/MA_XXXXXX/sub-accounts/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccounts.CreateSubaccountAsync(
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
