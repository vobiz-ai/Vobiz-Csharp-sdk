using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Balance;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetBalanceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "account_id": "account_id",
              "currency": "currency",
              "balance": 1.1,
              "reserved_funds": 1,
              "promotional_balance": 1,
              "promotional_reserved_balance": 1,
              "available_balance": 1.1,
              "credit_limit": 1,
              "is_postpaid": true,
              "credit_limit_type": "credit_limit_type",
              "low_balance_threshold": 1,
              "status": "status",
              "created_at": "created_at",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/balance/currency")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Balance.GetBalanceAsync(
            new GetBalanceRequest { AuthId = "auth_id", Currency = "currency" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "aabbccdd-1234-5678-90ab-cdef12345678",
              "account_id": "MA_XXXXXXXX",
              "currency": "INR",
              "balance": 23906.83,
              "reserved_funds": 0,
              "promotional_balance": 0,
              "promotional_reserved_balance": 0,
              "available_balance": 23906.83,
              "credit_limit": 1000,
              "is_postpaid": true,
              "credit_limit_type": "soft",
              "low_balance_threshold": 50,
              "status": "active",
              "created_at": "2026-01-19T18:39:15.050543Z",
              "updated_at": "2026-05-11T06:59:32.802705Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/balance/INR")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Balance.GetBalanceAsync(
            new GetBalanceRequest { AuthId = "MA_XXXXXX", Currency = "INR" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
