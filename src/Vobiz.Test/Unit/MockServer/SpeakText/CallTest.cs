using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.SpeakText;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CallTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "text": "text"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/Speak/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.SpeakText.CallAsync(
                new SpeakTextCallRequest
                {
                    AuthId = "auth_id",
                    CallUuid = "call_uuid",
                    Text = "text",
                    Voice = null,
                    Language = null,
                    Legs = null,
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "text": "Hello, your appointment is confirmed for tomorrow at 3 PM.",
              "voice": "WOMAN",
              "language": "en-US"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/call_uuid/Speak/")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.SpeakText.CallAsync(
                new SpeakTextCallRequest
                {
                    AuthId = "MA_XXXXXX",
                    CallUuid = "call_uuid",
                    Text = "Hello, your appointment is confirmed for tomorrow at 3 PM.",
                    Voice = "WOMAN",
                    Language = "en-US",
                }
            )
        );
    }
}
