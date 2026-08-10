using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.BulkOperations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkExportRecordingsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "recipient": {
                "customer_account": [
                  "customer_account",
                  "customer_account"
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "api_id": "api_id",
              "status": "status"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/export/recording/")
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

        var response = await Client.BulkOperations.BulkExportRecordingsAsync(
            new BulkExportRecordingsRequest
            {
                AuthId = "auth_id",
                Recipient = new BulkExportRecordingsRequestRecipient
                {
                    CustomerAccount = new List<string>() { "customer_account", "customer_account" },
                },
                From = null,
                To = null,
                RecordingStorageDuration = null,
                RecordingStorageDurationGte = null,
                RecordingStorageDurationGt = null,
                RecordingStorageDurationLte = null,
                RecordingStorageDurationLt = null,
                FromNumber = null,
                ToNumber = null,
                CallUuid = null,
                ConferenceName = null,
                RecordingFormat = null,
                RecordingId = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "recipient": {
                "customer_account": [
                  "admin@example.com"
                ]
              },
              "from": "2025-01-23 00:00:00",
              "to": "2025-01-30 23:59:59"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "correlation-id-uuid",
              "status": "success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/export/recording/")
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

        var response = await Client.BulkOperations.BulkExportRecordingsAsync(
            new BulkExportRecordingsRequest
            {
                AuthId = "MA_XXXXXX",
                Recipient = new BulkExportRecordingsRequestRecipient
                {
                    CustomerAccount = new List<string>() { "admin@example.com" },
                },
                From = "2025-01-23 00:00:00",
                To = "2025-01-30 23:59:59",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "recipient": {
                "customer_account": [
                  "admin@example.com"
                ]
              },
              "recording_storage_duration": "7"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "correlation-id-uuid",
              "status": "success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/export/recording/")
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

        var response = await Client.BulkOperations.BulkExportRecordingsAsync(
            new BulkExportRecordingsRequest
            {
                AuthId = "MA_XXXXXX",
                Recipient = new BulkExportRecordingsRequestRecipient
                {
                    CustomerAccount = new List<string>() { "admin@example.com" },
                },
                RecordingStorageDuration = "7",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "recipient": {
                "customer_account": [
                  "admin@example.com"
                ]
              },
              "recording_storage_duration__gte": "7",
              "recording_storage_duration__lte": "30"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "correlation-id-uuid",
              "status": "success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/export/recording/")
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

        var response = await Client.BulkOperations.BulkExportRecordingsAsync(
            new BulkExportRecordingsRequest
            {
                AuthId = "MA_XXXXXX",
                Recipient = new BulkExportRecordingsRequestRecipient
                {
                    CustomerAccount = new List<string>() { "admin@example.com" },
                },
                RecordingStorageDurationGte = "7",
                RecordingStorageDurationLte = "30",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "recipient": {
                "customer_account": [
                  "admin@example.com",
                  "backup@example.com"
                ]
              },
              "from": "2025-01-01 00:00:00",
              "to": "2025-01-30 23:59:59",
              "conference_name": "TeamMeeting",
              "recording_format": "mp3"
            }
            """;

        const string mockResponse = """
            {
              "api_id": "correlation-id-uuid",
              "status": "success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/export/recording/")
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

        var response = await Client.BulkOperations.BulkExportRecordingsAsync(
            new BulkExportRecordingsRequest
            {
                AuthId = "MA_XXXXXX",
                Recipient = new BulkExportRecordingsRequestRecipient
                {
                    CustomerAccount = new List<string>()
                    {
                        "admin@example.com",
                        "backup@example.com",
                    },
                },
                From = "2025-01-01 00:00:00",
                To = "2025-01-30 23:59:59",
                ConferenceName = "TeamMeeting",
                RecordingFormat = BulkExportRecordingsRequestRecordingFormat.Mp3,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
