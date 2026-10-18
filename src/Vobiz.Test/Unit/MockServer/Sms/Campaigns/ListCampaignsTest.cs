using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCampaignsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "id": "id",
                "accountId": "accountId",
                "brandId": "brandId",
                "name": "name",
                "campaignType": "TEN_DIGIT_LONG_CODE",
                "stage": "stage",
                "programSummary": "programSummary",
                "confirmationMessage": "confirmationMessage",
                "helpMessage": "helpMessage",
                "stopMessage": "stopMessage",
                "customerCarePhone": "customerCarePhone",
                "customerCareEmail": "customerCareEmail",
                "exampleMessages": [
                  "exampleMessages",
                  "exampleMessages"
                ],
                "termsAndConditionsUrl": "termsAndConditionsUrl",
                "privacyPolicyUrl": "privacyPolicyUrl",
                "useCases": [
                  "useCases",
                  "useCases"
                ],
                "messageTypes": [
                  "messageTypes",
                  "messageTypes"
                ],
                "optIns": {
                  "optIns": {
                    "key": "value"
                  }
                },
                "lowVolume": true,
                "ageGated": true,
                "directLending": true,
                "embeddedLink": true,
                "embeddedPhone": true,
                "numbers": [
                  "numbers",
                  "numbers"
                ],
                "rejectionReasons": {
                  "rejectionReasons": {
                    "key": "value"
                  }
                },
                "lastSyncedAt": "2024-01-15T09:30:00.000Z",
                "createdAt": "2024-01-15T09:30:00.000Z",
                "updatedAt": "2024-01-15T09:30:00.000Z"
              },
              {
                "id": "id",
                "accountId": "accountId",
                "brandId": "brandId",
                "name": "name",
                "campaignType": "TEN_DIGIT_LONG_CODE",
                "stage": "stage",
                "programSummary": "programSummary",
                "confirmationMessage": "confirmationMessage",
                "helpMessage": "helpMessage",
                "stopMessage": "stopMessage",
                "customerCarePhone": "customerCarePhone",
                "customerCareEmail": "customerCareEmail",
                "exampleMessages": [
                  "exampleMessages",
                  "exampleMessages"
                ],
                "termsAndConditionsUrl": "termsAndConditionsUrl",
                "privacyPolicyUrl": "privacyPolicyUrl",
                "useCases": [
                  "useCases",
                  "useCases"
                ],
                "messageTypes": [
                  "messageTypes",
                  "messageTypes"
                ],
                "optIns": {
                  "optIns": {
                    "key": "value"
                  }
                },
                "lowVolume": true,
                "ageGated": true,
                "directLending": true,
                "embeddedLink": true,
                "embeddedPhone": true,
                "numbers": [
                  "numbers",
                  "numbers"
                ],
                "rejectionReasons": {
                  "rejectionReasons": {
                    "key": "value"
                  }
                },
                "lastSyncedAt": "2024-01-15T09:30:00.000Z",
                "createdAt": "2024-01-15T09:30:00.000Z",
                "updatedAt": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.ListCampaignsAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "id": "9c1b3e5f-7a2d-4b8c-a0e1-2f3d4c5b6a72",
                "accountId": "MA_XXXXXXXX",
                "brandId": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
                "name": "Example Corp toll-free notifications",
                "campaignType": "TOLL_FREE_UNIFIED_NUMBER",
                "stage": "IN_REVIEW",
                "programSummary": "Example Corp sends account and support notifications to customers who opted in on the contact form.",
                "confirmationMessage": "confirmationMessage",
                "helpMessage": "helpMessage",
                "stopMessage": "stopMessage",
                "customerCarePhone": "+14155550100",
                "customerCareEmail": "support@example.com",
                "exampleMessages": [
                  "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out, HELP for help."
                ],
                "termsAndConditionsUrl": "https://example.com/terms",
                "privacyPolicyUrl": "https://example.com/privacy",
                "useCases": [
                  "NOTIFICATIONS"
                ],
                "messageTypes": [
                  "SMS"
                ],
                "optIns": {
                  "web": {
                    "url": "https://example.com/contact",
                    "callToAction": "By checking this box you agree to receive account notifications from Example Corp. Reply STOP to opt out, HELP for help."
                  }
                },
                "lowVolume": false,
                "ageGated": false,
                "directLending": false,
                "embeddedLink": false,
                "embeddedPhone": false,
                "numbers": [
                  "+18335550100"
                ],
                "rejectionReasons": {
                  "key": "value"
                },
                "lastSyncedAt": "2026-10-17T08:46:46.000Z",
                "createdAt": "2026-10-08T04:36:40.000Z",
                "updatedAt": "2026-10-15T19:19:02.000Z"
              },
              {
                "id": "8a7d2f10-3c4b-4e9a-b1d2-6e5f4a3b2c11",
                "accountId": "MA_XXXXXXXX",
                "brandId": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
                "name": "Example Corp account alerts",
                "campaignType": "TEN_DIGIT_LONG_CODE",
                "stage": "REGISTERED",
                "programSummary": "programSummary",
                "confirmationMessage": "confirmationMessage",
                "helpMessage": "helpMessage",
                "stopMessage": "stopMessage",
                "customerCarePhone": "+14155550100",
                "customerCareEmail": "support@example.com",
                "exampleMessages": [
                  "exampleMessages"
                ],
                "termsAndConditionsUrl": "termsAndConditionsUrl",
                "privacyPolicyUrl": "privacyPolicyUrl",
                "useCases": [
                  "ALERTS"
                ],
                "messageTypes": [
                  "SMS"
                ],
                "optIns": {
                  "key": "value"
                },
                "lowVolume": true,
                "ageGated": false,
                "directLending": false,
                "embeddedLink": true,
                "embeddedPhone": false,
                "numbers": [
                  "14155550100"
                ],
                "rejectionReasons": {
                  "key": "value"
                },
                "lastSyncedAt": "2026-10-17T08:46:48.000Z",
                "createdAt": "2026-10-06T14:28:25.000Z",
                "updatedAt": "2026-10-14T17:19:03.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.ListCampaignsAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
