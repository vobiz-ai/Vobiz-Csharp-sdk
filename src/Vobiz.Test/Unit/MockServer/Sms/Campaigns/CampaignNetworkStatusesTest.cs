using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CampaignNetworkStatusesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "network": "network",
                "state": "state",
                "messageClass": "messageClass",
                "throughput": 1,
                "brandTier": "brandTier"
              },
              {
                "network": "network",
                "state": "state",
                "messageClass": "messageClass",
                "throughput": 1,
                "brandTier": "brandTier"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns/id/network-statuses")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.CampaignNetworkStatusesAsync(
            new CampaignNetworkStatusesRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "network": "T_MOBILE",
                "state": "ACTIVE",
                "messageClass": "24",
                "throughput": 2000,
                "brandTier": "LOW"
              },
              {
                "network": "ATT",
                "state": "ACTIVE",
                "messageClass": "T",
                "throughput": 75,
                "brandTier": "LOW"
              },
              {
                "network": "VERIZON",
                "state": "ACTIVE",
                "messageClass": "T",
                "throughput": 75,
                "brandTier": "LOW"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/10dlc/campaigns/4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24/network-statuses"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.CampaignNetworkStatusesAsync(
            new CampaignNetworkStatusesRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
