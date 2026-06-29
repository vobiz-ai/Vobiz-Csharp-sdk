using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PurchaseFromInventoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "e164": "e164"
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
                    .WithPath("/api/v1/Account/auth_id/numbers/purchase-from-inventory")
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

        var response = await Client.PhoneNumbers.PurchaseFromInventoryAsync(
            new PurchaseFromInventoryRequest
            {
                AuthId = "auth_id",
                E164 = "e164",
                Currency = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "e164": "+919876543210",
              "currency": "USD"
            }
            """;

        const string mockResponse = """
            {
              "message": "Number purchased successfully",
              "number": {
                "id": "aabbccdd-1234-5678-90ab-cdef12345678",
                "account_id": "MA_XXXXXXXX",
                "e164": "+919876543210",
                "country": "IN",
                "region": "Karnataka",
                "capabilities": {
                  "voice": true,
                  "sms": false,
                  "mms": false,
                  "fax": false
                },
                "status": "active",
                "provider": "",
                "setup_fee": 100,
                "monthly_fee": 1,
                "currency": "INR",
                "voice_enabled": true,
                "purchased_at": "2026-03-25T10:00:00Z",
                "is_blocked": false,
                "created_at": "2026-03-25T10:00:00Z",
                "updated_at": "2026-03-25T10:00:00Z",
                "is_trial_number": false,
                "minimum_commitment_months": 0,
                "aadhaar_verification_required": false,
                "aadhaar_verified": false,
                "source": "inventory"
              },
              "items": [
                {
                  "id": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "e164": "+919876543210",
                  "country": "IN",
                  "region": "Karnataka",
                  "capabilities": {
                    "voice": true,
                    "sms": false,
                    "mms": false,
                    "fax": false
                  },
                  "status": "active",
                  "monthly_fee": 1,
                  "currency": "INR"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers/purchase-from-inventory")
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

        var response = await Client.PhoneNumbers.PurchaseFromInventoryAsync(
            new PurchaseFromInventoryRequest
            {
                AuthId = "MA_XXXXXX",
                E164 = "+919876543210",
                Currency = "USD",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
