using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Conference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlayAudioMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "url": "url"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/Account/auth_id/Conference/conference_name/Member/member_id/Play/"
                    )
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conference.PlayAudioMemberAsync(
                new PlayAudioMemberRequest
                {
                    AuthId = "auth_id",
                    ConferenceName = "conference_name",
                    MemberId = "member_id",
                    Url = "url",
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "url": "https://example.com/audio.mp3"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/Account/MA_XXXXXX/Conference/conference_name/Member/member_id/Play/"
                    )
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conference.PlayAudioMemberAsync(
                new PlayAudioMemberRequest
                {
                    AuthId = "MA_XXXXXX",
                    ConferenceName = "conference_name",
                    MemberId = "member_id",
                    Url = "https://example.com/audio.mp3",
                }
            )
        );
    }
}
