using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Dtmf;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SendDtmfTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "digits": "digits"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/DTMF/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Dtmf.SendDtmfAsync(
                new SendDtmfRequest
                {
                    AuthId = "auth_id",
                    CallUuid = "call_uuid",
                    Digits = "digits",
                    Leg = null,
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "digits": "1234",
              "leg": "aleg"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/call_uuid/DTMF/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Dtmf.SendDtmfAsync(
                new SendDtmfRequest
                {
                    AuthId = "MA_XXXXXX",
                    CallUuid = "call_uuid",
                    Digits = "1234",
                    Leg = SendDtmfRequestLeg.Aleg,
                }
            )
        );
    }
}
