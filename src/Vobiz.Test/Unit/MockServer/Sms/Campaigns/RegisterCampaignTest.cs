using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RegisterCampaignTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns/id/register")
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

        var response = await Client.Sms.Campaigns.RegisterCampaignAsync(
            new CampaignRegisterRequest { Id = "id", PriorityId = null }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "priorityId": "2c9e4b7a-1d3f-4a5b-8c6d-0e9f8a7b6c5d"
            }
            """;

        const string mockResponse = """
            {
              "id": "8a7d2f10-3c4b-4e9a-b1d2-6e5f4a3b2c11",
              "accountId": "MA_XXXXXXXX",
              "brandId": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
              "name": "Example Corp account alerts",
              "campaignType": "TEN_DIGIT_LONG_CODE",
              "stage": "IN_REVIEW",
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
              "lastSyncedAt": "2026-10-06T15:10:00.000Z",
              "createdAt": "2026-10-06T14:28:25.000Z",
              "updatedAt": "2026-10-06T15:10:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/10dlc/campaigns/4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24/register"
                    )
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

        var response = await Client.Sms.Campaigns.RegisterCampaignAsync(
            new CampaignRegisterRequest
            {
                Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
                PriorityId = "2c9e4b7a-1d3f-4a5b-8c6d-0e9f8a7b6c5d",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
