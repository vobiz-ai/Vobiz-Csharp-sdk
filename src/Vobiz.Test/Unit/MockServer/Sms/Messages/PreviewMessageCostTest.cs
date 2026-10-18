using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Messages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PreviewMessageCostTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "channel": "channel",
              "segmentCount": 1,
              "unitCost": 1.1,
              "totalCost": 1.1,
              "currency": "currency",
              "country": "country"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages/cost-preview")
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

        var response = await Client.Sms.Messages.PreviewMessageCostAsync(
            new PreviewMessageCostRequest { From = "from", To = "to" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "channel": "sms",
              "segmentCount": 2,
              "unitCost": 0.01,
              "totalCost": 0.02,
              "currency": "USD",
              "country": "US"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/messages/cost-preview")
                    .WithParam("from", "+14155550100")
                    .WithParam("to", "+14155550123")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Messages.PreviewMessageCostAsync(
            new PreviewMessageCostRequest { From = "+14155550100", To = "+14155550123" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
