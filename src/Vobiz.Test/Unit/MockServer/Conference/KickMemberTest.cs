using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Conference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class KickMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
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
                        "/api/v1/Account/auth_id/Conference/conference_name/Member/member_id/Kick/"
                    )
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conference.KickMemberAsync(
            new KickMemberRequest
            {
                AuthId = "auth_id",
                ConferenceName = "conference_name",
                MemberId = "member_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "message": "Member kicked from conference"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/Account/MA_XXXXXX/Conference/conference_name/Member/member_id/Kick/"
                    )
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conference.KickMemberAsync(
            new KickMemberRequest
            {
                AuthId = "MA_XXXXXX",
                ConferenceName = "conference_name",
                MemberId = "member_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
