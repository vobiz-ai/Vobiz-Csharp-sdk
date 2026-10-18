using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RemoveCampaignNumbersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
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
                    .WithPath("/api/v1/sms/10dlc/campaigns/id/numbers")
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.RemoveCampaignNumbersAsync(
            new RemoveCampaignNumbersRequest
            {
                Id = "id",
                Body = new CampaignNumbersRequest { Numbers = null, NumberKeys = null },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "numbers": [
                "14155550101"
              ]
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
                    .WithPath(
                        "/api/v1/sms/10dlc/campaigns/4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24/numbers"
                    )
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.RemoveCampaignNumbersAsync(
            new RemoveCampaignNumbersRequest
            {
                Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
                Body = new CampaignNumbersRequest
                {
                    Numbers = new List<string>() { "14155550101" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
