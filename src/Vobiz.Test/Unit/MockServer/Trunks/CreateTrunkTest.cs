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
              "name": "name"
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
                TrunkDirection = null,
                TrunkStatus = null,
                Secure = null,
                TrunkDomain = null,
                Transport = null,
                InboundDestination = null,
                Description = null,
                ConcurrentCallsLimit = null,
                CpsLimit = null,
                CredentialUuid = null,
                IpaclUuid = null,
                PrimaryUriUuid = null,
                FallbackUriUuid = null,
                Recording = null,
                EnableTranscription = null,
                PiiRedaction = null,
                PiiEntityTypes = null,
                WebhookUrl = null,
                WebhookMethod = null,
                RecordingWebhookEnabled = null,
                Username = null,
                Password = null,
                IpWhitelist = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "Retell AI SIP",
              "trunk_direction": "outbound",
              "transport": "udp",
              "concurrent_calls_limit": 50,
              "cps_limit": 15,
              "credential_uuid": "b1e2...",
              "ipacl_uuid": "c3d4...",
              "recording": true,
              "enable_transcription": true,
              "webhook_url": "https://example.com/vobiz/webhook",
              "webhook_method": "POST"
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
                Name = "Retell AI SIP",
                TrunkDirection = CreateTrunkRequestTrunkDirection.Outbound,
                Transport = CreateTrunkRequestTransport.Udp,
                ConcurrentCallsLimit = 50,
                CpsLimit = 15,
                CredentialUuid = "b1e2...",
                IpaclUuid = "c3d4...",
                Recording = true,
                EnableTranscription = true,
                WebhookUrl = "https://example.com/vobiz/webhook",
                WebhookMethod = CreateTrunkRequestWebhookMethod.Post,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
