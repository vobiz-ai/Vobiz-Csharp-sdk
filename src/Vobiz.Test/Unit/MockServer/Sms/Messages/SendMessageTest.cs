using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Messages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SendMessageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "from": "from",
              "to": [
                "to",
                "to"
              ]
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
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

        var response = await Client.Sms.Messages.SendMessageAsync(
            new SendMessageRequest
            {
                From = "from",
                To = new List<string>() { "to", "to" },
                Channel = null,
                Text = null,
                MediaUrls = null,
                Title = null,
                Tag = null,
                IdempotencyKey = null,
                ScheduledAt = null,
                FailoverToSms = null,
                RcsSuggestions = null,
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
              "from": "+14155550100",
              "to": [
                "+14155550123"
              ],
              "channel": "sms",
              "text": "Your verification code is 482913",
              "idempotencyKey": "otp-482913-user-77"
            }
            """;

        const string mockResponse = """
            {
              "id": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
              "accountId": "MA_XXXXXXXX",
              "direction": "out",
              "channel": "sms",
              "from": "+14155550100",
              "to": "+14155550123",
              "text": "Your verification code is 482913",
              "status": "sent",
              "errorCode": "errorCode",
              "errorMessage": "errorMessage",
              "tag": "otp",
              "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
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

        var response = await Client.Sms.Messages.SendMessageAsync(
            new SendMessageRequest
            {
                From = "+14155550100",
                To = new List<string>() { "+14155550123" },
                Channel = SendMessageRequestChannel.Sms,
                Text = "Your verification code is 482913",
                IdempotencyKey = "otp-482913-user-77",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "from": "+14155550100",
              "to": [
                "+14155550123"
              ],
              "channel": "mms",
              "text": "Here is your invoice.",
              "mediaUrls": [
                "https://example.com/invoice.pdf"
              ],
              "title": "Your invoice"
            }
            """;

        const string mockResponse = """
            {
              "id": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
              "accountId": "MA_XXXXXXXX",
              "direction": "out",
              "channel": "sms",
              "from": "+14155550100",
              "to": "+14155550123",
              "text": "Your verification code is 482913",
              "status": "sent",
              "errorCode": "errorCode",
              "errorMessage": "errorMessage",
              "tag": "otp",
              "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
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

        var response = await Client.Sms.Messages.SendMessageAsync(
            new SendMessageRequest
            {
                From = "+14155550100",
                To = new List<string>() { "+14155550123" },
                Channel = SendMessageRequestChannel.Mms,
                Text = "Here is your invoice.",
                MediaUrls = new List<string>() { "https://example.com/invoice.pdf" },
                Title = "Your invoice",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "from": "YOUR_RCS_SENDER_NAME",
              "to": [
                "+14155550123"
              ],
              "channel": "rcs",
              "text": "Your appointment is confirmed for 3pm tomorrow.",
              "idempotencyKey": "appt-8812-confirm",
              "failoverToSms": true,
              "rcsSuggestions": [
                {
                  "type": "REPLY",
                  "text": "Reschedule",
                  "postbackData": "reschedule"
                },
                {
                  "type": "DIAL_PHONE",
                  "text": "Call us",
                  "postbackData": "call",
                  "phoneNumber": "+14155550100"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "id": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
              "accountId": "MA_XXXXXXXX",
              "direction": "out",
              "channel": "sms",
              "from": "+14155550100",
              "to": "+14155550123",
              "text": "Your verification code is 482913",
              "status": "sent",
              "errorCode": "errorCode",
              "errorMessage": "errorMessage",
              "tag": "otp",
              "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
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

        var response = await Client.Sms.Messages.SendMessageAsync(
            new SendMessageRequest
            {
                From = "YOUR_RCS_SENDER_NAME",
                To = new List<string>() { "+14155550123" },
                Channel = SendMessageRequestChannel.Rcs,
                Text = "Your appointment is confirmed for 3pm tomorrow.",
                IdempotencyKey = "appt-8812-confirm",
                FailoverToSms = true,
                RcsSuggestions = new List<RcsSuggestion>()
                {
                    new RcsSuggestion
                    {
                        Type = RcsSuggestionType.Reply,
                        Text = "Reschedule",
                        PostbackData = "reschedule",
                    },
                    new RcsSuggestion
                    {
                        Type = RcsSuggestionType.DialPhone,
                        Text = "Call us",
                        PostbackData = "call",
                        PhoneNumber = "+14155550100",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "from": "+919876543210",
              "to": [
                "+919876500001"
              ],
              "channel": "sms",
              "text": "Your OTP is 4821.",
              "dltEntityId": "1001234567890123456",
              "dltHeaderId": "1001234567",
              "dltTemplateId": "10012345678901234567"
            }
            """;

        const string mockResponse = """
            {
              "id": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
              "accountId": "MA_XXXXXXXX",
              "direction": "out",
              "channel": "sms",
              "from": "+14155550100",
              "to": "+14155550123",
              "text": "Your verification code is 482913",
              "status": "sent",
              "errorCode": "errorCode",
              "errorMessage": "errorMessage",
              "tag": "otp",
              "conversationId": "c7d1e9a3-2b4f-4a6c-8d5e-1f3a9b7c2e04",
              "scheduledAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages")
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

        var response = await Client.Sms.Messages.SendMessageAsync(
            new SendMessageRequest
            {
                From = "+919876543210",
                To = new List<string>() { "+919876500001" },
                Channel = SendMessageRequestChannel.Sms,
                Text = "Your OTP is 4821.",
                DltEntityId = "1001234567890123456",
                DltHeaderId = "1001234567",
                DltTemplateId = "10012345678901234567",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
