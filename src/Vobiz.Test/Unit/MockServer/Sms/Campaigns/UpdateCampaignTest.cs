using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateCampaignTest : BaseMockServerTest
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
                    .WithPath("/api/v1/sms/10dlc/campaigns/id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.UpdateCampaignAsync(
            new UpdateCampaignRequest
            {
                Id = "id",
                Name = null,
                ProgramSummary = null,
                ConfirmationMessage = null,
                HelpMessage = null,
                StopMessage = null,
                CustomerCarePhone = null,
                CustomerCareEmail = null,
                TermsAndConditionsUrl = null,
                PrivacyPolicyUrl = null,
                ExampleMessages = null,
                UseCases = null,
                MessageTypes = null,
                OptIns = null,
                LowVolume = null,
                AgeGated = null,
                DirectLending = null,
                EmbeddedLink = null,
                EmbeddedPhone = null,
                Numbers = null,
                SupportingDocuments = null,
                MmsSampleFiles = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "Example Corp account alerts",
              "programSummary": "Example Corp sends account, billing and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
              "confirmationMessage": "Example Corp: You are subscribed to account alerts. Msg frequency varies. Msg & data rates may apply. Reply HELP for help, STOP to opt out.",
              "helpMessage": "Example Corp: For help email support@example.com. Reply STOP to opt out.",
              "stopMessage": "Example Corp: You have been unsubscribed. Reply HELP for help.",
              "customerCarePhone": "+14155550100",
              "customerCareEmail": "support@example.com",
              "termsAndConditionsUrl": "https://example.com/terms",
              "privacyPolicyUrl": "https://example.com/privacy",
              "exampleMessages": [
                "Example Corp: Your support ticket #48213 was updated. View it at https://example.com/support. Reply STOP to opt out."
              ],
              "useCases": [
                "ALERTS"
              ],
              "messageTypes": [
                "SMS"
              ],
              "optIns": {
                "web": {
                  "url": "https://example.com/signup",
                  "callToAction": "By checking this box you agree to receive account alerts from Example Corp. Msg frequency varies. Msg & data rates may apply. Reply STOP to opt out, HELP for help."
                }
              },
              "lowVolume": true,
              "embeddedLink": true
            }
            """;

        const string mockResponse = """
            {
              "id": "8a7d2f10-3c4b-4e9a-b1d2-6e5f4a3b2c11",
              "accountId": "MA_XXXXXXXX",
              "brandId": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
              "name": "Example Corp account alerts",
              "campaignType": "TEN_DIGIT_LONG_CODE",
              "stage": "DRAFT",
              "programSummary": "Example Corp sends account, billing and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
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
              "lastSyncedAt": "2026-10-14T17:19:03.000Z",
              "createdAt": "2026-10-06T14:28:25.000Z",
              "updatedAt": "2026-10-06T15:02:10.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns/4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Campaigns.UpdateCampaignAsync(
            new UpdateCampaignRequest
            {
                Id = "4c2a0e8d-6b4f-4d2c-b0a8-9e7c5a3f1d24",
                Name = "Example Corp account alerts",
                ProgramSummary =
                    "Example Corp sends account, billing and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
                ConfirmationMessage =
                    "Example Corp: You are subscribed to account alerts. Msg frequency varies. Msg & data rates may apply. Reply HELP for help, STOP to opt out.",
                HelpMessage =
                    "Example Corp: For help email support@example.com. Reply STOP to opt out.",
                StopMessage = "Example Corp: You have been unsubscribed. Reply HELP for help.",
                CustomerCarePhone = "+14155550100",
                CustomerCareEmail = "support@example.com",
                TermsAndConditionsUrl = "https://example.com/terms",
                PrivacyPolicyUrl = "https://example.com/privacy",
                ExampleMessages = new List<string>()
                {
                    "Example Corp: Your support ticket #48213 was updated. View it at https://example.com/support. Reply STOP to opt out.",
                },
                UseCases = new List<string>() { "ALERTS" },
                MessageTypes = new List<string>() { "SMS" },
                OptIns = new Dictionary<string, object?>()
                {
                    {
                        "web",
                        new Dictionary<object, object?>()
                        {
                            {
                                "callToAction",
                                "By checking this box you agree to receive account alerts from Example Corp. Msg frequency varies. Msg & data rates may apply. Reply STOP to opt out, HELP for help."
                            },
                            { "url", "https://example.com/signup" },
                        }
                    },
                },
                LowVolume = true,
                EmbeddedLink = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
