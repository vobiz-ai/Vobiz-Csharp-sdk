using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.OriginationUri;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOriginationUrisTest : BaseMockServerTest
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
                  "uri": "uri",
                  "priority": 1,
                  "weight": 1,
                  "enabled": true,
                  "transport": "transport",
                  "description": "description",
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                },
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/trunks/origination-uris")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OriginationUri.ListOriginationUrisAsync(
            new ListOriginationUrisRequest { AuthId = "auth_id" }
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
                  "uri": "sip:sbc1.example.com",
                  "priority": 1,
                  "weight": 10,
                  "enabled": true,
                  "transport": "udp",
                  "description": "Primary SBC",
                  "created_at": "2026-03-25T10:00:00Z",
                  "updated_at": "2026-03-25T10:00:00Z"
                },
                {
                  "id": "99887766-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "uri": "sip:sbc2.example.com",
                  "priority": 2,
                  "weight": 10,
                  "enabled": true,
                  "transport": "tcp",
                  "description": "US East SBC",
                  "created_at": "2026-03-22T09:00:00Z",
                  "updated_at": "2026-03-22T09:00:00Z"
                },
                {
                  "id": "55667788-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "uri": "sip:sbc3.example.com",
                  "priority": 10,
                  "weight": 10,
                  "enabled": true,
                  "transport": "tls",
                  "description": "",
                  "created_at": "2026-03-18T14:41:41Z",
                  "updated_at": "2026-03-18T14:41:41Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/trunks/origination-uris")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OriginationUri.ListOriginationUrisAsync(
            new ListOriginationUrisRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
