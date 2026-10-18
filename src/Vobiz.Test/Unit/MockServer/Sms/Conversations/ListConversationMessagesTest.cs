using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Conversations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListConversationMessagesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
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
              },
              {
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
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/conversations/id/messages")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Conversations.ListConversationMessagesAsync(
            new ListConversationMessagesRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "id": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
                "accountId": "MA_XXXXXXXX",
                "direction": "out",
                "channel": "sms",
                "from": "+14155550100",
                "to": "+14155550123",
                "text": "Your appointment is confirmed for 3pm tomorrow.",
                "status": "delivered",
                "errorCode": "errorCode",
                "errorMessage": "errorMessage",
                "tag": "tag",
                "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
                "scheduledAt": "2024-01-15T09:30:00.000Z",
                "createdAt": "2026-10-16T21:23:02.000Z",
                "updatedAt": "2026-10-16T21:23:09.000Z"
              },
              {
                "id": "2e7f4b91-6c3d-4a8e-b5f1-9d0c7a2e3b64",
                "accountId": "MA_XXXXXXXX",
                "direction": "in",
                "channel": "sms",
                "from": "+14155550123",
                "to": "+14155550100",
                "text": "Thanks, see you then.",
                "status": "received",
                "errorCode": "errorCode",
                "errorMessage": "errorMessage",
                "tag": "tag",
                "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
                "scheduledAt": "2024-01-15T09:30:00.000Z",
                "createdAt": "2026-10-16T21:23:51.000Z",
                "updatedAt": "2026-10-16T21:23:51.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/conversations/c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04/messages"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Conversations.ListConversationMessagesAsync(
            new ListConversationMessagesRequest { Id = "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
