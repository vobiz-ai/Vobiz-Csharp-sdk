using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKyc;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ConfirmSubaccountCinTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "company_name": "company_name",
              "selected_cin": "selected_cin"
            }
            """;

        const string mockResponse = """
            {
              "verification_type": "pan",
              "status": "verified",
              "kyc_calls_blocked": true,
              "mock": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/sub_auth_id/kyc/cin/confirm")
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

        var response = await Client.SubAccountKyc.ConfirmSubaccountCinAsync(
            new ConfirmSubaccountCinRequest
            {
                SubAuthId = "sub_auth_id",
                CompanyName = "company_name",
                SelectedCin = "selected_cin",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "company_name": "ACME PRIVATE LIMITED",
              "selected_cin": "U72900KA2024PTC123456"
            }
            """;

        const string mockResponse = """
            {
              "verification_type": "cin",
              "status": "verified",
              "kyc_calls_blocked": true,
              "mock": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc/cin/confirm")
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

        var response = await Client.SubAccountKyc.ConfirmSubaccountCinAsync(
            new ConfirmSubaccountCinRequest
            {
                SubAuthId = "SA_XXXXXX",
                CompanyName = "ACME PRIVATE LIMITED",
                SelectedCin = "U72900KA2024PTC123456",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
