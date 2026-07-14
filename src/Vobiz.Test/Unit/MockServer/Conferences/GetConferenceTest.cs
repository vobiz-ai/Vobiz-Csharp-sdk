using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Conferences;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetConferenceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "conference_name": "conference_name",
              "conference_run_time": "conference_run_time",
              "conference_member_count": "conference_member_count",
              "members": [
                {
                  "muted": true,
                  "member_id": "member_id",
                  "deaf": true,
                  "from": "from",
                  "to": "to",
                  "caller_name": "caller_name",
                  "direction": "direction",
                  "call_uuid": "call_uuid",
                  "join_time": "join_time"
                },
                {
                  "muted": true,
                  "member_id": "member_id",
                  "deaf": true,
                  "from": "from",
                  "to": "to",
                  "caller_name": "caller_name",
                  "direction": "direction",
                  "call_uuid": "call_uuid",
                  "join_time": "join_time"
                }
              ],
              "api_id": "api_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/Conference/conference_name/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conferences.GetConferenceAsync(
            new GetConferenceRequest { AuthId = "auth_id", ConferenceName = "conference_name" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "conference_name": "My Conf Room",
              "conference_run_time": "590",
              "conference_member_count": "1",
              "members": [
                {
                  "muted": false,
                  "member_id": "17",
                  "deaf": false,
                  "from": "CALLER_NUMBER",
                  "to": "VOBIZ_NUMBER",
                  "caller_name": "CALLER_NAME",
                  "direction": "inbound",
                  "call_uuid": "CALL_UUID",
                  "join_time": "590"
                }
              ],
              "api_id": "API_REQUEST_ID"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Conference/My Conf Room/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conferences.GetConferenceAsync(
            new GetConferenceRequest { AuthId = "MA_XXXXXX", ConferenceName = "My Conf Room" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "error": "failed",
              "api_id": "API_REQUEST_ID"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/Conference/My Conf Room/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conferences.GetConferenceAsync(
            new GetConferenceRequest { AuthId = "MA_XXXXXX", ConferenceName = "My Conf Room" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
