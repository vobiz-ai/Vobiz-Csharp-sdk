using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListApplicationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "meta": {
                "limit": 1,
                "next": "next",
                "offset": 1,
                "previous": {
                  "key": "value"
                },
                "total_count": 1
              },
              "objects": [
                {
                  "answer_method": "answer_method",
                  "answer_url": "answer_url",
                  "app_id": "app_id",
                  "app_name": "app_name",
                  "application_type": "application_type",
                  "created_at": "created_at",
                  "default_app": true,
                  "default_endpoint_app": true,
                  "enabled": true,
                  "fallback_answer_url": "fallback_answer_url",
                  "fallback_method": "fallback_method",
                  "hangup_method": "hangup_method",
                  "hangup_url": "hangup_url",
                  "log_incoming_message": true,
                  "message_method": "message_method",
                  "message_url": "message_url",
                  "public_uri": true,
                  "resource_uri": "resource_uri",
                  "sip_transfer_method": "sip_transfer_method",
                  "sip_transfer_url": {
                    "key": "value"
                  },
                  "sip_uri": "sip_uri",
                  "sub_account": {
                    "key": "value"
                  },
                  "updated_at": "updated_at"
                },
                {
                  "answer_method": "answer_method",
                  "answer_url": "answer_url",
                  "app_id": "app_id",
                  "app_name": "app_name",
                  "application_type": "application_type",
                  "created_at": "created_at",
                  "default_app": true,
                  "default_endpoint_app": true,
                  "enabled": true,
                  "fallback_answer_url": "fallback_answer_url",
                  "fallback_method": "fallback_method",
                  "hangup_method": "hangup_method",
                  "hangup_url": "hangup_url",
                  "log_incoming_message": true,
                  "message_method": "message_method",
                  "message_url": "message_url",
                  "public_uri": true,
                  "resource_uri": "resource_uri",
                  "sip_transfer_method": "sip_transfer_method",
                  "sip_transfer_url": {
                    "key": "value"
                  },
                  "sip_uri": "sip_uri",
                  "sub_account": {
                    "key": "value"
                  },
                  "updated_at": "updated_at"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Application/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ListApplicationsAsync(
            new ListApplicationsRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "meta": {
                "limit": 20,
                "next": "/v1/Account/MA_XXXXXXXX/Application/?limit=20&offset=20",
                "offset": 0,
                "total_count": 23
              },
              "objects": [
                {
                  "answer_method": "POST",
                  "answer_url": "https://example.com/answer",
                  "app_id": "12345678901234567",
                  "app_name": "My Voice App",
                  "application_type": "XML",
                  "created_at": "2026-04-02 12:11:19.740666+00:00",
                  "default_app": true,
                  "default_endpoint_app": false,
                  "enabled": true,
                  "fallback_method": "POST",
                  "hangup_method": "POST",
                  "hangup_url": "https://example.com/hangup",
                  "log_incoming_message": true,
                  "message_method": "POST",
                  "public_uri": false,
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/Application/12345678901234567/",
                  "sip_transfer_method": "POST",
                  "sip_uri": "sip:12345678901234567@app.vobiz.ai",
                  "updated_at": "2026-04-02 12:11:19.740666+00:00"
                },
                {
                  "answer_method": "POST",
                  "answer_url": "https://example.com/answer",
                  "app_id": "11223344556677889",
                  "app_name": "Acme Voice Application",
                  "application_type": "XML",
                  "created_at": "2026-03-25 09:33:08.869648+00:00",
                  "default_app": false,
                  "default_endpoint_app": false,
                  "enabled": true,
                  "fallback_method": "POST",
                  "hangup_method": "POST",
                  "hangup_url": "https://example.com/hangup",
                  "log_incoming_message": true,
                  "message_method": "POST",
                  "public_uri": false,
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/Application/11223344556677889/",
                  "sip_transfer_method": "POST",
                  "sip_uri": "sip:11223344556677889@app.vobiz.ai",
                  "updated_at": "2026-03-25 09:33:08.869648+00:00"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Application/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ListApplicationsAsync(
            new ListApplicationsRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
