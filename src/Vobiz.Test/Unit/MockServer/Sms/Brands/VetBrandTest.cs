using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Brands;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VetBrandTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "string": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/id/vet")
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

        var response = await Client.Sms.Brands.VetBrandAsync(
            new BrandVetRequest { Id = "id", Type = null }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "type": "STANDARD"
            }
            """;

        const string mockResponse = """
            {
              "vettingId": "4b3a2c1d-0e9f-4a8b-9c7d-6e5f4a3b2c1d",
              "vettingClass": "STANDARD",
              "vettingStatus": "PENDING",
              "createDate": "2026-10-12T11:10:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10/vet")
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

        var response = await Client.Sms.Brands.VetBrandAsync(
            new BrandVetRequest
            {
                Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10",
                Type = BrandVetRequestType.Standard,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
