using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKyc;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubaccountDigilockerInitiateTest : BaseMockServerTest
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
                    .WithPath("/api/v1/sub-accounts/sub_auth_id/kyc/digilocker/initiate")
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

        var response = await Client.SubAccountKyc.SubaccountDigilockerInitiateAsync(
            new SubaccountDigilockerInitiateRequest
            {
                SubAuthId = "sub_auth_id",
                RedirectUrl = "redirect_url",
                OauthState = null,
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
              "auth_url": "https://api.digitallocker.gov.in/public/oauth2/1/authorize?...",
              "access_request_id": "AR_xxxxxxxx"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc/digilocker/initiate")
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

        var response = await Client.SubAccountKyc.SubaccountDigilockerInitiateAsync(
            new SubaccountDigilockerInitiateRequest
            {
                SubAuthId = "SA_XXXXXX",
                RedirectUrl = "https://partner.example.com/kyc/callback",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
