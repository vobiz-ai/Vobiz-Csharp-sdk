using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKycTestMode;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MockSearchSubaccountCinTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "company_name": "company_name"
            }
            """;

        const string mockResponse = """
            {
              "key": "value"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/test/sub_auth_id/kyc/cin/search")
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

        var response = await Client.SubAccountKycTestMode.MockSearchSubaccountCinAsync(
            new MockSearchSubaccountCinRequest
            {
                SubAuthId = "sub_auth_id",
                CompanyName = "company_name",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "company_name": "ACME"
            }
            """;

        const string mockResponse = """
            {
              "matches": [
                {
                  "cin": "U72900KA2024PTC123456",
                  "company_name": "ACME PRIVATE LIMITED",
                  "status": "Active"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/test/SA_XXXXXX/kyc/cin/search")
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

        var response = await Client.SubAccountKycTestMode.MockSearchSubaccountCinAsync(
            new MockSearchSubaccountCinRequest { SubAuthId = "SA_XXXXXX", CompanyName = "ACME" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
