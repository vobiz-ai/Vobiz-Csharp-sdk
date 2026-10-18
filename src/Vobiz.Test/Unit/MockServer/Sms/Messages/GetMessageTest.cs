using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Messages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetMessageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "statusHistory": [
                {
                  "status": "scheduled",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "provider": "provider",
                  "createdAt": "2024-01-15T09:30:00.000Z"
                },
                {
                  "status": "scheduled",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "provider": "provider",
                  "createdAt": "2024-01-15T09:30:00.000Z"
                }
              ],
              "id": "id",
              "accountId": "accountId",
              "direction": "out",
              "channel": "sms",
              "from": "from",
              "to": "to",
              "text": "text",
              "mediaUrls": [
                "mediaUrls",
                "mediaUrls"
              ],
              "status": "scheduled",
              "errorCode": "errorCode",
              "errorMessage": "errorMessage",
              "tag": "tag",
              "conversationId": "conversationId",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2024-01-15T09:30:00.000Z",
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.GetMessageAsync(
            new GetMessageRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
              "accountId": "MA_XXXXXXXX",
              "direction": "out",
              "channel": "sms",
              "from": "+14155550100",
              "to": "+14155550123",
              "text": "Your verification code is 482913",
              "mediaUrls": [
                "mediaUrls"
              ],
              "status": "delivered",
              "errorCode": "errorCode",
              "errorMessage": "errorMessage",
              "tag": "tag",
              "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:31:04.000Z",
              "statusHistory": [
                {
                  "status": "sent",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "provider": "provider",
                  "createdAt": "2026-10-12T10:30:00.000Z"
                },
                {
                  "status": "delivered",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "provider": "provider",
                  "createdAt": "2026-10-12T10:31:04.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages/9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.GetMessageAsync(
            new GetMessageRequest { Id = "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
