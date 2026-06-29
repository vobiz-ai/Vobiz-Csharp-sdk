using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.IpAccessControlList;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListIpAclsTest : BaseMockServerTest
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
                  "ip_address": "ip_address",
                  "description": "description",
                  "enabled": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                },
                {
                  "id": "id",
                  "account_id": "account_id",
                  "ip_address": "ip_address",
                  "description": "description",
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
                    .WithPath("/api/v1/Account/auth_id/trunks/ip-acl")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.IpAccessControlList.ListIpAclsAsync(
            new ListIpAclsRequest { AuthId = "auth_id" }
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
                  "ip_address": "10.20.30.0/24",
                  "description": "Office IP",
                  "enabled": true,
                  "created_at": "2026-03-25T10:00:00Z",
                  "updated_at": "2026-03-25T10:00:00Z"
                },
                {
                  "id": "99887766-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "ip_address": "192.168.1.0/24",
                  "description": "Datacenter ACL",
                  "enabled": true,
                  "created_at": "2026-03-22T09:00:00Z",
                  "updated_at": "2026-03-22T09:00:00Z"
                },
                {
                  "id": "55667788-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "ip_address": "203.0.113.0/24",
                  "description": "Production SBC",
                  "enabled": true,
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
                    .WithPath("/api/v1/Account/MA_XXXXXX/trunks/ip-acl")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.IpAccessControlList.ListIpAclsAsync(
            new ListIpAclsRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
