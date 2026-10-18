using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListRecipientsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "recipients": [
                {
                  "id": 1000000,
                  "row": 1,
                  "to": "to",
                  "variables": {
                    "variables": "variables"
                  },
                  "status": "pending",
                  "messageId": "messageId",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "sentAt": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": 1000000,
                  "row": 1,
                  "to": "to",
                  "variables": {
                    "variables": "variables"
                  },
                  "status": "pending",
                  "messageId": "messageId",
                  "errorCode": "errorCode",
                  "errorMessage": "errorMessage",
                  "sentAt": "2024-01-15T09:30:00.000Z"
                }
              ],
              "total": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/id/recipients")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.ListRecipientsAsync(
            new ListRecipientsRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "recipients": [
                {
                  "id": 1042,
                  "row": 2,
                  "to": "+14155550123",
                  "variables": {
                    "name": "Priya",
                    "amount": "$42.00"
                  },
                  "status": "sent",
                  "messageId": "9b2e1c40-8a3d-4f5e-9c1a-7d6b2e8f4a01",
                  "errorCode": "",
                  "errorMessage": "",
                  "sentAt": "2026-10-12T11:05:10.000Z"
                },
                {
                  "id": 1043,
                  "row": 3,
                  "to": "+14155550124",
                  "variables": {
                    "name": "Sam",
                    "amount": "$18.50"
                  },
                  "status": "pending",
                  "messageId": "",
                  "errorCode": "",
                  "errorMessage": ""
                }
              ],
              "total": 2
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/broadcasts/3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35/recipients"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.ListRecipientsAsync(
            new ListRecipientsRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
