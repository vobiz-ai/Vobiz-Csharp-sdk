using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.AudioStreams;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StopStreamTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/Stream/stream_id/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.AudioStreams.StopStreamAsync(
                new StopStreamRequest
                {
                    AuthId = "auth_id",
                    CallUuid = "call_uuid",
                    StreamId = "stream_id",
                }
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/call_uuid/Stream/stream_id/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.AudioStreams.StopStreamAsync(
                new StopStreamRequest
                {
                    AuthId = "MA_XXXXXX",
                    CallUuid = "call_uuid",
                    StreamId = "stream_id",
                }
            )
        );
    }
}
