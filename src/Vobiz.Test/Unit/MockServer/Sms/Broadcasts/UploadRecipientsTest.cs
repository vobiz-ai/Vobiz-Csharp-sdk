using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UploadRecipientsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "numbers": [
                "numbers",
                "numbers"
              ]
            }
            """;

        const string mockResponse = """
            {
              "total": 1,
              "valid": 1,
              "invalid": [
                {
                  "row": 1,
                  "value": "value",
                  "reason": "missing phone number"
                },
                {
                  "row": 1,
                  "value": "value",
                  "reason": "missing phone number"
                }
              ],
              "invalidCount": 1,
              "duplicates": 1,
              "optedOut": 1,
              "columns": [
                "columns",
                "columns"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/id/recipients")
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

        var response = await Client.Sms.Broadcasts.UploadRecipientsAsync(
            new UploadRecipientsJson
            {
                Id = "id",
                Numbers = new List<string>() { "numbers", "numbers" },
                DefaultCountry = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "numbers": [
                "+14155550123",
                "+14155550124",
                "415 555 0125"
              ],
              "defaultCountry": "US"
            }
            """;

        const string mockResponse = """
            {
              "total": 5,
              "valid": 3,
              "invalid": [
                {
                  "row": 4,
                  "value": "abc",
                  "reason": "contains letters or symbols"
                }
              ],
              "invalidCount": 1,
              "duplicates": 1,
              "optedOut": 0,
              "columns": [
                "phone",
                "name",
                "amount"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/broadcasts/3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35/recipients"
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

        var response = await Client.Sms.Broadcasts.UploadRecipientsAsync(
            new UploadRecipientsJson
            {
                Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35",
                Numbers = new List<string>() { "+14155550123", "+14155550124", "415 555 0125" },
                DefaultCountry = UploadRecipientsJsonDefaultCountry.Us,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
