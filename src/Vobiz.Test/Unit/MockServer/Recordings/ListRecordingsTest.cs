using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Recordings;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListRecordingsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "meta": {
                "limit": 1,
                "next": "next",
                "offset": 1,
                "previous": {
                  "key": "value"
                },
                "total_count": 1
              },
              "objects": [
                {
                  "add_time": "add_time",
                  "call_uuid": "call_uuid",
                  "conference_name": "conference_name",
                  "from_number": "from_number",
                  "monthly_recording_storage_amount": 1,
                  "recording_duration_ms": "recording_duration_ms",
                  "recording_end_ms": "recording_end_ms",
                  "recording_format": "recording_format",
                  "recording_id": "recording_id",
                  "recording_start_ms": "recording_start_ms",
                  "recording_storage_duration": 1,
                  "recording_storage_rate": 1.1,
                  "recording_type": "recording_type",
                  "recording_url": "recording_url",
                  "resource_uri": "resource_uri",
                  "rounded_recording_duration": 1,
                  "to_number": "to_number"
                },
                {
                  "add_time": "add_time",
                  "call_uuid": "call_uuid",
                  "conference_name": "conference_name",
                  "from_number": "from_number",
                  "monthly_recording_storage_amount": 1,
                  "recording_duration_ms": "recording_duration_ms",
                  "recording_end_ms": "recording_end_ms",
                  "recording_format": "recording_format",
                  "recording_id": "recording_id",
                  "recording_start_ms": "recording_start_ms",
                  "recording_storage_duration": 1,
                  "recording_storage_rate": 1.1,
                  "recording_type": "recording_type",
                  "recording_url": "recording_url",
                  "resource_uri": "resource_uri",
                  "rounded_recording_duration": 1,
                  "to_number": "to_number"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Recording/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Recordings.ListRecordingsAsync(
            new ListRecordingsRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "api_id": "api_id",
              "meta": {
                "limit": 1,
                "next": "next",
                "offset": 1,
                "previous": {
                  "key": "value"
                },
                "total_count": 1
              },
              "objects": [
                {
                  "add_time": "add_time",
                  "call_uuid": "call_uuid",
                  "conference_name": "conference_name",
                  "from_number": "from_number",
                  "monthly_recording_storage_amount": 1,
                  "recording_duration_ms": "recording_duration_ms",
                  "recording_end_ms": "recording_end_ms",
                  "recording_format": "recording_format",
                  "recording_id": "rec_XXXXXXXXXX",
                  "recording_start_ms": "recording_start_ms",
                  "recording_storage_duration": 1,
                  "recording_storage_rate": 1.1,
                  "recording_type": "recording_type",
                  "recording_url": "https://storage.vobiz.ai/recordings/rec_XXXXXXXXXX.mp3",
                  "resource_uri": "resource_uri",
                  "rounded_recording_duration": 1,
                  "to_number": "to_number"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Recording/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Recordings.ListRecordingsAsync(
            new ListRecordingsRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
