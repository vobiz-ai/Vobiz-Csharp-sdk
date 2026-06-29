using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateKycSessionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "account_auth_id": "account_auth_id"
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
                    .WithPath("/api/v1/partner/kyc-sessions")
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

        var response = await Client.PartnerApi.CreateKycSessionAsync(
            new CreateKycSessionRequest
            {
                AccountAuthId = "account_auth_id",
                FlowType = null,
                CustomerEmail = null,
                RedirectUrl = null,
                WebhookUrl = null,
                ExpiresInDays = null,
                ReminderSchedule = null,
                Metadata = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "account_auth_id": "MA_ZKITB8Z2"
            }
            """;

        const string mockResponse = """
            {
              "session_id": "a5f8da3c-b47f-40c3-a3e6-d2c9a0f27065",
              "account_auth_id": "MA_E31MAU98",
              "customer_email": "customer@example.com",
              "email_dispatched_to": "c***@example.com",
              "status": "email_sent",
              "expires_at": "2026-05-15T19:37:01.316686Z",
              "message": "KYC email dispatched successfully"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/kyc-sessions")
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

        var response = await Client.PartnerApi.CreateKycSessionAsync(
            new CreateKycSessionRequest { AccountAuthId = "MA_ZKITB8Z2" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "account_auth_id": "MA_ZKITB8Z2"
            }
            """;

        const string mockResponse = """
            {
              "session_id": "1a0f7da5-2abb-47bf-a6c3-eb5cff7feda5",
              "account_auth_id": "MA_E31MAU98",
              "status": "link_ready",
              "expires_at": "2026-05-15T19:37:01.841263Z",
              "widget_url": "https://kyc.vobiz.ai/verify?token=kst_cb1b3fda15c0df5cf58a283e47e9eee148ce0b2b87d7c6693f77296612f58f07",
              "message": "KYC session created - redirect your customer to widget_url to begin."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/kyc-sessions")
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

        var response = await Client.PartnerApi.CreateKycSessionAsync(
            new CreateKycSessionRequest { AccountAuthId = "MA_ZKITB8Z2" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
