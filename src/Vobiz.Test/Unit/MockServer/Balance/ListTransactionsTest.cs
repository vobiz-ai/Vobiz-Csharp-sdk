using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Balance;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTransactionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "transactions": [
                {
                  "id": "id",
                  "account_id": "account_id",
                  "balance_id": "balance_id",
                  "type": "type",
                  "amount": 1.1,
                  "currency": "currency",
                  "description": "description",
                  "reference": "reference",
                  "reference_type": "reference_type",
                  "status": "status",
                  "processed_at": "processed_at",
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                },
                {
                  "id": "id",
                  "account_id": "account_id",
                  "balance_id": "balance_id",
                  "type": "type",
                  "amount": 1.1,
                  "currency": "currency",
                  "description": "description",
                  "reference": "reference",
                  "reference_type": "reference_type",
                  "status": "status",
                  "processed_at": "processed_at",
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                }
              ],
              "summary": {
                "total_transactions": 1,
                "total_debit": 1.1,
                "total_credit": 1,
                "net_amount": 1.1,
                "by_reference_type": [
                  {
                    "reference_type": "reference_type",
                    "total_debit": 1.1,
                    "total_credit": 1,
                    "count": 1
                  },
                  {
                    "reference_type": "reference_type",
                    "total_debit": 1.1,
                    "total_credit": 1,
                    "count": 1
                  }
                ]
              },
              "total": 1,
              "page": 1,
              "per_page": 1,
              "total_pages": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/transactions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Balance.ListTransactionsAsync(
            new ListTransactionsRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "transactions": [
                {
                  "id": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "balance_id": "11223344-5566-7788-99aa-bbccddeeff00",
                  "type": "debit",
                  "amount": 0.08,
                  "currency": "INR",
                  "description": "Call to 919876543210 (1s)",
                  "reference": "cdr:99887766-aabb-ccdd-eeff-001122334455",
                  "reference_type": "cdr",
                  "status": "completed",
                  "processed_at": "2026-05-11T06:59:32.806790Z",
                  "created_at": "2026-05-11T06:59:32.806790Z",
                  "updated_at": "2026-05-11T06:59:32.806790Z"
                }
              ],
              "summary": {
                "total_transactions": 5657,
                "total_debit": 138901.97,
                "total_credit": 350806,
                "net_amount": 211904.03,
                "by_reference_type": [
                  {
                    "reference_type": "cdr",
                    "total_debit": 932.93,
                    "total_credit": 0,
                    "count": 1866
                  },
                  {
                    "reference_type": "did_rental",
                    "total_debit": 18100,
                    "total_credit": 0,
                    "count": 44
                  },
                  {
                    "reference_type": "manual_adjustment",
                    "total_debit": 0,
                    "total_credit": 2455,
                    "count": 6
                  }
                ]
              },
              "total": 5657,
              "page": 1,
              "per_page": 50,
              "total_pages": 114
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/transactions")
                    .WithParam("from_date", "2026-08-25")
                    .WithParam("to_date", "2026-08-25")
                    .WithParam("type", "debit")
                    .WithParam("currency", "INR")
                    .WithParam("reference_type", "cdr")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Balance.ListTransactionsAsync(
            new ListTransactionsRequest
            {
                AuthId = "MA_XXXXXX",
                FromDate = "2026-08-25",
                ToDate = "2026-08-25",
                Type = "debit",
                Currency = "INR",
                ReferenceType = "cdr",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
