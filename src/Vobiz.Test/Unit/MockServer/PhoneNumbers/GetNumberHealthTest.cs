using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PhoneNumbers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetNumberHealthTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "e164": "e164",
              "status": "status",
              "usage_status": "usage_status",
              "is_spam": true,
              "granularity": "granularity",
              "summary": {
                "period_days": 1,
                "total_calls": 1,
                "answered_calls": 1,
                "answer_rate": 1.1,
                "total_minutes": 1.1,
                "avg_duration": 1.1
              },
              "snapshots": [
                {
                  "id": "id",
                  "ts": "2024-01-15T09:30:00.000Z",
                  "total_calls": 1,
                  "answered_calls": 1,
                  "failed_calls": 1,
                  "answer_rate": 1.1,
                  "total_duration": 1.1,
                  "avg_duration": 1.1,
                  "total_minutes": 1.1
                },
                {
                  "id": "id",
                  "ts": "2024-01-15T09:30:00.000Z",
                  "total_calls": 1,
                  "answered_calls": 1,
                  "failed_calls": 1,
                  "answer_rate": 1.1,
                  "total_duration": 1.1,
                  "avg_duration": 1.1,
                  "total_minutes": 1.1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/auth_id/numbers/e164/health")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.GetNumberHealthAsync(
            new GetNumberHealthRequest { AuthId = "auth_id", E164 = "e164" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "e164": "+919876543210",
              "status": "active",
              "usage_status": "unrated",
              "is_spam": false,
              "granularity": "daily",
              "summary": {
                "period_days": 30,
                "total_calls": 0,
                "answered_calls": 0,
                "answer_rate": 0,
                "total_minutes": 0,
                "avg_duration": 0
              },
              "snapshots": [
                {
                  "id": "bd41d44b-7217-4a78-9261-588fb1b41c25",
                  "ts": "2026-06-04T00:00:00.000Z",
                  "total_calls": 0,
                  "answered_calls": 0,
                  "failed_calls": 0,
                  "answer_rate": 0,
                  "total_duration": 0,
                  "avg_duration": 0,
                  "total_minutes": 0
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/account/MA_XXXXXX/numbers/%2B919876543210/health")
                    .WithParam("days", "30")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PhoneNumbers.GetNumberHealthAsync(
            new GetNumberHealthRequest
            {
                AuthId = "MA_XXXXXX",
                E164 = "%2B919876543210",
                Days = 30,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
