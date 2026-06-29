using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.ConferenceMembers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MuteMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/Account/auth_id/Conference/conference_name/Member/member_id/Mute/"
                    )
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.ConferenceMembers.MuteMemberAsync(
                new MuteMemberRequest
                {
                    AuthId = "auth_id",
                    ConferenceName = "conference_name",
                    MemberId = "member_id",
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
                    .WithPath(
                        "/api/v1/Account/MA_XXXXXX/Conference/conference_name/Member/member_id/Mute/"
                    )
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.ConferenceMembers.MuteMemberAsync(
                new MuteMemberRequest
                {
                    AuthId = "MA_XXXXXX",
                    ConferenceName = "conference_name",
                    MemberId = "member_id",
                }
            )
        );
    }
}
