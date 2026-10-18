using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Brands;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BrandRegistrarStatusesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "registrar": "registrar",
                "state": "state",
                "brandIdentityStatus": "brandIdentityStatus",
                "brandAuthenticationStatus": "brandAuthenticationStatus",
                "rejectionReason": "rejectionReason"
              },
              {
                "registrar": "registrar",
                "state": "state",
                "brandIdentityStatus": "brandIdentityStatus",
                "brandAuthenticationStatus": "brandAuthenticationStatus",
                "rejectionReason": "rejectionReason"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/id/registrar-statuses")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Brands.BrandRegistrarStatusesAsync(
            new BrandRegistrarStatusesRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "registrar": "TCR",
                "state": "ACTIVE",
                "brandIdentityStatus": "VERIFIED",
                "brandAuthenticationStatus": "AUTHENTICATED",
                "rejectionReason": "rejectionReason"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/10dlc/brands/8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10/registrar-statuses"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Brands.BrandRegistrarStatusesAsync(
            new BrandRegistrarStatusesRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
