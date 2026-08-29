using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Balance;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTransactionReferenceTypesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "reference_types": [
                "reference_types",
                "reference_types"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/transactions/reference-types")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Balance.ListTransactionReferenceTypesAsync(
            new ListTransactionReferenceTypesRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "reference_types": [
                "cdr",
                "did_purchase",
                "did_rental",
                "manual_adjustment",
                "ncc",
                "recording",
                "stream_cdr",
                "transcription"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/transactions/reference-types")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Balance.ListTransactionReferenceTypesAsync(
            new ListTransactionReferenceTypesRequest { AuthId = "MA_XXXXXX" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
