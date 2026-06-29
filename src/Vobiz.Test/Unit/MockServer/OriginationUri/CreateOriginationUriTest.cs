using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.OriginationUri;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateOriginationUriTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name",
              "sip_uri": "sip_uri",
              "priority": 1
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "account_id": "account_id",
              "uri": "uri",
              "priority": 1,
              "weight": 1,
              "enabled": true,
              "transport": "transport",
              "description": "description",
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/origination-uris")
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

        var response = await Client.OriginationUri.CreateOriginationUriAsync(
            new CreateOriginationUriRequest
            {
                AuthId = "auth_id",
                Name = "name",
                SipUri = "sip_uri",
                Priority = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "Primary SBC",
              "sip_uri": "sip:sbc.example.com",
              "priority": 1
            }
            """;

        const string mockResponse = """
            {
              "id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "account_id": "MA_XXXXXXXX",
              "uri": "sip:sbc1.example.com",
              "priority": 1,
              "weight": 10,
              "enabled": true,
              "transport": "TCP",
              "description": "Primary SBC",
              "created_at": "2026-03-25T10:00:00Z",
              "updated_at": "2026-03-25T10:00:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/origination-uris")
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

        var response = await Client.OriginationUri.CreateOriginationUriAsync(
            new CreateOriginationUriRequest
            {
                AuthId = "MA_XXXXXX",
                Name = "Primary SBC",
                SipUri = "sip:sbc.example.com",
                Priority = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
