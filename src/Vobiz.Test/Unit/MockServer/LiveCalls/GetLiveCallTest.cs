using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.LiveCalls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetLiveCallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "call_status": "call_status",
              "call_uuid": "call_uuid",
              "caller_name": "caller_name",
              "direction": "direction",
              "from": "from",
              "request_uuid": "request_uuid",
              "session_start": "session_start",
              "stir_attestation": "stir_attestation",
              "stir_verification": "stir_verification",
              "to": "to"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid")
                    .WithParam("status", "live")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LiveCalls.GetLiveCallAsync(
            new GetLiveCallRequest
            {
                AuthId = "auth_id",
                CallUuid = "call_uuid",
                Status = GetLiveCallRequestStatus.Live,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "api_id": "c9cab827-d7e6-4ab8-b521-f29e593a1c26",
              "call_status": "in-progress",
              "call_uuid": "2ded13fe-4f9b-4958-9bfb-093ea2f29f91",
              "caller_name": "",
              "direction": "outbound",
              "from": "919262171438",
              "request_uuid": "2ded13fe-4f9b-4958-9bfb-093ea2f29f91",
              "session_start": "2026-06-11 16:03:28.586839",
              "stir_attestation": "Not Applicable",
              "stir_verification": "Not Applicable",
              "to": "919148227303"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/cdr_XXXXXXXXXX")
                    .WithParam("status", "live")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LiveCalls.GetLiveCallAsync(
            new GetLiveCallRequest
            {
                AuthId = "MA_XXXXXX",
                CallUuid = "cdr_XXXXXXXXXX",
                Status = GetLiveCallRequestStatus.Live,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
