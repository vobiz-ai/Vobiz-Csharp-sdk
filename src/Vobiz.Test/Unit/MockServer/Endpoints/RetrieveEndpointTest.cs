using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Endpoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RetrieveEndpointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "alias": "alias",
              "application": "application",
              "endpoint_id": "endpoint_id",
              "resource_uri": "resource_uri",
              "sip_registered": "sip_registered",
              "sip_uri": "sip_uri",
              "sub_account": {
                "key": "value"
              },
              "username": "username"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Endpoint/endpoint_id/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Endpoints.RetrieveEndpointAsync(
            new RetrieveEndpointRequest { AuthId = "auth_id", EndpointId = "endpoint_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "alias": "Acme Desktop Phone",
              "application": "/v1/Account/MA_XXXXXXXX/Application/12345678901234567/",
              "endpoint_id": "147322537258167",
              "resource_uri": "/v1/Account/MA_XXXXXXXX/Endpoint/147322537258167/",
              "sip_registered": "false",
              "sip_uri": "sip:acme_sip_user_01@registrar.vobiz.ai",
              "username": "acme_sip_user_01"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Endpoint/87654321/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Endpoints.RetrieveEndpointAsync(
            new RetrieveEndpointRequest { AuthId = "MA_XXXXXX", EndpointId = "87654321" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
