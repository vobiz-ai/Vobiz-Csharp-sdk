using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.RcsSenders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetSenderTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "accountId": "accountId",
              "provider": "provider",
              "senderName": "senderName",
              "displayName": "displayName",
              "description": "description",
              "billingCategory": "billingCategory",
              "useCase": "useCase",
              "hostingRegion": "hostingRegion",
              "status": "pending",
              "brand": {
                "brandName": "brandName"
              },
              "color": "color",
              "phones": [
                {
                  "phoneNumber": "phoneNumber",
                  "label": "label"
                },
                {
                  "phoneNumber": "phoneNumber",
                  "label": "label"
                }
              ],
              "emails": [
                {
                  "address": "address",
                  "label": "label"
                },
                {
                  "address": "address",
                  "label": "label"
                }
              ],
              "websites": [
                {
                  "url": "url",
                  "label": "label"
                },
                {
                  "url": "url",
                  "label": "label"
                }
              ],
              "bannerUrl": "bannerUrl",
              "logoUrl": "logoUrl",
              "privacy": {
                "url": "url",
                "label": "label"
              },
              "termsOfService": {
                "url": "url",
                "label": "label"
              },
              "platform": {
                "applicationId": "applicationId",
                "entityId": "entityId"
              },
              "createdAt": "2024-01-15T09:30:00.000Z",
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/senders/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.RcsSenders.GetSenderAsync(
            new GetSenderRequest { Id = "id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "7a1c3e5f-9b2d-4c6e-8f0a-1b3d5e7f9a21",
              "accountId": "MA_XXXXXXXX",
              "provider": "YOUR_ROUTING_IDENTIFIER",
              "senderName": "example-brand",
              "displayName": "Example Brand",
              "description": "Order updates and support for Example Brand customers.",
              "billingCategory": "CONVERSATIONAL",
              "useCase": "TRANSACTIONAL",
              "hostingRegion": "NORTH_AMERICA",
              "status": "pending",
              "brand": {
                "brandName": "Example Brand"
              },
              "color": "#1A73E8",
              "phones": [
                {
                  "phoneNumber": "+14155550100",
                  "label": "Support"
                }
              ],
              "emails": [
                {
                  "address": "support@example.com",
                  "label": "Support"
                }
              ],
              "websites": [
                {
                  "url": "https://example.com",
                  "label": "Website"
                }
              ],
              "bannerUrl": "https://example.com/rcs/banner.jpg",
              "logoUrl": "https://example.com/rcs/logo.png",
              "privacy": {
                "url": "https://example.com/privacy",
                "label": "Privacy policy"
              },
              "termsOfService": {
                "url": "https://example.com/privacy",
                "label": "Privacy policy"
              },
              "platform": {
                "applicationId": "YOUR_APPLICATION_ID",
                "entityId": "YOUR_ENTITY_ID"
              },
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/senders/5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.RcsSenders.GetSenderAsync(
            new GetSenderRequest { Id = "5d7f9b1c-3e5a-4c7e-9f1b-3d5f7a9c1e3b" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
