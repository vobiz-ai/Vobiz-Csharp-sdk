using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.RcsSenders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTemplateStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "senderId": "senderId",
              "accountId": "accountId",
              "provider": "provider",
              "templateName": "templateName",
              "type": "type",
              "status": "pending",
              "content": {
                "content": {
                  "key": "value"
                }
              },
              "createdAt": "2024-01-15T09:30:00.000Z",
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/senders/senderId/templates/templateName/status")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.RcsSenders.GetTemplateStatusAsync(
            new GetTemplateStatusRequest { SenderId = "senderId", TemplateName = "templateName" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "c2e4a6b8-1d3f-4a5c-9e7b-6f8d0a2c4e61",
              "senderId": "7a1c3e5f-9b2d-4c6e-8f0a-1b3d5e7f9a21",
              "accountId": "MA_XXXXXXXX",
              "provider": "YOUR_ROUTING_IDENTIFIER",
              "templateName": "order-shipped",
              "type": "TEXT",
              "status": "pending",
              "content": {
                "text": "Your order {{orderId}} has shipped and arrives on {{eta}}."
              },
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T12:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/senders/5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b/templates/appointment_reminder/status"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.RcsSenders.GetTemplateStatusAsync(
            new GetTemplateStatusRequest
            {
                SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
                TemplateName = "appointment_reminder",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
