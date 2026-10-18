using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Conversations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetConversationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "accountId": "accountId",
              "participantA": "participantA",
              "participantB": "participantB",
              "channel": "sms",
              "lastMessageAt": "2024-01-15T09:30:00.000Z",
              "messageCount": 1,
              "unreadCount": 1,
              "lastReadAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/conversations/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Conversations.GetConversationAsync(
            new GetConversationRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
              "accountId": "MA_XXXXXXXX",
              "participantA": "+14155550100",
              "participantB": "+14155550123",
              "channel": "sms",
              "lastMessageAt": "2026-10-16T21:23:51.000Z",
              "messageCount": 3,
              "unreadCount": 1,
              "lastReadAt": "2026-10-17T08:46:55.000Z",
              "createdAt": "2026-10-16T21:23:02.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/conversations/c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Conversations.GetConversationAsync(
            new GetConversationRequest { Id = "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
