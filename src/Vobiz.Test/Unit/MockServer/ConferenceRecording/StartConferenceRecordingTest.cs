using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.ConferenceRecording;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StartConferenceRecordingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Conference/conference_name/Record/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.ConferenceRecording.StartConferenceRecordingAsync(
                new StartConferenceRecordingRequest
                {
                    AuthId = "auth_id",
                    ConferenceName = "conference_name",
                    FileFormat = null,
                    CallbackUrl = null,
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Conference/conference_name/Record/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.ConferenceRecording.StartConferenceRecordingAsync(
                new StartConferenceRecordingRequest
                {
                    AuthId = "MA_XXXXXX",
                    ConferenceName = "conference_name",
                }
            )
        );
    }
}
