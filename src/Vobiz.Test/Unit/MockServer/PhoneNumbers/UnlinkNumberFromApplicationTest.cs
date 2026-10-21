using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UnlinkNumberFromApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/numbers/e164/application")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.UnlinkNumberFromApplicationAsync(
                new UnlinkNumberFromApplicationRequest { AuthId = "auth_id", E164 = "e164" }
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers/%2B912271264217/application")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.UnlinkNumberFromApplicationAsync(
                new UnlinkNumberFromApplicationRequest
                {
                    AuthId = "MA_XXXXXX",
                    E164 = "%2B912271264217",
                }
            )
        );
    }
}
