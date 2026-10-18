using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Broadcasts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PreviewBroadcastTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "samples": [
                {
                  "to": "to",
                  "text": "text",
                  "segments": 1,
                  "encoding": "GSM-7"
                },
                {
                  "to": "to",
                  "text": "text",
                  "segments": 1,
                  "encoding": "GSM-7"
                }
              ],
              "missingVariables": [
                "missingVariables",
                "missingVariables"
              ],
              "estimatedSegments": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/id/preview")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.PreviewBroadcastAsync(
            new PreviewBroadcastRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "samples": [
                {
                  "to": "+14155550123",
                  "text": "Hi Priya, your refund of $42.00 is on its way.",
                  "segments": 1,
                  "encoding": "GSM-7"
                },
                {
                  "to": "+14155550124",
                  "text": "Hi Sam, your refund of $18.50 is on its way.",
                  "segments": 1,
                  "encoding": "GSM-7"
                }
              ],
              "missingVariables": [
                "missingVariables"
              ],
              "estimatedSegments": 2
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/broadcasts/3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35/preview")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Broadcasts.PreviewBroadcastAsync(
            new PreviewBroadcastRequest { Id = "3f8d2a6e-5b1c-4e7f-a9d0-2c4b6e8f1a35" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
