using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PlayAudio;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "urls": "urls"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/Play/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PlayAudio.CallAsync(
                new PlayAudioCallRequest
                {
                    AuthId = "auth_id",
                    CallUuid = "call_uuid",
                    Urls = "urls",
                    Legs = null,
                    Loop = null,
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "urls": "https://example.com/audio.mp3",
              "legs": "aleg"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/call_uuid/Play/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PlayAudio.CallAsync(
                new PlayAudioCallRequest
                {
                    AuthId = "MA_XXXXXX",
                    CallUuid = "call_uuid",
                    Urls = "https://example.com/audio.mp3",
                    Legs = PlayAudioCallRequestLegs.Aleg,
                }
            )
        );
    }
}
