using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Coverage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCoverageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "country": "country",
              "name": "name",
              "region": "region",
              "dialCode": "dialCode",
              "mcc": "mcc",
              "numberPortability": true,
              "localVsInternationalTraffic": true,
              "senders": {
                "alphanumeric": {
                  "local": true,
                  "international": true
                },
                "shortCode": {
                  "local": true,
                  "international": true
                },
                "longNumber": {
                  "local": true,
                  "international": true
                }
              },
              "registration": {
                "required": {
                  "local": true,
                  "international": true
                },
                "durationDays": "durationDays",
                "informationRequired": "informationRequired",
                "documentsRequired": "documentsRequired",
                "alphanumericExtraSteps": "alphanumericExtraSteps"
              },
              "urls": {
                "allowed": {
                  "local": true,
                  "international": true
                },
                "whitelistingRequired": {
                  "local": true,
                  "international": true
                }
              },
              "optOutMandatory": true,
              "twoWay": true,
              "prohibitedTopics": [
                "prohibitedTopics",
                "prohibitedTopics"
              ],
              "prohibitedNotes": "prohibitedNotes",
              "sendWindow": {
                "weekday": "weekday",
                "saturday": "saturday",
                "sunday": "sunday"
              },
              "marketNotes": "marketNotes",
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/coverage/country")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Coverage.GetCoverageAsync(
            new GetCoverageRequest { Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "country": "IN",
              "name": "India",
              "region": "South-central Asia",
              "dialCode": "91",
              "mcc": "405",
              "numberPortability": true,
              "localVsInternationalTraffic": false,
              "senders": {
                "alphanumeric": {
                  "local": true,
                  "international": true
                },
                "shortCode": {
                  "local": false,
                  "international": true
                },
                "longNumber": {
                  "local": false,
                  "international": true
                }
              },
              "registration": {
                "required": {
                  "local": false,
                  "international": false
                },
                "alphanumericExtraSteps": "Register the Principal Entity, the sender header and each content template on a TRAI DLT portal before sending local traffic."
              },
              "urls": {
                "allowed": {
                  "local": true,
                  "international": true
                },
                "whitelistingRequired": {
                  "local": false,
                  "international": false
                }
              },
              "optOutMandatory": false,
              "twoWay": true,
              "prohibitedTopics": [
                "Regulatory",
                "Other Scams",
                "Gambling",
                "Explicit Content",
                "Phishing"
              ],
              "prohibitedNotes": "Gambling - only OTP allowed. Political and adult content is not allowed.",
              "sendWindow": {
                "weekday": "MON - FRI: 10:00:00 - 21:00:00; Timezone from MSISDN",
                "saturday": "SAT: 10:00:00 - 21:00:00; Timezone from MSISDN",
                "sunday": "SUN: 10:00:00 - 21:00:00; Timezone from MSISDN"
              },
              "marketNotes": "DLT registration applies to all local SMS traffic types (promotional, transactional and OTP).",
              "updatedAt": "2026-10-09T09:49:01.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/coverage/US")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Coverage.GetCoverageAsync(
            new GetCoverageRequest { Country = "US" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
