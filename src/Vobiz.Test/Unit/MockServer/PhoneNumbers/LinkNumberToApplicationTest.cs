using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LinkNumberToApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "application_id": "application_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/numbers/e164/application")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.LinkNumberToApplicationAsync(
                new LinkNumberToApplicationRequest
                {
                    AuthId = "auth_id",
                    E164 = "e164",
                    ApplicationId = "application_id",
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "application_id": "12345678901234567"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers/%2B912271264217/application")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.PhoneNumbers.LinkNumberToApplicationAsync(
                new LinkNumberToApplicationRequest
                {
                    AuthId = "MA_XXXXXX",
                    E164 = "%2B912271264217",
                    ApplicationId = "12345678901234567",
                }
            )
        );
    }
}
