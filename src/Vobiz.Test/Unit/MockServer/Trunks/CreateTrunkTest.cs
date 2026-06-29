using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Trunks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTrunkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name",
              "trunk_type": "trunk_type",
              "max_concurrent_calls": 1
            }
            """;

        const string mockResponse = """
            {
              "trunk_id": "trunk_id",
              "account_id": "account_id",
              "name": "name",
              "trunk_domain": "trunk_domain",
              "trunk_status": "trunk_status",
              "secure": true,
              "trunk_direction": "trunk_direction",
              "concurrent_calls_limit": 1,
              "cps_limit": 1,
              "description": "description",
              "transport": "transport",
              "recording": true,
              "enable_transcription": true,
              "pii_redaction": true,
              "webhook_method": "webhook_method",
              "recording_webhook_enabled": true,
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/trunks")
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

        var response = await Client.Trunks.CreateTrunkAsync(
            new CreateTrunkRequest
            {
                AuthId = "auth_id",
                Name = "name",
                TrunkType = "trunk_type",
                MaxConcurrentCalls = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "My Outbound Trunk",
              "trunk_type": "OUTBOUND",
              "max_concurrent_calls": 10
            }
            """;

        const string mockResponse = """
            {
              "trunk_id": "trunk_id",
              "account_id": "account_id",
              "name": "name",
              "trunk_domain": "trunk_domain",
              "trunk_status": "trunk_status",
              "secure": true,
              "trunk_direction": "trunk_direction",
              "concurrent_calls_limit": 1,
              "cps_limit": 1,
              "description": "description",
              "transport": "transport",
              "recording": true,
              "enable_transcription": true,
              "pii_redaction": true,
              "webhook_method": "webhook_method",
              "recording_webhook_enabled": true,
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/trunks")
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

        var response = await Client.Trunks.CreateTrunkAsync(
            new CreateTrunkRequest
            {
                AuthId = "MA_XXXXXX",
                Name = "My Outbound Trunk",
                TrunkType = "OUTBOUND",
                MaxConcurrentCalls = 10,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
