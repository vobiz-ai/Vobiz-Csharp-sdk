using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Trunks;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTrunksTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "meta": {
                "limit": 1,
                "offset": 1,
                "total": 1
              },
              "objects": [
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
                  "credential_uuid": "credential_uuid",
                  "description": "description",
                  "transport": "transport",
                  "recording": true,
                  "enable_transcription": true,
                  "pii_redaction": true,
                  "webhook_method": "webhook_method",
                  "recording_webhook_enabled": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "primary_uri_uuid": "primary_uri_uuid",
                  "inbound_destination": "inbound_destination",
                  "pii_entity_types": "pii_entity_types",
                  "webhook_url": "webhook_url"
                },
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
                  "credential_uuid": "credential_uuid",
                  "description": "description",
                  "transport": "transport",
                  "recording": true,
                  "enable_transcription": true,
                  "pii_redaction": true,
                  "webhook_method": "webhook_method",
                  "recording_webhook_enabled": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "primary_uri_uuid": "primary_uri_uuid",
                  "inbound_destination": "inbound_destination",
                  "pii_entity_types": "pii_entity_types",
                  "webhook_url": "webhook_url"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/trunks")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Trunks.ListTrunksAsync(
            new ListTrunksRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "meta": {
                "limit": 20,
                "offset": 0,
                "total": 2
              },
              "objects": [
                {
                  "trunk_id": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "name": "My Outbound Trunk",
                  "trunk_domain": "aabbccdd-1234-5678-90ab-cdef12345678.sip.vobiz.ai",
                  "trunk_status": "active",
                  "secure": false,
                  "trunk_direction": "outbound",
                  "concurrent_calls_limit": 10,
                  "cps_limit": 2,
                  "credential_uuid": "11223344-5566-7788-99aa-bbccddeeff00",
                  "description": "",
                  "transport": "udp",
                  "recording": true,
                  "enable_transcription": true,
                  "pii_redaction": false,
                  "webhook_method": "POST",
                  "recording_webhook_enabled": false,
                  "created_at": "2026-03-25T08:52:02.383938Z",
                  "updated_at": "2026-03-25T08:52:02.383938Z",
                  "primary_uri_uuid": "primary_uri_uuid",
                  "inbound_destination": "inbound_destination",
                  "pii_entity_types": "pii_entity_types",
                  "webhook_url": "webhook_url"
                },
                {
                  "trunk_id": "99887766-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "name": "Acme Production Trunk",
                  "trunk_domain": "99887766-1234-5678-90ab-cdef12345678.sip.vobiz.ai",
                  "trunk_status": "active",
                  "secure": false,
                  "trunk_direction": "inbound",
                  "concurrent_calls_limit": 10,
                  "cps_limit": 2,
                  "credential_uuid": "credential_uuid",
                  "description": "",
                  "transport": "udp",
                  "recording": true,
                  "enable_transcription": true,
                  "pii_redaction": false,
                  "webhook_method": "POST",
                  "recording_webhook_enabled": false,
                  "created_at": "2026-03-25T10:28:06.112095Z",
                  "updated_at": "2026-03-25T10:28:06.112095Z",
                  "primary_uri_uuid": "55667788-1234-5678-90ab-cdef12345678",
                  "inbound_destination": "55667788-1234-5678-90ab-cdef12345678",
                  "pii_entity_types": "",
                  "webhook_url": "https://webhook.site/example"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/trunks")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Trunks.ListTrunksAsync(
            new ListTrunksRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
