using global::System.Globalization;
using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBroadcastTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

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
                    .WithPath("/api/v1/sms/broadcasts")
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

        var response = await Client.Sms.Broadcasts.CreateBroadcastAsync(
            new BroadcastInput
            {
                Name = null,
                From = null,
                Channel = null,
                Template = null,
                ScheduledAt = null,
                RatePerSecond = null,
                Tag = null,
                DltEntityId = null,
                DltHeaderId = null,
                DltTemplateId = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "October pricing update",
              "from": "+14155550100",
              "template": "Hi {{name}}, your refund of {{amount}} is on its way.",
              "ratePerSecond": 5,
              "tag": "pricing-oct"
            }
            """;

        const string mockResponse = """
            {
              "id": "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
              "accountId": "MA_XXXXXXXX",
              "name": "October pricing update",
              "from": "+14155550100",
              "channel": "sms",
              "template": "Hi {{name}}, your refund of {{amount}} is on its way.",
              "status": "draft",
              "pauseReason": "insufficient_balance",
              "ratePerSecond": 5,
              "tag": "pricing-oct",
              "dltEntityId": "",
              "dltHeaderId": "",
              "dltTemplateId": "",
              "stats": {
                "total": 0,
                "pending": 0,
                "sent": 0,
                "delivered": 0,
                "failed": 0,
                "optedOut": 0,
                "skipped": 0
              },
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts")
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

        var response = await Client.Sms.Broadcasts.CreateBroadcastAsync(
            new BroadcastInput
            {
                Name = "October pricing update",
                From = "+14155550100",
                Template = "Hi {{name}}, your refund of {{amount}} is on its way.",
                RatePerSecond = 5,
                Tag = "pricing-oct",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "name": "Weekend reminder",
              "from": "+14155550100",
              "template": "Hi {{name}}, your appointment is tomorrow at {{time}}.",
              "scheduledAt": "2026-10-15T09:00:00.000Z"
            }
            """;

        const string mockResponse = """
            {
              "id": "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
              "accountId": "MA_XXXXXXXX",
              "name": "October pricing update",
              "from": "+14155550100",
              "channel": "sms",
              "template": "Hi {{name}}, your refund of {{amount}} is on its way.",
              "status": "draft",
              "pauseReason": "insufficient_balance",
              "ratePerSecond": 5,
              "tag": "pricing-oct",
              "dltEntityId": "",
              "dltHeaderId": "",
              "dltTemplateId": "",
              "stats": {
                "total": 0,
                "pending": 0,
                "sent": 0,
                "delivered": 0,
                "failed": 0,
                "optedOut": 0,
                "skipped": 0
              },
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts")
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

        var response = await Client.Sms.Broadcasts.CreateBroadcastAsync(
            new BroadcastInput
            {
                Name = "Weekend reminder",
                From = "+14155550100",
                Template = "Hi {{name}}, your appointment is tomorrow at {{time}}.",
                ScheduledAt = DateTime.Parse(
                    "2026-10-15T09:00:00.000Z",
                    null,
                    DateTimeStyles.AdjustToUniversal
                ),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "name": "OTP reminder",
              "from": "+919876543210",
              "template": "Your OTP is {{otp}}.",
              "dltEntityId": "1001234567890123456",
              "dltHeaderId": "1001234567",
              "dltTemplateId": "10012345678901234567"
            }
            """;

        const string mockResponse = """
            {
              "id": "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
              "accountId": "MA_XXXXXXXX",
              "name": "October pricing update",
              "from": "+14155550100",
              "channel": "sms",
              "template": "Hi {{name}}, your refund of {{amount}} is on its way.",
              "status": "draft",
              "pauseReason": "insufficient_balance",
              "ratePerSecond": 5,
              "tag": "pricing-oct",
              "dltEntityId": "",
              "dltHeaderId": "",
              "dltTemplateId": "",
              "stats": {
                "total": 0,
                "pending": 0,
                "sent": 0,
                "delivered": 0,
                "failed": 0,
                "optedOut": 0,
                "skipped": 0
              },
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts")
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

        var response = await Client.Sms.Broadcasts.CreateBroadcastAsync(
            new BroadcastInput
            {
                Name = "OTP reminder",
                From = "+919876543210",
                Template = "Your OTP is {{otp}}.",
                DltEntityId = "1001234567890123456",
                DltHeaderId = "1001234567",
                DltTemplateId = "10012345678901234567",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
