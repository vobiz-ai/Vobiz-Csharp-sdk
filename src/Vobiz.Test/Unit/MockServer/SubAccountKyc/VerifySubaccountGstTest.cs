using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.SubAccountKyc;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VerifySubaccountGstTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "gstin": "blackcurrant..."
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
                    .WithPath("/api/v1/sub-accounts/sub_auth_id/kyc/verify-gst")
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

        var response = await Client.SubAccountKyc.VerifySubaccountGstAsync(
            new VerifySubaccountGstRequest { SubAuthId = "sub_auth_id", Gstin = "blackcurrant..." }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "gstin": "29AAJCN5983D1Z0"
            }
            """;

        const string mockResponse = """
            {
              "verification_type": "gst",
              "status": "verified",
              "kyc_calls_blocked": true,
              "mock": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sub-accounts/SA_XXXXXX/kyc/verify-gst")
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

        var response = await Client.SubAccountKyc.VerifySubaccountGstAsync(
            new VerifySubaccountGstRequest { SubAuthId = "SA_XXXXXX", Gstin = "29AAJCN5983D1Z0" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
