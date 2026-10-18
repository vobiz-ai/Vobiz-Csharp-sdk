using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Numbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListNumbersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "numbers": [
                {
                  "e164": "e164",
                  "provider": "provider",
                  "countryCode": "countryCode",
                  "channels": [
                    "sms",
                    "sms"
                  ],
                  "type": "type",
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ],
                  "tenDlc": {
                    "campaignId": "campaignId",
                    "campaignName": "campaignName",
                    "stage": "stage"
                  },
                  "tollFree": true,
                  "registration": {
                    "kind": "10dlc",
                    "status": "not_registered",
                    "campaignId": "campaignId",
                    "campaignName": "campaignName",
                    "stage": "stage"
                  },
                  "lastMessage": {
                    "status": "scheduled",
                    "errorCode": "errorCode",
                    "errorMessage": "errorMessage",
                    "to": "to",
                    "createdAt": "2024-01-15T09:30:00.000Z"
                  },
                  "sendable": {
                    "international": true,
                    "usDomestic": true
                  }
                },
                {
                  "e164": "e164",
                  "provider": "provider",
                  "countryCode": "countryCode",
                  "channels": [
                    "sms",
                    "sms"
                  ],
                  "type": "type",
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ],
                  "tenDlc": {
                    "campaignId": "campaignId",
                    "campaignName": "campaignName",
                    "stage": "stage"
                  },
                  "tollFree": true,
                  "registration": {
                    "kind": "10dlc",
                    "status": "not_registered",
                    "campaignId": "campaignId",
                    "campaignName": "campaignName",
                    "stage": "stage"
                  },
                  "lastMessage": {
                    "status": "scheduled",
                    "errorCode": "errorCode",
                    "errorMessage": "errorMessage",
                    "to": "to",
                    "createdAt": "2024-01-15T09:30:00.000Z"
                  },
                  "sendable": {
                    "international": true,
                    "usDomestic": true
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/sms/numbers").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListNumbersAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "numbers": [
                {
                  "e164": "+14155550100",
                  "provider": "internal",
                  "countryCode": "US",
                  "channels": [
                    "sms",
                    "mms"
                  ],
                  "type": "VIRTUAL_LONG_NUMBER",
                  "capabilities": [
                    "SMS",
                    "VOICE",
                    "MMS"
                  ],
                  "tenDlc": {
                    "campaignId": "3f1c7a2e-9d4b-4e8a-b6c5-2a7d9e1f0b43",
                    "campaignName": "Order notifications",
                    "stage": "REGISTERED"
                  },
                  "tollFree": false,
                  "registration": {
                    "kind": "10dlc",
                    "status": "approved",
                    "campaignId": "3f1c7a2e-9d4b-4e8a-b6c5-2a7d9e1f0b43",
                    "campaignName": "Order notifications",
                    "stage": "REGISTERED"
                  },
                  "lastMessage": {
                    "status": "delivered",
                    "errorCode": "",
                    "errorMessage": "",
                    "to": "+14155550123",
                    "createdAt": "2026-10-16T21:23:02.000Z"
                  },
                  "sendable": {
                    "international": true,
                    "usDomestic": true
                  }
                },
                {
                  "e164": "+14155550101",
                  "provider": "internal",
                  "countryCode": "US",
                  "channels": [
                    "sms",
                    "mms"
                  ],
                  "type": "VIRTUAL_LONG_NUMBER",
                  "capabilities": [
                    "SMS",
                    "VOICE",
                    "MMS"
                  ],
                  "tollFree": false,
                  "registration": {
                    "kind": "10dlc",
                    "status": "not_registered",
                    "campaignId": "",
                    "campaignName": "",
                    "stage": ""
                  },
                  "sendable": {
                    "international": true,
                    "usDomestic": false
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/sms/numbers").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListNumbersAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
