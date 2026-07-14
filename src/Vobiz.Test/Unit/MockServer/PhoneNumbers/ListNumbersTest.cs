using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListNumbersTest : BaseMockServerTest
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
                  "region": "region",
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
                  "application_id": "application_id",
                  "voice_enabled": true,
                  "tags": [
                    "tags",
                    "tags"
                  ],
                  "purchased_at": "purchased_at",
                  "is_blocked": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "is_trial_number": true,
                  "last_billing_date": "last_billing_date",
                  "next_billing_date": "next_billing_date",
                  "minimum_commitment_months": 1,
                  "aadhaar_verification_required": true,
                  "aadhaar_verified": true,
                  "source": "source",
                  "released_at": "released_at",
                  "trunk_group_id": "trunk_group_id"
                },
                {
                  "id": "id",
                  "account_id": "account_id",
                  "e164": "e164",
                  "country": "country",
                  "region": "region",
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
                  "application_id": "application_id",
                  "voice_enabled": true,
                  "tags": [
                    "tags",
                    "tags"
                  ],
                  "purchased_at": "purchased_at",
                  "is_blocked": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "is_trial_number": true,
                  "last_billing_date": "last_billing_date",
                  "next_billing_date": "next_billing_date",
                  "minimum_commitment_months": 1,
                  "aadhaar_verification_required": true,
                  "aadhaar_verified": true,
                  "source": "source",
                  "released_at": "released_at",
                  "trunk_group_id": "trunk_group_id"
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
                    .WithPath("/api/v1/Account/auth_id/numbers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.ListNumbersAsync(
            new ListNumbersRequest { AuthId = "auth_id" }
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
                  "monthly_fee": 300,
                  "currency": "INR",
                  "application_id": "20577609616603585",
                  "voice_enabled": true,
                  "tags": [
                    "tags"
                  ],
                  "purchased_at": "2026-03-25T06:58:38.796024Z",
                  "is_blocked": false,
                  "created_at": "2026-03-25T18:30:00Z",
                  "updated_at": "2026-03-25T06:58:54.752187Z",
                  "is_trial_number": false,
                  "last_billing_date": "2026-03-25T06:58:38.796024Z",
                  "next_billing_date": "2026-04-25T06:58:38.796024Z",
                  "minimum_commitment_months": 0,
                  "aadhaar_verification_required": false,
                  "aadhaar_verified": false,
                  "source": "purchased",
                  "released_at": "released_at",
                  "trunk_group_id": "trunk_group_id"
                },
                {
                  "id": "11223344-5566-7788-99aa-bbccddeeff00",
                  "account_id": "MA_XXXXXXXX",
                  "e164": "+912271263984",
                  "country": "IN",
                  "region": "Mumbai",
                  "capabilities": {
                    "voice": true,
                    "sms": false,
                    "mms": false,
                    "fax": false
                  },
                  "status": "active",
                  "provider": "",
                  "setup_fee": 100,
                  "monthly_fee": 200,
                  "currency": "INR",
                  "application_id": "31985999331899218",
                  "voice_enabled": true,
                  "tags": [
                    "tags"
                  ],
                  "purchased_at": "2026-03-25T10:25:30.672202Z",
                  "is_blocked": false,
                  "created_at": "2026-03-25T09:30:04.541115Z",
                  "updated_at": "2026-03-25T10:29:35.330503Z",
                  "is_trial_number": false,
                  "last_billing_date": "2026-03-25T10:25:30.672202Z",
                  "next_billing_date": "2026-04-25T10:25:30.672202Z",
                  "minimum_commitment_months": 0,
                  "aadhaar_verification_required": false,
                  "aadhaar_verified": false,
                  "source": "purchased",
                  "released_at": "released_at",
                  "trunk_group_id": "trunk_group_id"
                }
              ],
              "page": 1,
              "per_page": 25,
              "total": 24
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/numbers")
                    .WithParam("search", "+919876543210")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.ListNumbersAsync(
            new ListNumbersRequest { AuthId = "MA_XXXXXX", Search = "+919876543210" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
