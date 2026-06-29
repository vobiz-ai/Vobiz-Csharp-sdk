using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKycTestMode;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MockSubaccountDigilockerVerifyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "access_request_id": "MOCK_AR_SUCCESS"
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
                    .WithPath("/api/v1/sub-accounts/test/sub_auth_id/kyc/digilocker/verify")
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

        var response = await Client.SubAccountKycTestMode.MockSubaccountDigilockerVerifyAsync(
            new MockSubaccountDigilockerVerifyRequest
            {
                SubAuthId = "sub_auth_id",
                AccessRequestId =
                    MockSubaccountDigilockerVerifyRequestAccessRequestId.MockArSuccess,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "access_request_id": "MOCK_AR_SUCCESS"
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
                    .WithPath("/api/v1/sub-accounts/test/SA_XXXXXX/kyc/digilocker/verify")
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

        var response = await Client.SubAccountKycTestMode.MockSubaccountDigilockerVerifyAsync(
            new MockSubaccountDigilockerVerifyRequest
            {
                SubAuthId = "SA_XXXXXX",
                AccessRequestId =
                    MockSubaccountDigilockerVerifyRequestAccessRequestId.MockArSuccess,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
