using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListWebhooksTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
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
              },
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
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Webhooks.ListWebhooksAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
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
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Webhooks.ListWebhooksAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
