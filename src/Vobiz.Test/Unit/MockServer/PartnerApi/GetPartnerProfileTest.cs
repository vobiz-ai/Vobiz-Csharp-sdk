using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPartnerProfileTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
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
              "balance": "balance",
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/partner/me").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.GetPartnerProfileAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "id",
              "account_id": 1,
              "name": "Acme Reseller",
              "slug": "slug",
              "company": "company",
              "auth_id": "PA_ABC123",
              "email": "partner@acme.com",
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
              "balance": "balance",
              "created_at": "2025-01-15T10:00:00Z",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/partner/me").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.GetPartnerProfileAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
