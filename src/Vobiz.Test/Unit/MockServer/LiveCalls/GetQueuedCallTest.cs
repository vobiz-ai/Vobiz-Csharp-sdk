using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.LiveCalls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetQueuedCallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "call_status": "call_status",
              "call_uuid": "call_uuid",
              "request_uuid": "request_uuid",
              "caller_name": "caller_name",
              "direction": "direction",
              "from": "from",
              "to": "to"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/")
                    .WithParam("status", "live")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LiveCalls.GetQueuedCallAsync(
            new GetQueuedCallRequest
            {
                AuthId = "auth_id",
                CallUuid = "call_uuid",
                Status = GetQueuedCallRequestStatus.Live,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "api_id": "45223222-74f8-11e1-8ea7-12313806be9a",
              "call_status": "queued",
              "call_uuid": "6653422-91b6-4716-9fad-9463daaeeec2",
              "request_uuid": "6653422-91b6-4716-9fad-9463daaeeec2",
              "caller_name": "+15856338537",
              "direction": "outbound",
              "from": "15856338537",
              "to": "14154290945"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/cdr_XXXXXXXXXX/")
                    .WithParam("status", "live")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LiveCalls.GetQueuedCallAsync(
            new GetQueuedCallRequest
            {
                AuthId = "MA_XXXXXX",
                CallUuid = "cdr_XXXXXXXXXX",
                Status = GetQueuedCallRequestStatus.Live,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
