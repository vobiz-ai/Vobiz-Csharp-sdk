using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKycTestMode;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MockFinalizePendingKycTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "verification_type": "pan",
              "outcome": "verified"
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
                    .WithPath("/api/v1/sub-accounts/test/sub_auth_id/kyc/finalize-pending")
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

        var response = await Client.SubAccountKycTestMode.MockFinalizePendingKycAsync(
            new MockFinalizePendingKycRequest
            {
                SubAuthId = "sub_auth_id",
                VerificationType = MockFinalizePendingKycRequestVerificationType.Pan,
                Outcome = MockFinalizePendingKycRequestOutcome.Verified,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "verification_type": "pan",
              "outcome": "verified"
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
                    .WithPath("/api/v1/sub-accounts/test/SA_XXXXXX/kyc/finalize-pending")
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

        var response = await Client.SubAccountKycTestMode.MockFinalizePendingKycAsync(
            new MockFinalizePendingKycRequest
            {
                SubAuthId = "SA_XXXXXX",
                VerificationType = MockFinalizePendingKycRequestVerificationType.Pan,
                Outcome = MockFinalizePendingKycRequestOutcome.Verified,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
