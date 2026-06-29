using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Credentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCredentialsTest : BaseMockServerTest
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
                  "id": "id",
                  "account_id": "account_id",
                  "username": "username",
                  "password": "password",
                  "realm": "realm",
                  "enabled": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                },
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/trunks/credentials")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Credentials.ListCredentialsAsync(
            new ListCredentialsRequest { AuthId = "auth_id" }
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
                "total": 3
              },
              "objects": [
                {
                  "id": "11223344-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "username": "acme_sip_user_01",
                  "password": "<redacted>",
                  "realm": "MA_XXXXXXXX.sip.vobiz.ai",
                  "enabled": true,
                  "created_at": "2026-03-25T10:00:00Z",
                  "updated_at": "2026-03-25T10:00:00Z"
                },
                {
                  "id": "99887766-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "username": "office_phone_03",
                  "password": "<redacted>",
                  "realm": "MA_XXXXXXXX.sip.vobiz.ai",
                  "enabled": true,
                  "created_at": "2026-03-20T08:15:00Z",
                  "updated_at": "2026-03-20T08:15:00Z"
                },
                {
                  "id": "55667788-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "username": "sipuser_demo",
                  "password": "<redacted>",
                  "realm": "MA_XXXXXXXX.sip.vobiz.ai",
                  "enabled": true,
                  "created_at": "2026-03-15T14:42:00Z",
                  "updated_at": "2026-03-15T14:42:00Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/trunks/credentials")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Credentials.ListCredentialsAsync(
            new ListCredentialsRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
