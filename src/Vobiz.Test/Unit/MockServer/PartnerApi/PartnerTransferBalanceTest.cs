using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PartnerTransferBalanceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "amount": 1.1,
              "currency": "currency"
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
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/transfer-balance")
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

        var response = await Client.PartnerApi.PartnerTransferBalanceAsync(
            new PartnerTransferBalanceRequest
            {
                CustomerAuthId = "customer_auth_id",
                Amount = 1.1,
                Currency = "currency",
                Description = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "amount": 500,
              "currency": "INR"
            }
            """;

        const string mockResponse = """
            {
              "transaction_id": "txn_aabbccdd1234",
              "from_account": "PA_XXXXXXXX",
              "to_account": "MA_XXXXXXXX",
              "amount": 500,
              "currency": "INR",
              "description": "April recharge",
              "status": "completed",
              "partner_balance_after": 47750,
              "customer_balance_after": 2950,
              "timestamp": "2026-03-25T11:00:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/MA_ZKITB8Z2/transfer-balance")
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

        var response = await Client.PartnerApi.PartnerTransferBalanceAsync(
            new PartnerTransferBalanceRequest
            {
                CustomerAuthId = "MA_ZKITB8Z2",
                Amount = 500,
                Currency = "INR",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
