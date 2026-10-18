using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LaunchBroadcastTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "accountId": "accountId",
              "name": "name",
              "from": "from",
              "channel": "sms",
              "template": "template",
              "status": "draft",
              "pauseReason": "insufficient_balance",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "ratePerSecond": 1,
              "tag": "tag",
              "dltEntityId": "dltEntityId",
              "dltHeaderId": "dltHeaderId",
              "dltTemplateId": "dltTemplateId",
              "columns": [
                "columns",
                "columns"
              ],
              "stats": {
                "total": 1,
                "pending": 1,
                "sent": 1,
                "delivered": 1,
                "failed": 1,
                "optedOut": 1,
                "skipped": 1
              },
              "createdAt": "2024-01-15T09:30:00.000Z",
              "updatedAt": "2024-01-15T09:30:00.000Z",
              "startedAt": "2024-01-15T09:30:00.000Z",
              "completedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/id/launch")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.LaunchBroadcastAsync(
            new LaunchBroadcastRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
              "accountId": "MA_XXXXXXXX",
              "name": "October pricing update",
              "from": "+14155550100",
              "channel": "sms",
              "template": "Hi {{name}}, your refund of {{amount}} is on its way.",
              "status": "running",
              "pauseReason": "insufficient_balance",
              "ratePerSecond": 5,
              "tag": "pricing-oct",
              "dltEntityId": "",
              "dltHeaderId": "",
              "dltTemplateId": "",
              "columns": [
                "phone",
                "name",
                "amount"
              ],
              "stats": {
                "total": 3,
                "pending": 3,
                "sent": 0,
                "delivered": 0,
                "failed": 0,
                "optedOut": 0,
                "skipped": 0
              },
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T11:05:10.000Z",
              "startedAt": "2026-10-12T11:05:10.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35/launch")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.LaunchBroadcastAsync(
            new LaunchBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
