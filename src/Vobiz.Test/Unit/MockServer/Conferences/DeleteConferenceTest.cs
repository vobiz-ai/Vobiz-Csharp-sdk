using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Conferences;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteConferenceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Conference/conference_name/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conferences.DeleteConferenceAsync(
                new DeleteConferenceRequest
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/Conference/conference_name/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conferences.DeleteConferenceAsync(
                new DeleteConferenceRequest
                {
                    AuthId = "MA_XXXXXX",
                    ConferenceName = "conference_name",
                }
            )
        );
    }
}
