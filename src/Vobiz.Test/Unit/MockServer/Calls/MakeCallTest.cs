using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Calls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MakeCallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "from": "from",
              "to": "to",
              "answer_url": "answer_url",
              "answer_method": "answer_method"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "api_id",
              "message": "message",
              "request_uuid": "request_uuid"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/")
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

        var response = await Client.Calls.MakeCallAsync(
            new MakeCallRequest
            {
                AuthId = "auth_id",
                From = "from",
                To = "to",
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
              "from": "14155551234",
              "to": "+919876543210",
              "answer_url": "https://example.com/answer",
              "answer_method": "POST"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "5a9fcfee-3d4c-11ef-bef9-0242ac110005",
              "message": "Call fired",
              "request_uuid": "5a9fd4a0-3d4c-11ef-bef9-0242ac110005"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/")
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

        var response = await Client.Calls.MakeCallAsync(
            new MakeCallRequest
            {
                AuthId = "MA_XXXXXX",
                From = "14155551234",
                To = "+919876543210",
                AnswerUrl = "https://example.com/answer",
                AnswerMethod = "POST",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
