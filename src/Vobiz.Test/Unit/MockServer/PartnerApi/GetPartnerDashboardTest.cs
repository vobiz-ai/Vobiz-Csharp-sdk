using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPartnerDashboardTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "partner": {
                "id": "id",
                "account_id": 1,
                "name": "name",
                "slug": "slug",
                "company": "company",
                "auth_id": "auth_id",
                "email": "email",
                "phone": "phone",
                "billing_model": "billing_model",
                "is_active": true,
                "is_verified": true,
                "max_accounts": 1,
                "can_create_accounts": true,
                "can_create_pricing_tiers": true,
                "can_view_cdrs": true,
                "can_transfer_balance": true,
                "default_pricing_tier_id": "default_pricing_tier_id",
                "account_count": 1,
                "balance": {
                  "key": "value"
                },
                "created_at": "created_at",
                "updated_at": "updated_at"
              },
              "period": {
                "from": "from",
                "to": "to"
              },
              "accounts": {
                "total": 1,
                "active": 1,
                "customers": [
                  {
                    "auth_id": "auth_id",
                    "name": "name",
                    "email": "email",
                    "phone": "phone",
                    "is_active": true,
                    "created_at": "created_at"
                  },
                  {
                    "auth_id": "auth_id",
                    "name": "name",
                    "email": "email",
                    "phone": "phone",
                    "is_active": true,
                    "created_at": "created_at"
                  }
                ]
              },
              "total_balance": "total_balance",
              "currency": "currency",
              "calls": {
                "total_calls": 1,
                "answered_calls": 1,
                "total_minutes": 1.1,
                "total_cost": "total_cost"
              },
              "traffic": {
                "inbound": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost"
                },
                "outbound": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost"
                }
              },
              "by_product": {
                "sip_trunking": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1,
                  "total_cost": "total_cost"
                },
                "voice_api": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost"
                }
              },
              "time_series": [
                {
                  "date": "date",
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost",
                  "inbound": {
                    "total_calls": 1,
                    "answered_calls": 1,
                    "total_minutes": 1.1
                  },
                  "outbound": {
                    "total_calls": 1,
                    "answered_calls": 1,
                    "total_minutes": 1.1
                  }
                },
                {
                  "date": "date",
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost",
                  "inbound": {
                    "total_calls": 1,
                    "answered_calls": 1,
                    "total_minutes": 1.1
                  },
                  "outbound": {
                    "total_calls": 1,
                    "answered_calls": 1,
                    "total_minutes": 1.1
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/dashboard")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.GetPartnerDashboardAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "partner": {
                "id": "id",
                "account_id": 1,
                "name": "name",
                "slug": "slug",
                "company": "company",
                "auth_id": "auth_id",
                "email": "email",
                "phone": "phone",
                "billing_model": "billing_model",
                "is_active": true,
                "is_verified": true,
                "max_accounts": 1,
                "can_create_accounts": true,
                "can_create_pricing_tiers": true,
                "can_view_cdrs": true,
                "can_transfer_balance": true,
                "default_pricing_tier_id": "default_pricing_tier_id",
                "account_count": 1,
                "balance": {
                  "key": "value"
                },
                "created_at": "created_at",
                "updated_at": "updated_at"
              },
              "period": {
                "from": "from",
                "to": "to"
              },
              "accounts": {
                "total": 1,
                "active": 1,
                "customers": [
                  {
                    "auth_id": "auth_id",
                    "name": "name",
                    "email": "email",
                    "phone": "phone",
                    "is_active": true,
                    "created_at": "created_at"
                  }
                ]
              },
              "total_balance": "total_balance",
              "currency": "INR",
              "calls": {
                "total_calls": 1,
                "answered_calls": 1,
                "total_minutes": 1.1,
                "total_cost": "total_cost"
              },
              "traffic": {
                "inbound": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost"
                },
                "outbound": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost"
                }
              },
              "by_product": {
                "sip_trunking": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1,
                  "total_cost": "total_cost"
                },
                "voice_api": {
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost"
                }
              },
              "time_series": [
                {
                  "date": "date",
                  "total_calls": 1,
                  "answered_calls": 1,
                  "total_minutes": 1.1,
                  "total_cost": "total_cost",
                  "inbound": {
                    "total_calls": 1,
                    "answered_calls": 1,
                    "total_minutes": 1.1
                  },
                  "outbound": {
                    "total_calls": 1,
                    "answered_calls": 1,
                    "total_minutes": 1.1
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/dashboard")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.GetPartnerDashboardAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
