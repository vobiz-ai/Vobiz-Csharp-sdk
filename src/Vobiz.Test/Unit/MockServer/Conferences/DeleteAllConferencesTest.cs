using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Conferences;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteAllConferencesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Conference/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conferences.DeleteAllConferencesAsync(
                new DeleteAllConferencesRequest { AuthId = "auth_id" }
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/Conference/")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Conferences.DeleteAllConferencesAsync(
                new DeleteAllConferencesRequest { AuthId = "MA_XXXXXX" }
            )
        );
    }
}
