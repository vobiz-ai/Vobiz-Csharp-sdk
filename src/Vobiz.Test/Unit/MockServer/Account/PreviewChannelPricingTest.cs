using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Account;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PreviewChannelPricingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "resource_type": "concurrent_calls",
              "quantity": 10000,
              "monthly_cost": "monthly_cost",
              "currency": "currency",
              "breakdown": [
                {
                  "breakdown": {
                    "key": "value"
                  }
                },
                {
                  "breakdown": {
                    "key": "value"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/auth_id/channel-pricing-preview")
                    .WithParam("resource_type", "concurrent_calls")
                    .WithParam("quantity", "10000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Account.PreviewChannelPricingAsync(
            new PreviewChannelPricingRequest
            {
                AuthId = "auth_id",
                ResourceType = CapacityResourceType.ConcurrentCalls,
                Quantity = 10000,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "resource_type": "concurrent_calls",
              "quantity": 30,
              "monthly_cost": "10470.00",
              "currency": "INR",
              "breakdown": [
                {
                  "key": "value"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/MA_XXXX/channel-pricing-preview")
                    .WithParam("resource_type", "concurrent_calls")
                    .WithParam("quantity", "30")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Account.PreviewChannelPricingAsync(
            new PreviewChannelPricingRequest
            {
                AuthId = "MA_XXXX",
                ResourceType = CapacityResourceType.ConcurrentCalls,
                Quantity = 30,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
