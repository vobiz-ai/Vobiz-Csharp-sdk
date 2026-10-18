using NUnit.Framework;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Numbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCountriesTest : BaseMockServerTest
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
                  "types": [
                    "types",
                    "types"
                  ],
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ]
                },
                {
                  "country": "country",
                  "name": "name",
                  "types": [
                    "types",
                    "types"
                  ],
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ]
                }
              ],
              "updatedAt": "2024-01-15T09:30:00.000Z",
              "ready": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/countries")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListCountriesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "countries": [
                {
                  "country": "CA",
                  "name": "Canada",
                  "types": [
                    "local"
                  ],
                  "capabilities": [
                    "SMS",
                    "MMS",
                    "VOICE"
                  ]
                },
                {
                  "country": "GB",
                  "name": "United Kingdom",
                  "types": [
                    "local"
                  ],
                  "capabilities": [
                    "SMS"
                  ]
                },
                {
                  "country": "US",
                  "name": "United States",
                  "types": [
                    "local",
                    "tollfree"
                  ],
                  "capabilities": [
                    "SMS",
                    "MMS",
                    "VOICE"
                  ]
                }
              ],
              "updatedAt": "2026-10-18T03:19:11.000Z",
              "ready": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/countries")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListCountriesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "countries": [
                {
                  "country": "US",
                  "name": "United States",
                  "types": [
                    "local",
                    "tollfree"
                  ],
                  "capabilities": [
                    "SMS",
                    "MMS",
                    "VOICE"
                  ]
                }
              ],
              "ready": false
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/countries")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.ListCountriesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
