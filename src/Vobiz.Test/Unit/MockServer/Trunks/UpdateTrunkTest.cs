using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Trunks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTrunkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name",
              "max_concurrent_calls": 1,
              "enabled": true
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
                    .WithPath("/api/v1/Account/auth_id/trunks/trunk_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Trunks.UpdateTrunkAsync(
            new UpdateTrunkRequest
            {
                AuthId = "auth_id",
                TrunkId = "trunk_id",
                Name = "name",
                MaxConcurrentCalls = 1,
                Enabled = true,
                WebhookUrl = null,
                WebhookMethod = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "name",
              "max_concurrent_calls": 1,
              "enabled": true
            }
            """;

        const string mockResponse = """
            {
              "trunk_id": "99887766-1234-5678-90ab-cdef12345678",
              "account_id": "MA_XXXXXXXX",
              "name": "Acme Production Trunk Updated",
              "trunk_domain": "99887766-1234-5678-90ab-cdef12345678.sip.vobiz.ai",
              "trunk_status": "active",
              "secure": false,
              "trunk_direction": "both",
              "concurrent_calls_limit": 10,
              "cps_limit": 2,
              "description": "",
              "transport": "udp",
              "recording": false,
              "enable_transcription": false,
              "pii_redaction": false,
              "webhook_method": "POST",
              "recording_webhook_enabled": false,
              "created_at": "2026-03-25T10:00:00Z",
              "updated_at": "2026-03-25T10:05:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/trunks/trunk_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Trunks.UpdateTrunkAsync(
            new UpdateTrunkRequest
            {
                AuthId = "MA_XXXXXX",
                TrunkId = "trunk_id",
                Name = "name",
                MaxConcurrentCalls = 1,
                Enabled = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
