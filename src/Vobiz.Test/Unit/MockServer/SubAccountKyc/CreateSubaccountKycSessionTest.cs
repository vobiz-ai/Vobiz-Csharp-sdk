using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKyc;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateSubaccountKycSessionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "account_auth_id": "account_auth_id",
              "flow_type": "email"
            }
            """;

        const string mockResponse = """
            {
              "key": "value"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/sub_auth_id/kyc-sessions")
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

        var response = await Client.SubAccountKyc.CreateSubaccountKycSessionAsync(
            new CreateSubaccountKycSessionRequest
            {
                SubAuthId = "sub_auth_id",
                AccountAuthId = "account_auth_id",
                FlowType = CreateSubaccountKycSessionRequestFlowType.Email,
                CustomerEmail = null,
                RedirectUrl = null,
                WebhookUrl = null,
                ExpiresInDays = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "account_auth_id": "SA_XXXXXX",
              "flow_type": "email",
              "customer_email": "customer@example.com",
              "webhook_url": "https://your-app.example.com/kyc/webhook",
              "expires_in_days": 30
            }
            """;

        const string mockResponse = """
            {
              "session_id": "a5f8da3c-b47f-40c3-a3e6-d2c9a0f27065",
              "account_auth_id": "SA_XXXXXX",
              "customer_email": "customer@example.com",
              "status": "email_sent",
              "expires_at": "2026-06-24T19:37:01.316686Z",
              "message": "KYC email dispatched successfully"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc-sessions")
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

        var response = await Client.SubAccountKyc.CreateSubaccountKycSessionAsync(
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
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "account_auth_id": "SA_XXXXXX",
              "flow_type": "redirect",
              "redirect_url": "https://your-app.example.com/kyc/done",
              "webhook_url": "https://your-app.example.com/kyc/webhook",
              "expires_in_days": 30
            }
            """;

        const string mockResponse = """
            {
              "session_id": "a5f8da3c-b47f-40c3-a3e6-d2c9a0f27065",
              "account_auth_id": "SA_XXXXXX",
              "customer_email": "customer@example.com",
              "status": "email_sent",
              "expires_at": "2026-06-24T19:37:01.316686Z",
              "message": "KYC email dispatched successfully"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc-sessions")
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

        var response = await Client.SubAccountKyc.CreateSubaccountKycSessionAsync(
            new CreateSubaccountKycSessionRequest
            {
                SubAuthId = "SA_XXXXXX",
                AccountAuthId = "SA_XXXXXX",
                FlowType = CreateSubaccountKycSessionRequestFlowType.Redirect,
                RedirectUrl = "https://your-app.example.com/kyc/done",
                WebhookUrl = "https://your-app.example.com/kyc/webhook",
                ExpiresInDays = 30,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "account_auth_id": "SA_XXXXXX",
              "flow_type": "email",
              "customer_email": "customer@example.com",
              "webhook_url": "https://your-app.example.com/kyc/webhook",
              "expires_in_days": 30
            }
            """;

        const string mockResponse = """
            {
              "session_id": "a5f8da3c-b47f-40c3-a3e6-d2c9a0f27065",
              "account_auth_id": "SA_XXXXXX",
              "customer_email": "customer@example.com",
              "status": "email_sent",
              "expires_at": "2026-06-24T19:37:01.316686Z",
              "message": "KYC email dispatched successfully"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc-sessions")
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

        var response = await Client.SubAccountKyc.CreateSubaccountKycSessionAsync(
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
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "account_auth_id": "SA_XXXXXX",
              "flow_type": "email",
              "customer_email": "customer@example.com",
              "webhook_url": "https://your-app.example.com/kyc/webhook",
              "expires_in_days": 30
            }
            """;

        const string mockResponse = """
            {
              "session_id": "1a0f7da5-2abb-47bf-a6c3-eb5cff7feda5",
              "account_auth_id": "SA_XXXXXX",
              "status": "link_ready",
              "expires_at": "2026-06-24T19:37:01.841263Z",
              "widget_url": "https://kyc.vobiz.ai/verify?token=kst_cb1b3fda...",
              "message": "Redirect your customer to widget_url to begin."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc-sessions")
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

        var response = await Client.SubAccountKyc.CreateSubaccountKycSessionAsync(
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
