using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ExportBroadcastTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = "string";

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/id/export")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.ExportBroadcastAsync(
            new ExportBroadcastRequest { Id = "id" }
        );
        Assert.That(response, Is.EqualTo(mockResponse));
    }
}
