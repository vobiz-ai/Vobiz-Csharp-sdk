using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Conference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeafMemberTest : BaseMockServerTest
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
                    .WithPath(
                        "/api/v1/Account/auth_id/Conference/conference_name/Member/member_id/Deaf/"
                    )
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conference.DeafMemberAsync(
            new DeafMemberRequest
            {
                AuthId = "auth_id",
                ConferenceName = "conference_name",
                MemberId = "member_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "message": "deaf",
              "member_id": [
                "2"
              ],
              "api_id": "API_REQUEST_ID"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/Account/MA_XXXXXX/Conference/conference_name/Member/member_id/Deaf/"
                    )
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Conference.DeafMemberAsync(
            new DeafMemberRequest
            {
                AuthId = "MA_XXXXXX",
                ConferenceName = "conference_name",
                MemberId = "member_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
