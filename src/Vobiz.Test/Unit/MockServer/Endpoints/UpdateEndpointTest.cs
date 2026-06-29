using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Endpoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateEndpointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "alias": "alias",
              "password": "password"
            }
            """;

        const string mockResponse = """
            "string"
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Endpoint/endpoint_id/")
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

        var response = await Client.Endpoints.UpdateEndpointAsync(
            new UpdateEndpointRequest
            {
                AuthId = "auth_id",
                EndpointId = "endpoint_id",
                Alias = "alias",
                Password = "password",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "alias": "John's Updated Desktop Phone",
              "password": "NewSecurePassword456!"
            }
            """;

        const string mockResponse = """
            ""
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Endpoint/87654321/")
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

        var response = await Client.Endpoints.UpdateEndpointAsync(
            new UpdateEndpointRequest
            {
                AuthId = "MA_XXXXXX",
                EndpointId = "87654321",
                Alias = "John's Updated Desktop Phone",
                Password = "NewSecurePassword456!",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
