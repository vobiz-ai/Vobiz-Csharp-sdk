using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CancelNumberReleaseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "message": "message",
              "status": "active",
              "currency": "currency",
              "refund_amount": 1.1,
              "refund_status": "success",
              "refund_error": "refund_error"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/account_id/numbers/e164/cancel-release")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.CancelNumberReleaseAsync(
            new CancelNumberReleaseRequest { AccountId = "account_id", E164 = "e164" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "message": "release cancelled, number restored to active status",
              "status": "active",
              "currency": "INR",
              "refund_amount": 700,
              "refund_status": "success",
              "refund_error": "refund_error"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/MA_XXXXXX/numbers/%2B919876543210/cancel-release")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.CancelNumberReleaseAsync(
            new CancelNumberReleaseRequest { AccountId = "MA_XXXXXX", E164 = "%2B919876543210" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "message": "release cancelled, number restored to active status",
              "status": "active",
              "currency": "currency",
              "refund_amount": 1.1,
              "refund_status": "failed",
              "refund_error": "could not process refund, please contact support"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/MA_XXXXXX/numbers/%2B919876543210/cancel-release")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.CancelNumberReleaseAsync(
            new CancelNumberReleaseRequest { AccountId = "MA_XXXXXX", E164 = "%2B919876543210" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
