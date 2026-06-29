using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.AudioStreams;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StartStreamTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "service_url": "service_url"
            }
            """;

        const string mockResponse = """
            {
              "key": "value"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/Stream/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AudioStreams.StartStreamAsync(
            new StartStreamRequest
            {
                AuthId = "auth_id",
                CallUuid = "call_uuid",
                ServiceUrl = "service_url",
                Bidirectional = null,
                AudioTrack = null,
                AudioFormat = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "service_url": "wss://your-server.com/ws",
              "bidirectional": true,
              "audio_track": "both"
            }
            """;

        const string mockResponse = """
            {
              "stream_id": "str_XXXXXXXXXX",
              "message": "Stream started"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/call_uuid/Stream/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AudioStreams.StartStreamAsync(
            new StartStreamRequest
            {
                AuthId = "MA_XXXXXX",
                CallUuid = "call_uuid",
                ServiceUrl = "wss://your-server.com/ws",
                Bidirectional = true,
                AudioTrack = StartStreamRequestAudioTrack.Both,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
