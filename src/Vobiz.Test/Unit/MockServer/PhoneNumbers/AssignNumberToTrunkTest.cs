using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AssignNumberToTrunkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "trunk_group_id": "trunk_group_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/numbers/phone_number/assign")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.AssignNumberToTrunkAsync(
                new AssignNumberToTrunkRequest
                {
                    AuthId = "auth_id",
                    PhoneNumber = "phone_number",
                    TrunkGroupId = "trunk_group_id",
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "trunk_group_id": "e3e55a78-1234-5678-90ab-cdef12345678"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers/%2B912271264217/assign")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.AssignNumberToTrunkAsync(
                new AssignNumberToTrunkRequest
                {
                    AuthId = "MA_XXXXXX",
                    PhoneNumber = "%2B912271264217",
                    TrunkGroupId = "e3e55a78-1234-5678-90ab-cdef12345678",
                }
            )
        );
    }
}
