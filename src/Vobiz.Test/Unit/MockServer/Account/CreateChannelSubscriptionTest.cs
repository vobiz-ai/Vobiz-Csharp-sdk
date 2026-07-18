using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Account;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateChannelSubscriptionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "resource_type": "concurrent_calls",
              "quantity": 10000
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "account_id": 1,
              "resource_type": "concurrent_calls",
              "quantity": 10000,
              "monthly_cost": "monthly_cost",
              "currency": "currency",
              "status": "status",
              "last_billing_date": "2024-01-15T09:30:00.000Z",
              "next_billing_date": "2024-01-15T09:30:00.000Z",
              "purchased_at": "2024-01-15T09:30:00.000Z",
              "cancelled_at": "2024-01-15T09:30:00.000Z",
              "cancellation_reason": "cancellation_reason",
              "is_active": true,
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/auth_id/channel-subscriptions")
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

        var response = await Client.Account.CreateChannelSubscriptionAsync(
            new ChannelSubscriptionRequest
            {
                AuthId = "auth_id",
                ResourceType = CapacityResourceType.ConcurrentCalls,
                Quantity = 10000,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "resource_type": "concurrent_calls",
              "quantity": 30
            }
            """;

        const string mockResponse = """
            {
              "id": "5ed57f90-b1f1-4c32-9475-b85aa6739aec",
              "account_id": 123456,
              "resource_type": "concurrent_calls",
              "quantity": 30,
              "monthly_cost": "10470.00",
              "currency": "INR",
              "status": "active",
              "last_billing_date": "2026-07-16T10:00:00.000Z",
              "next_billing_date": "2026-08-15T10:00:00.000Z",
              "purchased_at": "2026-07-16T10:00:00.000Z",
              "is_active": true,
              "created_at": "2026-07-16T10:00:00.000Z",
              "updated_at": "2026-07-16T10:00:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/MA_XXXX/channel-subscriptions")
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

        var response = await Client.Account.CreateChannelSubscriptionAsync(
            new ChannelSubscriptionRequest
            {
                AuthId = "MA_XXXX",
                ResourceType = CapacityResourceType.ConcurrentCalls,
                Quantity = 30,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
