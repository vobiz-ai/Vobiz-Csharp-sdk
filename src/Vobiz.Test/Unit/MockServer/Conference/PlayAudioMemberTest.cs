using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Conference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PlayAudioMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "url": "url"
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
                    .WithPath(
                        "/api/v1/Account/auth_id/Conference/conference_name/Member/member_id/Play/"
                    )
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

        var response = await Client.Conference.PlayAudioMemberAsync(
            new PlayAudioMemberRequest
            {
                AuthId = "auth_id",
                ConferenceName = "conference_name",
                MemberId = "member_id",
                Url = "url",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "url": "https://example.com/audio.mp3"
            }
            """;

        const string mockResponse = """
            {
              "message": "play queued into conference",
              "member_id": [
                "2"
              ],
              "api_id": "API_REQUEST_ID"
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
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conference.PlayAudioMemberAsync(
            new PlayAudioMemberRequest
            {
                AuthId = "MA_XXXXXX",
                ConferenceName = "conference_name",
                MemberId = "member_id",
                Url = "https://example.com/audio.mp3",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
