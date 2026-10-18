using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Sms.Brands;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteBrandTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/id")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Sms.Brands.DeleteBrandAsync(new DeleteBrandRequest { Id = "id" })
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands/8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Sms.Brands.DeleteBrandAsync(
                new DeleteBrandRequest { Id = "8e6c4a2f-0d9b-4b7a-a5c3-1e9f7d5b3a10" }
            )
        );
    }
}
