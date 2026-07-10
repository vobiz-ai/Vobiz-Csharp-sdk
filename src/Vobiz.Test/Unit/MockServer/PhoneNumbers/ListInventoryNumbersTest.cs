using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListInventoryNumbersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "account_id": "account_id",
                  "e164": "e164",
                  "country": "country",
                  "capabilities": {
                    "voice": true,
                    "sms": true,
                    "mms": true,
                    "fax": true
                  },
                  "status": "status",
                  "provider": "provider",
                  "setup_fee": 1,
                  "monthly_fee": 1,
                  "currency": "currency",
                  "voice_enabled": true,
                  "tags": {
                    "key": "value"
                  },
                  "is_blocked": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "is_trial_number": true,
                  "minimum_commitment_months": 1,
                  "aadhaar_verification_required": true,
                  "aadhaar_verified": true,
                  "region": "region"
                },
                {
                  "id": "id",
                  "account_id": "account_id",
                  "e164": "e164",
                  "country": "country",
                  "capabilities": {
                    "voice": true,
                    "sms": true,
                    "mms": true,
                    "fax": true
                  },
                  "status": "status",
                  "provider": "provider",
                  "setup_fee": 1,
                  "monthly_fee": 1,
                  "currency": "currency",
                  "voice_enabled": true,
                  "tags": {
                    "key": "value"
                  },
                  "is_blocked": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "is_trial_number": true,
                  "minimum_commitment_months": 1,
                  "aadhaar_verification_required": true,
                  "aadhaar_verified": true,
                  "region": "region"
                }
              ],
              "page": 1,
              "per_page": 1,
              "total": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/inventory/numbers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.ListInventoryNumbersAsync(
            new ListInventoryNumbersRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "550e8400-e29b-41d4-a716-446655440000",
                  "account_id": "account_id",
                  "e164": "+14155551234",
                  "country": "US",
                  "capabilities": {
                    "voice": true,
                    "sms": true,
                    "mms": true,
                    "fax": true
                  },
                  "status": "active",
                  "provider": "provider",
                  "setup_fee": 0,
                  "monthly_fee": 1,
                  "currency": "INR",
                  "voice_enabled": true,
                  "tags": {
                    "key": "value"
                  },
                  "is_blocked": true,
                  "created_at": "2025-01-15T10:00:00Z",
                  "updated_at": "2025-01-15T10:00:00Z",
                  "is_trial_number": true,
                  "minimum_commitment_months": 1,
                  "aadhaar_verification_required": true,
                  "aadhaar_verified": true,
                  "region": "CA"
                }
              ],
              "page": 1,
              "per_page": 25,
              "total": 500
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/inventory/numbers")
                    .WithParam("country", "IN")
                    .WithParam("exclude", "9180", "9192")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.ListInventoryNumbersAsync(
            new ListInventoryNumbersRequest
            {
                AuthId = "MA_XXXXXX",
                Country = "IN",
                Exclude = "9180,9192",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
