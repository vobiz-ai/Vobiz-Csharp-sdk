using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "app_name": "app_name",
              "default_number_app": true
            }
            """;

        const string mockResponse = """
            {
              "api_id": "api_id",
              "message": "message"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Application/app_id/")
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

        var response = await Client.Applications.UpdateApplicationAsync(
            new UpdateApplicationRequest
            {
                AuthId = "auth_id",
                AppId = "app_id",
                AppName = "app_name",
                DefaultNumberApp = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "app_name": "Updated Application Name",
              "default_number_app": true
            }
            """;

        const string mockResponse = """
            {
              "api_id": "11223344-5566-7788-99aa-bbccddeeff00",
              "message": "changed"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Application/12345678/")
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

        var response = await Client.Applications.UpdateApplicationAsync(
            new UpdateApplicationRequest
            {
                AuthId = "MA_XXXXXX",
                AppId = "12345678",
                AppName = "Updated Application Name",
                DefaultNumberApp = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
