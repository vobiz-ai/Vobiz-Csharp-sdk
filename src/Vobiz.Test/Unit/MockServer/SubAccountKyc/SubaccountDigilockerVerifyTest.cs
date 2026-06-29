using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKyc;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubaccountDigilockerVerifyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "access_request_id": "access_request_id"
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
                    .WithPath("/api/v1/sub-accounts/sub_auth_id/kyc/digilocker/verify")
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

        var response = await Client.SubAccountKyc.SubaccountDigilockerVerifyAsync(
            new SubaccountDigilockerVerifyRequest
            {
                SubAuthId = "sub_auth_id",
                AccessRequestId = "access_request_id",
                LinkedNumber = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "access_request_id": "AR_xxxxxxxx"
            }
            """;

        const string mockResponse = """
            {
              "verification_type": "aadhaar",
              "status": "verified",
              "kyc_calls_blocked": true,
              "mock": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc/digilocker/verify")
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

        var response = await Client.SubAccountKyc.SubaccountDigilockerVerifyAsync(
            new SubaccountDigilockerVerifyRequest
            {
                SubAuthId = "SA_XXXXXX",
                AccessRequestId = "AR_xxxxxxxx",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
