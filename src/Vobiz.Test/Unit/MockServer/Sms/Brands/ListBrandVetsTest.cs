using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Brands;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListBrandVetsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "results": [
                {
                  "results": {
                    "key": "value"
                  }
                },
                {
                  "results": {
                    "key": "value"
                  }
                }
              ],
              "paging": {
                "page": 1,
                "size": 1,
                "totalPages": 1,
                "totalResults": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/id/vets")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Brands.ListBrandVetsAsync(
            new ListBrandVetsRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "results": [
                {
                  "key": "value"
                }
              ],
              "paging": {
                "page": 0,
                "size": 10,
                "totalPages": 0,
                "totalResults": 0
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10/vets")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Brands.ListBrandVetsAsync(
            new ListBrandVetsRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
