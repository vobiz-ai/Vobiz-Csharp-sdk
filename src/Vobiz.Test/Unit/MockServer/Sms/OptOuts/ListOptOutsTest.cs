using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.OptOuts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOptOutsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "id": "id",
                "accountId": "accountId",
                "phoneNumber": "phoneNumber",
                "channel": "channel",
                "reason": "reason",
                "source": "inbound",
                "syncedToProvider": true,
                "createdAt": "2024-01-15T09:30:00.000Z"
              },
              {
                "id": "id",
                "accountId": "accountId",
                "phoneNumber": "phoneNumber",
                "channel": "channel",
                "reason": "reason",
                "source": "inbound",
                "syncedToProvider": true,
                "createdAt": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/opt-outs")
                    .WithParam("limit", "1")
                    .WithParam("offset", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.OptOuts.ListOptOutsAsync(
            new ListOptOutsRequest { Limit = 1, Offset = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "id": "4e8b2d61-7c3a-4f9e-a1d5-9b6c0e2f8a37",
                "accountId": "MA_XXXXXXXX",
                "phoneNumber": "+14155550123",
                "channel": "sms",
                "reason": "manual",
                "source": "manual",
                "syncedToProvider": true,
                "createdAt": "2026-10-18T07:23:03.000Z"
              },
              {
                "id": "7b1d9f3e-2a6c-4e5b-8d0f-3c9a1e7b5d26",
                "accountId": "MA_XXXXXXXX",
                "phoneNumber": "+14155550124",
                "channel": "sms",
                "reason": "stop",
                "source": "inbound",
                "syncedToProvider": false,
                "createdAt": "2026-10-17T19:04:40.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/opt-outs")
                    .WithParam("limit", "1")
                    .WithParam("offset", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.OptOuts.ListOptOutsAsync(
            new ListOptOutsRequest { Limit = 1, Offset = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
