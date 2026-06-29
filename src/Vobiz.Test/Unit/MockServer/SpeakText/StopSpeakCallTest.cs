using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.SpeakText;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StopSpeakCallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/Speak/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.SpeakText.StopSpeakCallAsync(
                new StopSpeakCallRequest { AuthId = "auth_id", CallUuid = "call_uuid" }
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/call_uuid/Speak/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.SpeakText.StopSpeakCallAsync(
                new StopSpeakCallRequest { AuthId = "MA_XXXXXX", CallUuid = "call_uuid" }
            )
        );
    }
}
