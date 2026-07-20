using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UnrentNumberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "cancel_url": "cancel_url",
              "cooldown_ends_at": "2024-01-15T09:30:00.000Z",
              "message": "message",
              "note": "note",
              "release_fee": 1.1,
              "status": "status"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/numbers/e164")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.UnrentNumberAsync(
            new UnrentNumberRequest { AuthId = "auth_id", E164 = "e164" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "cancel_url": "/api/v1/account/MA_XXXXXX/numbers/+919876543210/cancel-release",
              "cooldown_ends_at": "2026-07-21T09:18:26.000Z",
              "message": "number release initiated",
              "note": "Number will be in pending_release for 24 hours (cancellable), then quarantined for 45 days before becoming available.",
              "release_fee": 700,
              "status": "pending_release"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers/%2B919876543210")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.UnrentNumberAsync(
            new UnrentNumberRequest { AuthId = "MA_XXXXXX", E164 = "%2B919876543210" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
