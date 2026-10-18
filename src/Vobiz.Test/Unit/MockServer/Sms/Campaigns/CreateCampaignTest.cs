using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateCampaignTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "brandId": "brandId"
            }
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
                    .WithPath("/api/v1/sms/10dlc/campaigns")
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

        var response = await Client.Sms.Campaigns.CreateCampaignAsync(
            new CreateCampaignRequest
            {
                ReferenceId = null,
                BrandId = "brandId",
                CampaignType = null,
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
              "programSummary": "Example Corp sends account and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
              "confirmationMessage": "Example Corp: You are subscribed to account alerts. Msg frequency varies. Msg & data rates may apply. Reply HELP for help, STOP to opt out.",
              "helpMessage": "Example Corp: For help email support@example.com. Reply STOP to opt out.",
              "stopMessage": "Example Corp: You have been unsubscribed. Reply HELP for help.",
              "customerCarePhone": "+14155550100",
              "customerCareEmail": "support@example.com",
              "termsAndConditionsUrl": "https://example.com/terms",
              "privacyPolicyUrl": "https://example.com/privacy",
              "exampleMessages": [
                "Example Corp: Your support ticket #48213 was updated. View it at https://example.com/support. Reply STOP to opt out.",
                "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out."
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
              "embeddedLink": true,
              "numbers": [
                "14155550100"
              ],
              "referenceId": "campaign-account-alerts-01",
              "brandId": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
              "campaignType": "TEN_DIGIT_LONG_CODE"
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
              "programSummary": "Example Corp sends account and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
              "confirmationMessage": "Example Corp: You are subscribed to account alerts. Msg frequency varies. Msg & data rates may apply. Reply HELP for help, STOP to opt out.",
              "helpMessage": "Example Corp: For help email support@example.com. Reply STOP to opt out.",
              "stopMessage": "Example Corp: You have been unsubscribed. Reply HELP for help.",
              "customerCarePhone": "+14155550100",
              "customerCareEmail": "support@example.com",
              "exampleMessages": [
                "Example Corp: Your support ticket #48213 was updated. View it at https://example.com/support. Reply STOP to opt out.",
                "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out."
              ],
              "termsAndConditionsUrl": "https://example.com/terms",
              "privacyPolicyUrl": "https://example.com/privacy",
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
              "updatedAt": "2026-10-06T14:28:25.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns")
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

        var response = await Client.Sms.Campaigns.CreateCampaignAsync(
            new CreateCampaignRequest
            {
                Name = "Example Corp account alerts",
                ProgramSummary =
                    "Example Corp sends account and support alerts to customers who opted in on the sign-up form. Reply STOP to opt out, HELP for help.",
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
                    "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out.",
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
                Numbers = new List<string>() { "14155550100" },
                ReferenceId = "campaign-account-alerts-01",
                BrandId = "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
                CampaignType = CreateCampaignRequestCampaignType.TenDigitLongCode,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
