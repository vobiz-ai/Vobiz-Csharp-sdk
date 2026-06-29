using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.IpAccessControlList;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateIpAclTest : BaseMockServerTest
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
                    .WithPath("/api/v1/Account/auth_id/ip-acl")
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

        var response = await Client.IpAccessControlList.CreateIpAclAsync(
            new CreateIpAclRequest
            {
                AuthId = "auth_id",
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
              "name": "Office IP",
              "ip_address": "ip_address"
            }
            """;

        const string mockResponse = """
            {
              "id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "account_id": "MA_XXXXXXXX",
              "ip_address": "10.20.30.0/24",
              "description": "",
              "enabled": true,
              "created_at": "2026-03-25T10:00:00Z",
              "updated_at": "2026-03-25T10:00:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/ip-acl")
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

        var response = await Client.IpAccessControlList.CreateIpAclAsync(
            new CreateIpAclRequest
            {
                AuthId = "MA_XXXXXX",
                Name = "Office IP",
                IpAddress = "ip_address",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
