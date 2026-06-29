using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Endpoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListEndpointsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "meta": {
                "limit": 1,
                "offset": 1,
                "total_count": 1,
                "next": {
                  "key": "value"
                },
                "previous": {
                  "key": "value"
                }
              },
              "objects": [
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
                },
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Endpoint/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Endpoints.ListEndpointsAsync(
            new ListEndpointsRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "meta": {
                "limit": 20,
                "offset": 0,
                "total_count": 4
              },
              "objects": [
                {
                  "alias": "Acme Desktop Phone",
                  "application": "/v1/Account/MA_XXXXXXXX/Application/12345678901234567/",
                  "endpoint_id": "147322537258167",
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/Endpoint/147322537258167/",
                  "sip_registered": "false",
                  "sip_uri": "sip:acme_sip_user_01@registrar.vobiz.ai",
                  "username": "acme_sip_user_01"
                },
                {
                  "alias": "SIP Demo Phone",
                  "endpoint_id": "125649946800674",
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/Endpoint/125649946800674/",
                  "sip_registered": "false",
                  "sip_uri": "sip:sipuser_demo@registrar.vobiz.ai",
                  "username": "sipuser_demo"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Endpoint/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Endpoints.ListEndpointsAsync(
            new ListEndpointsRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
