using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.OptOuts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateOptOutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "phoneNumber": "phoneNumber"
            }
            """;

        const string mockResponse = """
            {
              "status": "status"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/opt-outs")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.OptOuts.CreateOptOutAsync(
            new CreateOptOutRequest
            {
                PhoneNumber = "phoneNumber",
                Channel = null,
                Reason = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "phoneNumber": "+14155550123",
              "channel": "sms",
              "reason": "customer request"
            }
            """;

        const string mockResponse = """
            {
              "status": "ok"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/opt-outs")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.OptOuts.CreateOptOutAsync(
            new CreateOptOutRequest
            {
                PhoneNumber = "+14155550123",
                Channel = "sms",
                Reason = "customer request",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
