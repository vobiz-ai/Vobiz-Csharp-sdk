using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.LiveCalls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListLiveCallsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "calls": [
                "calls",
                "calls"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call")
                    .WithParam("status", "live")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LiveCalls.ListLiveCallsAsync(
            new ListLiveCallsRequest
            {
                AuthId = "auth_id",
                Status = ListLiveCallsRequestStatus.Live,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "api_id": "c9527676-5839-11e1-86da-6ff39efcb949",
              "calls": [
                "eac94337-b1cd-499b-82d1-b39bca50dc31",
                "0a70a7fb-168e-4944-a846-4f3f4d2f96f1"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call")
                    .WithParam("status", "live")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.LiveCalls.ListLiveCallsAsync(
            new ListLiveCallsRequest
            {
                AuthId = "MA_XXXXXX",
                Status = ListLiveCallsRequestStatus.Live,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
