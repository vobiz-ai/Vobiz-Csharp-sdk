using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetWebhookTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "accountId": "accountId",
              "url": "url",
              "secret": "secret",
              "events": [
                "message.status",
                "message.status"
              ],
              "active": true,
              "createdAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Webhooks.GetWebhookAsync(
            new GetWebhookRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "8d4f2a6b-3e1c-4b9a-a7d2-5c8e1f0b6a93",
              "accountId": "MA_XXXXXXXX",
              "url": "https://example.com/vobiz/webhooks",
              "secret": "YOUR_WEBHOOK_SECRET",
              "events": [
                "message.received",
                "message.delivered",
                "message.failed"
              ],
              "active": true,
              "createdAt": "2026-10-18T07:22:11.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks/2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Webhooks.GetWebhookAsync(
            new GetWebhookRequest { Id = "2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
