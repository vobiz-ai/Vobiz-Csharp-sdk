using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Numbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPurchasesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "purchases": [
                {
                  "id": "id",
                  "accountId": "accountId",
                  "provider": "provider",
                  "e164": "e164",
                  "countryCode": "countryCode",
                  "type": "type",
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ],
                  "setupAmount": 1.1,
                  "monthlyAmount": 1.1,
                  "currency": "currency",
                  "status": "pending",
                  "purchasedAt": "2024-01-15T09:30:00.000Z",
                  "nextBillingAt": "2024-01-15T09:30:00.000Z",
                  "releasedAt": "2024-01-15T09:30:00.000Z",
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "updatedAt": "2024-01-15T09:30:00.000Z",
                  "charges": [
                    {
                      "purchaseId": "purchaseId",
                      "kind": "purchase",
                      "periodStart": "2024-01-15T09:30:00.000Z",
                      "amount": 1.1,
                      "currency": "currency",
                      "status": "pending",
                      "reference": "reference",
                      "attempts": 1,
                      "attemptedAt": "2024-01-15T09:30:00.000Z"
                    },
                    {
                      "purchaseId": "purchaseId",
                      "kind": "purchase",
                      "periodStart": "2024-01-15T09:30:00.000Z",
                      "amount": 1.1,
                      "currency": "currency",
                      "status": "pending",
                      "reference": "reference",
                      "attempts": 1,
                      "attemptedAt": "2024-01-15T09:30:00.000Z"
                    }
                  ]
                },
                {
                  "id": "id",
                  "accountId": "accountId",
                  "provider": "provider",
                  "e164": "e164",
                  "countryCode": "countryCode",
                  "type": "type",
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ],
                  "setupAmount": 1.1,
                  "monthlyAmount": 1.1,
                  "currency": "currency",
                  "status": "pending",
                  "purchasedAt": "2024-01-15T09:30:00.000Z",
                  "nextBillingAt": "2024-01-15T09:30:00.000Z",
                  "releasedAt": "2024-01-15T09:30:00.000Z",
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "updatedAt": "2024-01-15T09:30:00.000Z",
                  "charges": [
                    {
                      "purchaseId": "purchaseId",
                      "kind": "purchase",
                      "periodStart": "2024-01-15T09:30:00.000Z",
                      "amount": 1.1,
                      "currency": "currency",
                      "status": "pending",
                      "reference": "reference",
                      "attempts": 1,
                      "attemptedAt": "2024-01-15T09:30:00.000Z"
                    },
                    {
                      "purchaseId": "purchaseId",
                      "kind": "purchase",
                      "periodStart": "2024-01-15T09:30:00.000Z",
                      "amount": 1.1,
                      "currency": "currency",
                      "status": "pending",
                      "reference": "reference",
                      "attempts": 1,
                      "attemptedAt": "2024-01-15T09:30:00.000Z"
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/purchases")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListPurchasesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "purchases": [
                {
                  "id": "5c2d9e7a-1b4f-4a8c-9e3d-6f7a0b1c2d3e",
                  "accountId": "MA_XXXXXXXX",
                  "provider": "internal",
                  "e164": "+14155550100",
                  "countryCode": "US",
                  "type": "VIRTUAL_LONG_NUMBER",
                  "capabilities": [
                    "VOICE",
                    "SMS",
                    "MMS"
                  ],
                  "setupAmount": 1,
                  "monthlyAmount": 1,
                  "currency": "USD",
                  "status": "purchased",
                  "purchasedAt": "2026-10-12T09:06:44.000Z",
                  "nextBillingAt": "2026-11-12T09:06:44.000Z",
                  "createdAt": "2026-10-12T09:06:42.000Z",
                  "updatedAt": "2026-10-12T09:06:44.000Z",
                  "charges": [
                    {
                      "purchaseId": "5c2d9e7a-1b4f-4a8c-9e3d-6f7a0b1c2d3e",
                      "kind": "purchase",
                      "periodStart": "2026-10-12T09:06:42.000Z",
                      "amount": 2,
                      "currency": "USD",
                      "status": "paid",
                      "reference": "sms_number_purchase:5c2d9e7a-1b4f-4a8c-9e3d-6f7a0b1c2d3e",
                      "attempts": 1,
                      "attemptedAt": "2026-10-12T09:06:42.000Z"
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/purchases")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListPurchasesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
