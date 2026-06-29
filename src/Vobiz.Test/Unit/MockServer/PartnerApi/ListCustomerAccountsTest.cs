using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCustomerAccountsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "accounts": [
                {
                  "name": "name",
                  "email": "email",
                  "phone": "phone",
                  "description": "description",
                  "gstin": "gstin",
                  "gst_status": "gst_status",
                  "tds_enabled": true,
                  "tds_percentage": 1,
                  "business_type": "business_type",
                  "id": "id",
                  "auth_id": "auth_id",
                  "api_id": "api_id",
                  "account_type": "account_type",
                  "role": "role",
                  "postpaid": true,
                  "address": "address",
                  "city": "city",
                  "state": "state",
                  "timezone": "timezone",
                  "country": "country",
                  "zip_code": "zip_code",
                  "company": "company",
                  "billing_mode": "billing_mode",
                  "auto_recharge": true,
                  "cash_credits": "cash_credits",
                  "cps_limit": 1,
                  "concurrent_calls_limit": 1,
                  "base_cps_limit": {
                    "key": "value"
                  },
                  "base_concurrent_calls_limit": {
                    "key": "value"
                  },
                  "purchased_cps": {
                    "key": "value"
                  },
                  "purchased_concurrent_calls": {
                    "key": "value"
                  },
                  "is_active": true,
                  "is_verified": true,
                  "is_trial_account": true,
                  "enabled": true,
                  "kyc_status": "kyc_status",
                  "google_id": {
                    "key": "value"
                  },
                  "referral_code": "referral_code",
                  "referral_disabled": true,
                  "custom_referrer_reward_amount": {
                    "key": "value"
                  },
                  "custom_referee_reward_amount": {
                    "key": "value"
                  },
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "last_login": "last_login",
                  "pricing_tier_id": "pricing_tier_id",
                  "pricing_tier": {
                    "id": "id",
                    "name": "name",
                    "currency": "currency",
                    "rate_per_minute": 1.1,
                    "streaming_rate_per_minute": 1.1,
                    "recording_rate_per_minute": 1.1,
                    "whatsapp_voice_rate": 1.1,
                    "transcription_rate_per_minute": 1.1,
                    "pii_redaction_rate_per_minute": 1.1,
                    "charge_non_connected_calls": true,
                    "non_connected_call_fee": 1.1,
                    "did_release_fee": 1,
                    "is_active": true,
                    "is_default": true,
                    "partner_id": {
                      "key": "value"
                    }
                  },
                  "partner_id": "partner_id",
                  "auto_recharge_config": {
                    "key": "value"
                  },
                  "resource_uri": "resource_uri",
                  "auth_token": "auth_token"
                },
                {
                  "name": "name",
                  "email": "email",
                  "phone": "phone",
                  "description": "description",
                  "gstin": "gstin",
                  "gst_status": "gst_status",
                  "tds_enabled": true,
                  "tds_percentage": 1,
                  "business_type": "business_type",
                  "id": "id",
                  "auth_id": "auth_id",
                  "api_id": "api_id",
                  "account_type": "account_type",
                  "role": "role",
                  "postpaid": true,
                  "address": "address",
                  "city": "city",
                  "state": "state",
                  "timezone": "timezone",
                  "country": "country",
                  "zip_code": "zip_code",
                  "company": "company",
                  "billing_mode": "billing_mode",
                  "auto_recharge": true,
                  "cash_credits": "cash_credits",
                  "cps_limit": 1,
                  "concurrent_calls_limit": 1,
                  "base_cps_limit": {
                    "key": "value"
                  },
                  "base_concurrent_calls_limit": {
                    "key": "value"
                  },
                  "purchased_cps": {
                    "key": "value"
                  },
                  "purchased_concurrent_calls": {
                    "key": "value"
                  },
                  "is_active": true,
                  "is_verified": true,
                  "is_trial_account": true,
                  "enabled": true,
                  "kyc_status": "kyc_status",
                  "google_id": {
                    "key": "value"
                  },
                  "referral_code": "referral_code",
                  "referral_disabled": true,
                  "custom_referrer_reward_amount": {
                    "key": "value"
                  },
                  "custom_referee_reward_amount": {
                    "key": "value"
                  },
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "last_login": "last_login",
                  "pricing_tier_id": "pricing_tier_id",
                  "pricing_tier": {
                    "id": "id",
                    "name": "name",
                    "currency": "currency",
                    "rate_per_minute": 1.1,
                    "streaming_rate_per_minute": 1.1,
                    "recording_rate_per_minute": 1.1,
                    "whatsapp_voice_rate": 1.1,
                    "transcription_rate_per_minute": 1.1,
                    "pii_redaction_rate_per_minute": 1.1,
                    "charge_non_connected_calls": true,
                    "non_connected_call_fee": 1.1,
                    "did_release_fee": 1,
                    "is_active": true,
                    "is_default": true,
                    "partner_id": {
                      "key": "value"
                    }
                  },
                  "partner_id": "partner_id",
                  "auto_recharge_config": {
                    "key": "value"
                  },
                  "resource_uri": "resource_uri",
                  "auth_token": "auth_token"
                }
              ],
              "total": 1,
              "page": 1,
              "size": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerAccountsAsync(
            new ListCustomerAccountsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "accounts": [
                {
                  "name": "Acme Corp",
                  "email": "admin@acme-corp.com",
                  "phone": "+919876543210",
                  "tds_enabled": false,
                  "tds_percentage": 2,
                  "business_type": "individual",
                  "id": "500000",
                  "auth_id": "MA_XXXXXXXX",
                  "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "account_type": "standard",
                  "role": "user",
                  "postpaid": false,
                  "address": "221B Baker Street",
                  "city": "Mumbai",
                  "timezone": "Asia/Kolkata",
                  "country": "IN",
                  "zip_code": "400001",
                  "company": "Acme Corp",
                  "billing_mode": "prepaid",
                  "auto_recharge": false,
                  "cash_credits": "1300.00000",
                  "cps_limit": 1,
                  "concurrent_calls_limit": 4,
                  "is_active": true,
                  "is_verified": false,
                  "is_trial_account": false,
                  "enabled": true,
                  "kyc_status": "pending",
                  "referral_disabled": false,
                  "created_at": "2026-03-25T10:00:00Z",
                  "updated_at": "2026-03-26T11:54:13Z",
                  "last_login": "2026-03-25T10:16:47Z",
                  "pricing_tier_id": "11223344-1234-5678-90ab-cdef12345678",
                  "pricing_tier": {
                    "id": "11223344-1234-5678-90ab-cdef12345678",
                    "name": "Standard",
                    "currency": "INR",
                    "rate_per_minute": 0.45,
                    "streaming_rate_per_minute": 0.2,
                    "recording_rate_per_minute": 0.1,
                    "whatsapp_voice_rate": 0.45,
                    "transcription_rate_per_minute": 0.1,
                    "pii_redaction_rate_per_minute": 0.3,
                    "charge_non_connected_calls": true,
                    "non_connected_call_fee": 0.02,
                    "did_release_fee": 700,
                    "is_active": true,
                    "is_default": false
                  },
                  "partner_id": "99887766-1234-5678-90ab-cdef12345678",
                  "resource_uri": "/v1/Account/MA_XXXXXXXX/",
                  "auth_token": "<redacted>"
                },
                {
                  "name": "John Doe",
                  "email": "john@example.com",
                  "phone": "+918012345678",
                  "tds_enabled": false,
                  "tds_percentage": 2,
                  "business_type": "individual",
                  "id": "500001",
                  "auth_id": "MA_YYYYYYYY",
                  "api_id": "55667788-1234-5678-90ab-cdef12345678",
                  "account_type": "standard",
                  "role": "user",
                  "postpaid": false,
                  "country": "IN",
                  "company": "Acme Corp",
                  "billing_mode": "prepaid",
                  "auto_recharge": false,
                  "cash_credits": "1107.00000",
                  "cps_limit": 1,
                  "concurrent_calls_limit": 3,
                  "is_active": true,
                  "is_verified": false,
                  "is_trial_account": false,
                  "enabled": true,
                  "kyc_status": "pending",
                  "referral_disabled": false,
                  "created_at": "2026-03-20T05:58:46Z",
                  "updated_at": "2026-03-21T05:13:16Z",
                  "pricing_tier_id": "11223344-1234-5678-90ab-cdef12345678",
                  "pricing_tier": {
                    "id": "11223344-1234-5678-90ab-cdef12345678",
                    "name": "Standard",
                    "currency": "INR",
                    "rate_per_minute": 0.45,
                    "streaming_rate_per_minute": 0.2,
                    "recording_rate_per_minute": 0.1,
                    "whatsapp_voice_rate": 0.45,
                    "transcription_rate_per_minute": 0.1,
                    "pii_redaction_rate_per_minute": 0.3,
                    "charge_non_connected_calls": true,
                    "non_connected_call_fee": 0.02,
                    "did_release_fee": 700,
                    "is_active": true,
                    "is_default": false
                  },
                  "partner_id": "99887766-1234-5678-90ab-cdef12345678",
                  "resource_uri": "/v1/Account/MA_YYYYYYYY/",
                  "auth_token": "<redacted>"
                }
              ],
              "total": 2,
              "page": 1,
              "size": 20
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerAccountsAsync(
            new ListCustomerAccountsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
