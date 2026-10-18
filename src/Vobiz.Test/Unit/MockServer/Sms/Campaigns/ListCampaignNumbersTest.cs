using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCampaignNumbersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "numberPreviews": [
                {
                  "numberKey": "numberKey",
                  "number": "number",
                  "countryCode": "countryCode"
                },
                {
                  "numberKey": "numberKey",
                  "number": "number",
                  "countryCode": "countryCode"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns/id/numbers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.ListCampaignNumbersAsync(
            new ListCampaignNumbersRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "numberPreviews": [
                {
                  "numberKey": "6f5e4d3c2b1a4c9d8e7f0a1b2c3d4e5f",
                  "number": "14155550100",
                  "countryCode": "US"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/10dlc/campaigns/4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24/numbers"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.ListCampaignNumbersAsync(
            new ListCampaignNumbersRequest { Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
