using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKycTestMode;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MockSubaccountDigilockerInitiateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "redirect_url": "redirect_url"
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
                    .WithPath("/api/v1/sub-accounts/test/sub_auth_id/kyc/digilocker/initiate")
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

        var response = await Client.SubAccountKycTestMode.MockSubaccountDigilockerInitiateAsync(
            new MockSubaccountDigilockerInitiateRequest
            {
                SubAuthId = "sub_auth_id",
                RedirectUrl = "redirect_url",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "redirect_url": "https://partner.example.com/kyc/callback"
            }
            """;

        const string mockResponse = """
            {
              "auth_url": "https://kyc.vobiz.ai/mock/digilocker",
              "access_request_id": "MOCK_AR_SUCCESS"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/test/SA_XXXXXX/kyc/digilocker/initiate")
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

        var response = await Client.SubAccountKycTestMode.MockSubaccountDigilockerInitiateAsync(
            new MockSubaccountDigilockerInitiateRequest
            {
                SubAuthId = "SA_XXXXXX",
                RedirectUrl = "https://partner.example.com/kyc/callback",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
