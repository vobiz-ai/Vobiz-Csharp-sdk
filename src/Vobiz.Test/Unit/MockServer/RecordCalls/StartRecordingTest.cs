using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.RecordCalls;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StartRecordingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "key": "value"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Call/call_uuid/Record/")
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

        var response = await Client.RecordCalls.StartRecordingAsync(
            new StartRecordingRequest
            {
                AuthId = "auth_id",
                CallUuid = "call_uuid",
                TimeLimit = null,
                FileFormat = null,
                TranscriptionType = null,
                CallbackUrl = null,
                RecordChannelType = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "time_limit": 120,
              "file_format": "mp3"
            }
            """;

        const string mockResponse = """
            {
              "recording_id": "rec_XXXXXXXXXX",
              "message": "Recording started"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Call/cdr_XXXXXXXXXX/Record/")
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

        var response = await Client.RecordCalls.StartRecordingAsync(
            new StartRecordingRequest
            {
                AuthId = "MA_XXXXXX",
                CallUuid = "cdr_XXXXXXXXXX",
                TimeLimit = 120,
                FileFormat = StartRecordingRequestFileFormat.Mp3,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
