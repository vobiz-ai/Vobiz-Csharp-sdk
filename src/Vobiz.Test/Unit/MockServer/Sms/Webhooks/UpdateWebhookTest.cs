using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Webhooks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateWebhookTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "status": "status"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks/id")
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

        var response = await Client.Sms.Webhooks.UpdateWebhookAsync(
            new UpdateWebhookRequest
            {
                Id = "id",
                Url = null,
                Secret = null,
                Events = null,
                Active = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "events": [
                "message.delivered",
                "message.failed"
              ]
            }
            """;

        const string mockResponse = """
            {
              "status": "ok"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks/2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e")
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

        var response = await Client.Sms.Webhooks.UpdateWebhookAsync(
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
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "active": false
            }
            """;

        const string mockResponse = """
            {
              "status": "ok"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks/2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e")
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

        var response = await Client.Sms.Webhooks.UpdateWebhookAsync(
            new UpdateWebhookRequest { Id = "2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e", Active = false }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "url": "https://example.com/vobiz/webhooks-v2",
              "secret": "YOUR_NEW_WEBHOOK_SECRET"
            }
            """;

        const string mockResponse = """
            {
              "status": "ok"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/webhooks/2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e")
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

        var response = await Client.Sms.Webhooks.UpdateWebhookAsync(
            new UpdateWebhookRequest
            {
                Id = "2a4c6e8f-1b3d-4f5a-8c7e-9d0b2f4a6c8e",
                Url = "https://example.com/vobiz/webhooks-v2",
                Secret = "YOUR_NEW_WEBHOOK_SECRET",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
