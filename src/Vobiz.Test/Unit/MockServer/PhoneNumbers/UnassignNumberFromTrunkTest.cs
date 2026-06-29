using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UnassignNumberFromTrunkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/numbers/phone_number/assign")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.UnassignNumberFromTrunkAsync(
                new UnassignNumberFromTrunkRequest
                {
                    AuthId = "auth_id",
                    PhoneNumber = "phone_number",
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers/%2B912271264217/assign")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.UnassignNumberFromTrunkAsync(
                new UnassignNumberFromTrunkRequest
                {
                    AuthId = "MA_XXXXXX",
                    PhoneNumber = "%2B912271264217",
                }
            )
        );
    }
}
