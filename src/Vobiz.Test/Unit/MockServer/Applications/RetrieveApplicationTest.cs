using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RetrieveApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "answer_method": "answer_method",
              "answer_url": "answer_url",
              "api_id": "api_id",
              "app_id": "app_id",
              "app_name": "app_name",
              "application_type": "application_type",
              "created_at": "created_at",
              "default_app": true,
              "default_endpoint_app": true,
              "enabled": true,
              "fallback_answer_url": {
                "key": "value"
              },
              "fallback_method": "fallback_method",
              "hangup_method": "hangup_method",
              "hangup_url": "hangup_url",
              "log_incoming_message": true,
              "message_method": "message_method",
              "message_url": {
                "key": "value"
              },
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Application/app_id/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.RetrieveApplicationAsync(
            new RetrieveApplicationRequest { AuthId = "auth_id", AppId = "app_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "answer_method": "GET",
              "answer_url": "https://example.com/answer",
              "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "app_id": "12345678901234567",
              "app_name": "My Voice App",
              "application_type": "XML",
              "created_at": "2026-03-25 10:00:00.000000+00:00",
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
              "updated_at": "2026-03-25 10:00:00.000000+00:00"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Application/12345678/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.RetrieveApplicationAsync(
            new RetrieveApplicationRequest { AuthId = "MA_XXXXXX", AppId = "12345678" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
