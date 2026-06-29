using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Conference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeafMemberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/Account/auth_id/Conference/conference_name/Member/member_id/Deaf/"
                    )
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conference.DeafMemberAsync(
                new DeafMemberRequest
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
                        "/api/v1/Account/MA_XXXXXX/Conference/conference_name/Member/member_id/Deaf/"
                    )
                    .UsingPost()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conference.DeafMemberAsync(
                new DeafMemberRequest
                {
                    AuthId = "MA_XXXXXX",
                    ConferenceName = "conference_name",
                    MemberId = "member_id",
                }
            )
        );
    }
}
