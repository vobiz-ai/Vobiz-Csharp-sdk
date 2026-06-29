using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Recordings;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetRecordingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "add_time": "add_time",
              "api_id": "api_id",
              "call_uuid": "call_uuid",
              "conference_name": {
                "key": "value"
              },
              "from_number": "from_number",
              "monthly_recording_storage_amount": 1,
              "recording_duration_ms": "recording_duration_ms",
              "recording_end_ms": {
                "key": "value"
              },
              "recording_format": "recording_format",
              "recording_id": "recording_id",
              "recording_start_ms": {
                "key": "value"
              },
              "recording_storage_duration": 1,
              "recording_storage_rate": 1.1,
              "recording_type": "recording_type",
              "recording_url": "recording_url",
              "resource_uri": "resource_uri",
              "rounded_recording_duration": 1,
              "to_number": "to_number"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Recording/recording_id/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Recordings.GetRecordingAsync(
            new GetRecordingRequest { AuthId = "auth_id", RecordingId = "recording_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "add_time": "2026-03-25 10:00:00.000000+05:30",
              "api_id": "55667788-1234-5678-90ab-cdef12345678",
              "call_uuid": "55667788-1234-5678-90ab-cdef12345678",
              "from_number": "+919876543210",
              "monthly_recording_storage_amount": 0,
              "recording_duration_ms": "7880.00000",
              "recording_format": "wav",
              "recording_id": "55667788-1234-5678-90ab-cdef12345678",
              "recording_storage_duration": 6,
              "recording_storage_rate": 0.005,
              "recording_type": "trunk",
              "recording_url": "https://recordings.vobiz.ai/example/abc123.mp3",
              "resource_uri": "/v1/Account/MA_XXXXXXXX/Recording/55667788-1234-5678-90ab-cdef12345678/",
              "rounded_recording_duration": 60,
              "to_number": "+918012345678"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Recording/rec_XXXXXXXXXX/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Recordings.GetRecordingAsync(
            new GetRecordingRequest { AuthId = "MA_XXXXXX", RecordingId = "rec_XXXXXXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
