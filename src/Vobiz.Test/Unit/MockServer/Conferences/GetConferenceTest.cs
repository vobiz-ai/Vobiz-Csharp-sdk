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
              "key": "value"
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
              "member_count": 3,
              "members": [
                {
                  "member_id": "1",
                  "muted": false,
                  "deaf": false
                }
              ]
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
