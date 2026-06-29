using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCustomerTransactionsTest : BaseMockServerTest
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
                  "amount": 1,
                  "currency": "currency",
                  "description": "description",
                  "reference": "reference",
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
                  "amount": 1,
                  "currency": "currency",
                  "description": "description",
                  "reference": "reference",
                  "status": "status",
                  "processed_at": "processed_at",
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                }
              ],
              "summary": {
                "total_transactions": 1,
                "total_debit": 1,
                "total_credit": 1,
                "net_amount": 1,
                "by_reference_type": [
                  {
                    "reference_type": "reference_type",
                    "total_debit": 1,
                    "total_credit": 1,
                    "count": 1
                  },
                  {
                    "reference_type": "reference_type",
                    "total_debit": 1,
                    "total_credit": 1,
                    "count": 1
                  }
                ]
              },
              "total": 1,
              "page": 1,
              "per_page": 1,
              "total_pages": 1,
              "account_auth_id": "account_auth_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/transactions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerTransactionsAsync(
            new ListCustomerTransactionsRequest { CustomerAuthId = "customer_auth_id" }
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
                  "balance_id": "11223344-1234-5678-90ab-cdef12345678",
                  "type": "credit",
                  "amount": 200,
                  "currency": "INR",
                  "description": "Transfer from partner Acme: Balance transfer",
                  "reference": "ptc:99887766-1234-5678-90ab-cdef12345678:MA_XXXXXXXX:1778140310",
                  "status": "completed",
                  "processed_at": "2026-03-25T10:00:00Z",
                  "created_at": "2026-03-25T10:00:00Z",
                  "updated_at": "2026-03-25T10:00:00Z"
                },
                {
                  "id": "55667788-1234-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "balance_id": "11223344-1234-5678-90ab-cdef12345678",
                  "type": "credit",
                  "amount": 100,
                  "currency": "INR",
                  "description": "Transfer from partner Acme: Balance transfer",
                  "reference": "ptc:99887766-1234-5678-90ab-cdef12345678:MA_XXXXXXXX:1778051898",
                  "status": "completed",
                  "processed_at": "2026-03-24T07:18:18Z",
                  "created_at": "2026-03-24T07:18:18Z",
                  "updated_at": "2026-03-24T07:18:18Z"
                },
                {
                  "id": "aabbccdd-9999-5678-90ab-cdef12345678",
                  "account_id": "MA_XXXXXXXX",
                  "balance_id": "11223344-1234-5678-90ab-cdef12345678",
                  "type": "credit",
                  "amount": 1000,
                  "currency": "INR",
                  "description": "Transfer from partner Acme: Balance transfer",
                  "reference": "ptc:99887766-1234-5678-90ab-cdef12345678:MA_XXXXXXXX:1778051770",
                  "status": "completed",
                  "processed_at": "2026-03-24T07:16:10Z",
                  "created_at": "2026-03-24T07:16:10Z",
                  "updated_at": "2026-03-24T07:16:10Z"
                }
              ],
              "summary": {
                "total_transactions": 3,
                "total_debit": 0,
                "total_credit": 1300,
                "net_amount": 1300,
                "by_reference_type": [
                  {
                    "reference_type": "unknown",
                    "total_debit": 0,
                    "total_credit": 1300,
                    "count": 3
                  }
                ]
              },
              "total": 3,
              "page": 1,
              "per_page": 20,
              "total_pages": 1,
              "account_auth_id": "MA_XXXXXXXX"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/transactions")
                    .WithParam("from_date", "2026-03-01")
                    .WithParam("to_date", "2026-03-31")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerTransactionsAsync(
            new ListCustomerTransactionsRequest
            {
                CustomerAuthId = "customer_auth_id",
                FromDate = new DateOnly(2026, 3, 1),
                ToDate = new DateOnly(2026, 3, 31),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
