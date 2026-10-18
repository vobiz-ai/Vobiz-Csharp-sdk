using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Numbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PurchaseNumberTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "e164": "e164",
              "country": "country"
            }
            """;

        const string mockResponse = """
            {
              "purchase": {
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
              "number": {
                "id": 1,
                "e164": "e164",
                "provider": "provider",
                "channelCapabilities": [
                  "channelCapabilities",
                  "channelCapabilities"
                ],
                "accountId": "accountId",
                "countryCode": "countryCode",
                "createdAt": "2024-01-15T09:30:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/purchase")
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

        var response = await Client.Sms.Numbers.PurchaseNumberAsync(
            new PurchaseNumberRequest
            {
                E164 = "e164",
                Country = "country",
                NumberKey = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "e164": "+14155550100",
              "country": "US"
            }
            """;

        const string mockResponse = """
            {
              "purchase": {
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
              },
              "number": {
                "id": 1042,
                "e164": "+14155550100",
                "provider": "internal",
                "channelCapabilities": [
                  "sms",
                  "mms"
                ],
                "accountId": "MA_XXXXXXXX",
                "countryCode": "US",
                "createdAt": "2026-10-12T09:06:44.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/purchase")
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

        var response = await Client.Sms.Numbers.PurchaseNumberAsync(
            new PurchaseNumberRequest { E164 = "+14155550100", Country = "US" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "e164": "+442079460100",
              "country": "GB",
              "numberKey": "YOUR_NUMBER_KEY"
            }
            """;

        const string mockResponse = """
            {
              "purchase": {
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
              },
              "number": {
                "id": 1042,
                "e164": "+14155550100",
                "provider": "internal",
                "channelCapabilities": [
                  "sms",
                  "mms"
                ],
                "accountId": "MA_XXXXXXXX",
                "countryCode": "US",
                "createdAt": "2026-10-12T09:06:44.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/purchase")
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

        var response = await Client.Sms.Numbers.PurchaseNumberAsync(
            new PurchaseNumberRequest
            {
                E164 = "+442079460100",
                Country = "GB",
                NumberKey = "YOUR_NUMBER_KEY",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
