using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;

namespace Vobiz.Test.Unit.MockServer.Sms.RcsSenders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTemplateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/senders/senderId/templates/templateName")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Sms.RcsSenders.DeleteTemplateAsync(
                new DeleteTemplateRequest { SenderId = "senderId", TemplateName = "templateName" }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/api/v1/sms/senders/5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b/templates/appointment_reminder"
                    )
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Sms.RcsSenders.DeleteTemplateAsync(
                new DeleteTemplateRequest
                {
                    SenderId = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b",
                    TemplateName = "appointment_reminder",
                }
            )
        );
    }
}
