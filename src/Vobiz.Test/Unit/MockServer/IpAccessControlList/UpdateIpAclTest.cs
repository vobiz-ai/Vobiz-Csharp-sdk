using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.IpAccessControlList;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateIpAclTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name",
              "ip_address": "ip_address"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "account_id": "account_id",
              "ip_address": "ip_address",
              "description": "description",
              "enabled": true,
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/ip-acl/ip_acl_id")
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

        var response = await Client.IpAccessControlList.UpdateIpAclAsync(
            new UpdateIpAclRequest
            {
                AuthId = "auth_id",
                IpAclId = "ip_acl_id",
                Name = "name",
                IpAddress = "ip_address",
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
              "ip_address": "ip_address"
            }
            """;

        const string mockResponse = """
            {
              "id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "account_id": "MA_XXXXXXXX",
              "ip_address": "192.168.1.0/24",
              "description": "Datacenter ACL",
              "enabled": true,
              "created_at": "2026-03-25T10:00:00Z",
              "updated_at": "2026-03-25T11:30:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/ip-acl/ip_acl_id")
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

        var response = await Client.IpAccessControlList.UpdateIpAclAsync(
            new UpdateIpAclRequest
            {
                AuthId = "MA_XXXXXX",
                IpAclId = "ip_acl_id",
                Name = "name",
                IpAddress = "ip_address",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
