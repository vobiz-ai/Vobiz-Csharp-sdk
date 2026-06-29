using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Credentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateCredentialTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "username": "username",
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
                    .WithPath("/api/v1/Account/auth_id/credentials")
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

        var response = await Client.Credentials.CreateCredentialAsync(
            new CreateCredentialRequest
            {
                AuthId = "auth_id",
                Username = "username",
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
              "username": "myuser",
              "password": "securepassword123"
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
              "updated_at": "2026-03-25T10:00:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/credentials")
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

        var response = await Client.Credentials.CreateCredentialAsync(
            new CreateCredentialRequest
            {
                AuthId = "MA_XXXXXX",
                Username = "myuser",
                Password = "securepassword123",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
