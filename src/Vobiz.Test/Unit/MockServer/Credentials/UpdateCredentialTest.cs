using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Credentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateCredentialTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "password": "password"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "account_id": "account_id",
              "username": "username",
              "password": "password",
              "realm": "realm",
              "enabled": true,
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/credentials/credential_id")
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

        var response = await Client.Credentials.UpdateCredentialAsync(
            new UpdateCredentialRequest
            {
                AuthId = "auth_id",
                CredentialId = "credential_id",
                Password = "password",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "password": "password"
            }
            """;

        const string mockResponse = """
            {
              "id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "account_id": "MA_XXXXXXXX",
              "username": "acme_sip_user_01",
              "password": "<redacted>",
              "realm": "MA_XXXXXXXX.sip.vobiz.ai",
              "enabled": true,
              "created_at": "2026-03-25T10:00:00Z",
              "updated_at": "2026-03-25T11:30:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/credentials/credential_id")
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

        var response = await Client.Credentials.UpdateCredentialAsync(
            new UpdateCredentialRequest
            {
                AuthId = "MA_XXXXXX",
                CredentialId = "credential_id",
                Password = "password",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
