using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Messages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CheckRcsReachabilityTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "to": "to",
              "reachable": true,
              "carrier": "carrier",
              "capability": "capability"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages/rcs-reachability")
                    .WithParam("from", "from")
                    .WithParam("to", "to")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.CheckRcsReachabilityAsync(
            new CheckRcsReachabilityRequest { From = "from", To = "to" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "to": "+14155550123",
              "reachable": true,
              "carrier": "Example Mobile",
              "capability": "reachable"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages/rcs-reachability")
                    .WithParam("from", "YOUR_RCS_SENDER_NAME")
                    .WithParam("to", "+14155550123")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.CheckRcsReachabilityAsync(
            new CheckRcsReachabilityRequest { From = "YOUR_RCS_SENDER_NAME", To = "+14155550123" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
