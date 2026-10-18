using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Messages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListMessagesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "messages": [
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
              ],
              "total": 1,
              "limit": 1,
              "offset": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.ListMessagesAsync(new ListMessagesRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "messages": [
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
                  "status": "scheduled",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "tag": "tag",
                  "conversationId": "conversationId",
                  "scheduledAt": "2024-01-15T09:30:00.000Z",
                  "createdAt": "2026-10-12T10:30:00.000Z",
                  "updatedAt": "2026-10-12T10:30:00.000Z"
                }
              ],
              "total": 128,
              "limit": 20,
              "offset": 0
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.ListMessagesAsync(new ListMessagesRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
