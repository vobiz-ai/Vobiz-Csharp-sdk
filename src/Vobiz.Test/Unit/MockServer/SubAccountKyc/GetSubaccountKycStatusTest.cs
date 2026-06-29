using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKyc;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetSubaccountKycStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "sub_account_id": "sub_account_id",
              "kyc_mode": "personal_use",
              "business_type": "business_type",
              "overall_status": "not_started",
              "kyc_calls_blocked": true,
              "verifications": {
                "verifications": "not_started"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/sub_auth_id/kyc/status")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccountKyc.GetSubaccountKycStatusAsync(
            new GetSubaccountKycStatusRequest { SubAuthId = "sub_auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "sub_account_id": "SA_XXXXXX",
              "kyc_mode": "customer_use",
              "business_type": "private_limited",
              "overall_status": "pending",
              "kyc_calls_blocked": true,
              "verifications": {
                "pan": "verified",
                "gst": "pending",
                "aadhaar": "not_started",
                "cin": "not_started"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc/status")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubAccountKyc.GetSubaccountKycStatusAsync(
            new GetSubaccountKycStatusRequest { SubAuthId = "SA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
