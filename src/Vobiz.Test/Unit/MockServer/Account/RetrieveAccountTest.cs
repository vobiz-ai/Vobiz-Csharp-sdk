using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Account;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RetrieveAccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "type": "type",
              "id": "id",
              "api_id": "api_id",
              "name": "name",
              "email": "email",
              "phone": "phone",
              "description": "description",
              "auth_id": "auth_id",
              "auth_secret": "auth_secret",
              "auth_token_expire_time": {
                "key": "value"
              },
              "country": "country",
              "timezone": "timezone",
              "city": "city",
              "state": "state",
              "address": "address",
              "zip_code": "zip_code",
              "company": "company",
              "account_type": "account_type",
              "postpaid": true,
              "auto_recharge": true,
              "auto_recharge_config": {
                "key": "value"
              },
              "enabled": true,
              "carrier_type": {
                "key": "value"
              },
              "customer_type": {
                "key": "value"
              },
              "credit_limit": 1,
              "cps_limit": 1,
              "concurrent_calls_limit": 1,
              "base_cps_limit": 1,
              "base_concurrent_calls_limit": 1,
              "purchased_cps": 1,
              "purchased_concurrent_calls": 1,
              "risk_rating": 1,
              "risk_status": {
                "key": "value"
              },
              "features": {
                "call_queue": true
              },
              "ip_auth_enabled": true,
              "ip_whitelist_rules": {
                "ip_whitelist_rules": {
                  "key": "value"
                }
              },
              "allow_aws_ips": true,
              "role": "role",
              "is_active": true,
              "is_verified": true,
              "is_trial_account": true,
              "created_at": "created_at",
              "updated_at": "updated_at",
              "last_login": "last_login",
              "pricing_tier_id": "pricing_tier_id",
              "pricing_tier": {
                "id": "id",
                "name": "name",
                "description": "description",
                "currency": "currency",
                "rate_per_minute": 1.1,
                "billing_increment_seconds": 1,
                "minimum_duration_seconds": 1,
                "is_active": true,
                "is_default": true
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/auth/me").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Account.RetrieveAccountAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "type": "account",
              "id": "500000",
              "api_id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "name": "Acme Corp",
              "email": "admin@example.com",
              "phone": "+919876543210",
              "description": "description",
              "auth_id": "MA_XXXXXXXX",
              "auth_secret": "<redacted>",
              "country": "IN",
              "timezone": "Asia/Kolkata",
              "city": "Bengaluru",
              "state": "KA",
              "address": "123 Example Street, Bengaluru",
              "zip_code": "560001",
              "company": "Acme Corp",
              "account_type": "standard",
              "postpaid": false,
              "auto_recharge": true,
              "enabled": true,
              "credit_limit": 0,
              "cps_limit": 11,
              "concurrent_calls_limit": 10,
              "base_cps_limit": 1,
              "base_concurrent_calls_limit": 10,
              "purchased_cps": 10,
              "purchased_concurrent_calls": 0,
              "risk_rating": 0,
              "features": {
                "call_queue": true
              },
              "ip_auth_enabled": false,
              "ip_whitelist_rules": {
                "key": "value"
              },
              "allow_aws_ips": false,
              "role": "admin",
              "is_active": true,
              "is_verified": false,
              "is_trial_account": false,
              "created_at": "2025-09-30T08:33:24.700542+00:00",
              "updated_at": "2026-05-12T05:41:41.892287+00:00",
              "last_login": "2026-05-12T05:41:42.601005+00:00",
              "pricing_tier_id": "11223344-5566-7788-99aa-bbccddeeff00",
              "pricing_tier": {
                "id": "11223344-5566-7788-99aa-bbccddeeff00",
                "name": "Standard",
                "description": "description",
                "currency": "INR",
                "rate_per_minute": 0.45,
                "billing_increment_seconds": 60,
                "minimum_duration_seconds": 0,
                "is_active": true,
                "is_default": false
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/auth/me").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Account.RetrieveAccountAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
