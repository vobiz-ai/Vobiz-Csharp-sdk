using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Numbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchAvailableNumbersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "numbers": [
                {
                  "e164": "e164",
                  "numberKey": "numberKey",
                  "countryCode": "countryCode",
                  "type": "type",
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ],
                  "network": "network",
                  "setupPrice": 1.1,
                  "monthlyPrice": 1.1,
                  "currency": "currency",
                  "providerRequiresDocuments": true
                },
                {
                  "e164": "e164",
                  "numberKey": "numberKey",
                  "countryCode": "countryCode",
                  "type": "type",
                  "capabilities": [
                    "capabilities",
                    "capabilities"
                  ],
                  "network": "network",
                  "setupPrice": 1.1,
                  "monthlyPrice": 1.1,
                  "currency": "currency",
                  "providerRequiresDocuments": true
                }
              ],
              "page": 1,
              "limit": 1,
              "hasMore": true,
              "hint": "hint"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/available")
                    .WithParam("country", "country")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.SearchAvailableNumbersAsync(
            new SearchAvailableNumbersRequest { Country = "country" }
        );
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
                  "numberKey": "",
                  "countryCode": "US",
                  "type": "VIRTUAL_LONG_NUMBER",
                  "capabilities": [
                    "MMS",
                    "SMS",
                    "VOICE"
                  ],
                  "network": "",
                  "setupPrice": 1,
                  "monthlyPrice": 1,
                  "currency": "USD",
                  "providerRequiresDocuments": false
                }
              ],
              "page": 0,
              "limit": 10,
              "hasMore": false,
              "hint": "India uses DLT sender IDs, not long codes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/available")
                    .WithParam("country", "US")
                    .WithParam("capabilities", "SMS", "MMS")
                    .WithParam("areaCode", "415")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.SearchAvailableNumbersAsync(
            new SearchAvailableNumbersRequest
            {
                Country = "US",
                Capabilities = "SMS,MMS",
                AreaCode = "415",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "numbers": [
                {
                  "e164": "+14155550100",
                  "numberKey": "",
                  "countryCode": "US",
                  "type": "VIRTUAL_LONG_NUMBER",
                  "capabilities": [
                    "MMS",
                    "SMS",
                    "VOICE"
                  ],
                  "network": "",
                  "setupPrice": 1,
                  "monthlyPrice": 1,
                  "currency": "USD",
                  "providerRequiresDocuments": true
                }
              ],
              "page": 0,
              "limit": 10,
              "hasMore": false,
              "hint": "India uses DLT sender IDs, not long codes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/numbers/available")
                    .WithParam("country", "US")
                    .WithParam("capabilities", "SMS", "MMS")
                    .WithParam("areaCode", "415")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Numbers.SearchAvailableNumbersAsync(
            new SearchAvailableNumbersRequest
            {
                Country = "US",
                Capabilities = "SMS,MMS",
                AreaCode = "415",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
