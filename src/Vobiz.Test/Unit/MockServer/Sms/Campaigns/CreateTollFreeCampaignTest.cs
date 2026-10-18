using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Campaigns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTollFreeCampaignTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name"
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
                    .WithPath("/api/v1/sms/10dlc/campaigns/toll-free")
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

        var response = await Client.Sms.Campaigns.CreateTollFreeCampaignAsync(
            new TollFreeCampaignRequest
            {
                ReferenceId = null,
                Name = "name",
                PrivacyPolicyUrl = null,
                TermsAndConditionsUrl = null,
                MessageVolume = null,
                Numbers = null,
                NumberKeys = null,
                UseCase = null,
                ProgramSummary = null,
                ExampleMessage = null,
                OptIns = null,
                OptInImageUrLs = null,
                AdditionalInformation = null,
                CountryCode = null,
                Address = null,
                SupportPhone = null,
                SupportEmail = null,
                BusinessContactFirstName = null,
                BusinessContactLastName = null,
                LegalName = null,
                BusinessDba = null,
                BusinessName = null,
                BusinessWebsite = null,
                CustomerCareEmail = null,
                TaxId = null,
                TaxIdIssuingCountry = null,
                LegalEntityType = null,
                BusinessRegistrationType = null,
                CampaignVerifyToken = null,
                PriorityId = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "referenceId": "tollfree-notifications-01",
              "name": "Example Corp toll-free notifications",
              "privacyPolicyUrl": "https://example.com/privacy",
              "termsAndConditionsUrl": "https://example.com/terms",
              "messageVolume": "TEN_THOUSAND",
              "numbers": [
                "+18335550100"
              ],
              "useCase": "NOTIFICATIONS",
              "programSummary": "Example Corp sends account and support notifications to customers who opted in on the contact form. Reply STOP to opt out, HELP for help.",
              "exampleMessage": "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out, HELP for help.",
              "optIns": {
                "web": {
                  "url": "https://example.com/contact",
                  "callToAction": "By checking this box you agree to receive account notifications from Example Corp. Reply STOP to opt out, HELP for help."
                }
              },
              "optInImageURLs": [
                "https://example.com/opt-in-screenshot.png"
              ],
              "countryCode": "US",
              "address": {
                "street": "100 Example Street",
                "city": "San Francisco",
                "state": "CA",
                "zipCode": "94105"
              },
              "supportPhone": "+14155550100",
              "supportEmail": "support@example.com",
              "businessContactFirstName": "Alex",
              "businessContactLastName": "Doe",
              "legalName": "Example Corporation Inc.",
              "businessName": "Example Corp",
              "businessWebsite": "https://example.com",
              "customerCareEmail": "support@example.com",
              "taxId": "12-3456789",
              "taxIdIssuingCountry": "US",
              "legalEntityType": "PRIVATE_COMPANY"
            }
            """;

        const string mockResponse = """
            {
              "id": "9c1b3e5f-7a2d-4b8c-a0e1-2f3d4c5b6a72",
              "accountId": "MA_XXXXXXXX",
              "brandId": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
              "name": "Example Corp toll-free notifications",
              "campaignType": "TOLL_FREE_UNIFIED_NUMBER",
              "stage": "DRAFT",
              "programSummary": "Example Corp sends account and support notifications to customers who opted in on the contact form. Reply STOP to opt out, HELP for help.",
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
              "lastSyncedAt": "2026-10-14T17:19:03.000Z",
              "createdAt": "2026-10-08T04:36:40.000Z",
              "updatedAt": "2026-10-08T04:36:40.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/campaigns/toll-free")
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

        var response = await Client.Sms.Campaigns.CreateTollFreeCampaignAsync(
            new TollFreeCampaignRequest
            {
                ReferenceId = "tollfree-notifications-01",
                Name = "Example Corp toll-free notifications",
                PrivacyPolicyUrl = "https://example.com/privacy",
                TermsAndConditionsUrl = "https://example.com/terms",
                MessageVolume = "TEN_THOUSAND",
                Numbers = new List<string>() { "+18335550100" },
                UseCase = "NOTIFICATIONS",
                ProgramSummary =
                    "Example Corp sends account and support notifications to customers who opted in on the contact form. Reply STOP to opt out, HELP for help.",
                ExampleMessage =
                    "Example Corp: Your account balance is low. Add funds at https://example.com/wallet. Reply STOP to opt out, HELP for help.",
                OptIns = new Dictionary<string, object?>()
                {
                    {
                        "web",
                        new Dictionary<object, object?>()
                        {
                            {
                                "callToAction",
                                "By checking this box you agree to receive account notifications from Example Corp. Reply STOP to opt out, HELP for help."
                            },
                            { "url", "https://example.com/contact" },
                        }
                    },
                },
                OptInImageUrLs = new List<string>() { "https://example.com/opt-in-screenshot.png" },
                CountryCode = "US",
                Address = new BrandAddress
                {
                    Street = "100 Example Street",
                    City = "San Francisco",
                    State = "CA",
                    ZipCode = "94105",
                },
                SupportPhone = "+14155550100",
                SupportEmail = "support@example.com",
                BusinessContactFirstName = "Alex",
                BusinessContactLastName = "Doe",
                LegalName = "Example Corporation Inc.",
                BusinessName = "Example Corp",
                BusinessWebsite = "https://example.com",
                CustomerCareEmail = "support@example.com",
                TaxId = "12-3456789",
                TaxIdIssuingCountry = "US",
                LegalEntityType = "PRIVATE_COMPANY",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
