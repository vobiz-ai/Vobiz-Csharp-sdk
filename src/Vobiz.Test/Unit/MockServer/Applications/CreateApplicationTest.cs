using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "app_name": "app_name",
              "answer_url": "answer_url",
              "answer_method": "answer_method"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "api_id",
              "app_id": "app_id",
              "message": "message"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Application/")
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

        var response = await Client.Applications.CreateApplicationAsync(
            new CreateApplicationRequest
            {
                AuthId = "auth_id",
                AppName = "app_name",
                AnswerUrl = "answer_url",
                AnswerMethod = "answer_method",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "app_name": "My Voice Application",
              "answer_url": "https://example.com/answer",
              "answer_method": "POST"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "app_id": "12345678901234567",
              "message": "created"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Application/")
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

        var response = await Client.Applications.CreateApplicationAsync(
            new CreateApplicationRequest
            {
                AuthId = "MA_XXXXXX",
                AppName = "My Voice Application",
                AnswerUrl = "https://example.com/answer",
                AnswerMethod = "POST",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
