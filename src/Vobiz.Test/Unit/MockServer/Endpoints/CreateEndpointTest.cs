using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Endpoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateEndpointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "username": "username",
              "password": "password",
              "alias": "alias",
              "application": 1
            }
            """;

        const string mockResponse = """
            {
              "alias": "alias",
              "endpoint_id": "endpoint_id",
              "username": "username"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Endpoint/")
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

        var response = await Client.Endpoints.CreateEndpointAsync(
            new CreateEndpointRequest
            {
                AuthId = "auth_id",
                Username = "username",
                Password = "password",
                Alias = "alias",
                Application = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "username": "john_doe",
              "password": "SecurePassword123!",
              "alias": "John's Desktop Phone",
              "application": 12345678
            }
            """;

        const string mockResponse = """
            {
              "alias": "Acme Desktop Phone",
              "endpoint_id": "193962768711692",
              "username": "acme_sip_user_01"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Endpoint/")
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

        var response = await Client.Endpoints.CreateEndpointAsync(
            new CreateEndpointRequest
            {
                AuthId = "MA_XXXXXX",
                Username = "john_doe",
                Password = "SecurePassword123!",
                Alias = "John's Desktop Phone",
                Application = 12345678,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
