using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Coverage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCoverageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "countries": [
                {
                  "country": "country",
                  "name": "name",
                  "region": "region",
                  "dialCode": "dialCode",
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
                  "registrationRequired": {
                    "local": true,
                    "international": true
                  },
                  "twoWay": true,
                  "optOutMandatory": true,
                  "hasSendWindow": true
                },
                {
                  "country": "country",
                  "name": "name",
                  "region": "region",
                  "dialCode": "dialCode",
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
                  "registrationRequired": {
                    "local": true,
                    "international": true
                  },
                  "twoWay": true,
                  "optOutMandatory": true,
                  "hasSendWindow": true
                }
              ],
              "total": 1,
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/coverage")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Coverage.ListCoverageAsync(new ListCoverageRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "countries": [
                {
                  "country": "GB",
                  "name": "United Kingdom",
                  "region": "Northern Europe",
                  "dialCode": "44",
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
                  "registrationRequired": {
                    "local": true,
                    "international": true
                  },
                  "twoWay": true,
                  "optOutMandatory": false,
                  "hasSendWindow": false
                },
                {
                  "country": "US",
                  "name": "United States",
                  "region": "Northern America",
                  "dialCode": "1",
                  "senders": {
                    "alphanumeric": {
                      "local": false,
                      "international": false
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
                  "registrationRequired": {
                    "local": true,
                    "international": true
                  },
                  "twoWay": true,
                  "optOutMandatory": true,
                  "hasSendWindow": false
                }
              ],
              "total": 2,
              "updatedAt": "2026-10-09T09:49:01.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/coverage")
                    .WithParam("q", "united")
                    .WithParam("region", "Northern America")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Coverage.ListCoverageAsync(
            new ListCoverageRequest { Q = "united", Region = "Northern America" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
