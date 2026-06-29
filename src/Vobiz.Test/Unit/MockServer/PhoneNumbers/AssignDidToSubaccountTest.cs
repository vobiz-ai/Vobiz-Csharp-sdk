using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AssignDidToSubaccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "sub_account_id": "sub_account_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/auth_id/numbers/e164/assign-subaccount")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.AssignDidToSubaccountAsync(
                new AssignDidToSubaccountRequest
                {
                    AuthId = "auth_id",
                    E164 = "e164",
                    SubAccountId = "sub_account_id",
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "sub_account_id": "SA_XXXXXX"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/MA_XXXXXX/numbers/%2B919876543210/assign-subaccount")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.AssignDidToSubaccountAsync(
                new AssignDidToSubaccountRequest
                {
                    AuthId = "MA_XXXXXX",
                    E164 = "%2B919876543210",
                    SubAccountId = "SA_XXXXXX",
                }
            )
        );
    }
}
