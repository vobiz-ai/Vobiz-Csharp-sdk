using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.ConferenceRecording;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StopConferenceRecordingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Conference/conference_name/Record/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.ConferenceRecording.StopConferenceRecordingAsync(
                new StopConferenceRecordingRequest
                {
                    AuthId = "auth_id",
                    ConferenceName = "conference_name",
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/Conference/conference_name/Record/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.ConferenceRecording.StopConferenceRecordingAsync(
                new StopConferenceRecordingRequest
                {
                    AuthId = "MA_XXXXXX",
                    ConferenceName = "conference_name",
                }
            )
        );
    }
}
