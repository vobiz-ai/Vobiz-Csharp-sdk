using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCustomerNumbersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "key": "value"
                },
                {
                  "key": "value"
                }
              ],
              "page": 1,
              "per_page": 1,
              "total": 1,
              "account_auth_id": "account_auth_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/numbers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerNumbersAsync(
            new ListCustomerNumbersRequest { CustomerAuthId = "customer_auth_id" }
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
                  "e164": "+918012345678",
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
                  "purchased_at": "2026-03-25T06:58:38Z",
                  "is_blocked": false,
                  "created_at": "2025-03-31T18:30:00Z",
                  "updated_at": "2026-03-25T06:58:54Z",
                  "is_trial_number": false,
                  "last_billing_date": "2026-03-25T06:58:38Z",
                  "next_billing_date": "2026-04-25T06:58:38Z",
                  "minimum_commitment_months": 0,
                  "aadhaar_verification_required": false,
                  "aadhaar_verified": false,
                  "source": "purchased"
                },
                {
                  "id": "11223344-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "e164": "+919876543210",
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
                  "purchased_at": "2026-02-17T10:25:30Z",
                  "is_blocked": false,
                  "created_at": "2026-02-14T09:30:04Z",
                  "updated_at": "2026-02-17T10:29:35Z",
                  "is_trial_number": false,
                  "last_billing_date": "2026-02-17T10:25:30Z",
                  "next_billing_date": "2026-03-17T10:25:30Z",
                  "minimum_commitment_months": 0,
                  "aadhaar_verification_required": false,
                  "aadhaar_verified": false,
                  "source": "purchased"
                }
              ],
              "page": 1,
              "per_page": 20,
              "total": 2,
              "account_auth_id": "MA_XXXXXXXX"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/numbers")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerNumbersAsync(
            new ListCustomerNumbersRequest { CustomerAuthId = "customer_auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
