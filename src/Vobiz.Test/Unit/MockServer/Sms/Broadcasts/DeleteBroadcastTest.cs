using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteBroadcastTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/id")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Sms.Broadcasts.DeleteBroadcastAsync(
                new DeleteBroadcastRequest { Id = "id" }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Sms.Broadcasts.DeleteBroadcastAsync(
                new DeleteBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
            )
        );
    }
}
