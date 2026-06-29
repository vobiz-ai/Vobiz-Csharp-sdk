using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateCustomerAccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name",
              "email": "email",
              "phone": "phone",
              "password": "password",
              "country": "country"
            }
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
                    .WithPath("/api/v1/partner/accounts")
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

        var response = await Client.PartnerApi.CreateCustomerAccountAsync(
            new CreateCustomerAccountRequest
            {
                Name = "name",
                Email = "email",
                Phone = "phone",
                Password = "password",
                Company = null,
                Country = "country",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "John Doe",
              "email": "john@example.com",
              "phone": "+919876543210",
              "password": "SecurePass123!",
              "country": "IN"
            }
            """;

        const string mockResponse = """
            {
              "auth_id": "MA_ZKITB8Z2",
              "auth_token": "your_auth_token_here",
              "name": "John Doe",
              "email": "john@example.com",
              "status": "active",
              "balance": 0,
              "currency": "INR",
              "country": "IN",
              "created_at": "2026-03-25T10:00:00Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts")
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

        var response = await Client.PartnerApi.CreateCustomerAccountAsync(
            new CreateCustomerAccountRequest
            {
                Name = "John Doe",
                Email = "john@example.com",
                Phone = "+919876543210",
                Password = "SecurePass123!",
                Country = "IN",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
