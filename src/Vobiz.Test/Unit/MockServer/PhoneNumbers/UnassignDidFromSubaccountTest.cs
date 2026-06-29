using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UnassignDidFromSubaccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/auth_id/numbers/e164/assign-subaccount")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.UnassignDidFromSubaccountAsync(
                new UnassignDidFromSubaccountRequest { AuthId = "auth_id", E164 = "e164" }
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
                    .WithPath("/api/v1/account/MA_XXXXXX/numbers/%2B919876543210/assign-subaccount")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.UnassignDidFromSubaccountAsync(
                new UnassignDidFromSubaccountRequest
                {
                    AuthId = "MA_XXXXXX",
                    E164 = "%2B919876543210",
                    Force = true,
                }
            )
        );
    }
}
