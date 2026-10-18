using NUnit.Framework;
using Vobiz.Sms;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Sms.Brands;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBrandTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "name": "name",
              "brandType": "TENDLC_PRIVATE_COMPANY"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "accountId": "accountId",
              "name": "name",
              "legalName": "legalName",
              "brandType": "TENDLC_PRIVATE_COMPANY",
              "stage": "DRAFT",
              "registrationStatus": "ACTIVE",
              "brandIdentityStatus": "brandIdentityStatus",
              "rejectionReasons": [
                {
                  "registrar": "registrar",
                  "state": "state",
                  "rejectionReason": "rejectionReason"
                },
                {
                  "registrar": "registrar",
                  "state": "state",
                  "rejectionReason": "rejectionReason"
                }
              ],
              "website": "website",
              "supportEmail": "supportEmail",
              "supportPhone": "supportPhone",
              "vertical": "vertical",
              "taxId": "taxId",
              "taxIdIssuingCountry": "taxIdIssuingCountry",
              "countryCode": "countryCode",
              "address": {
                "street": "street",
                "city": "city",
                "state": "state",
                "zipCode": "zipCode"
              },
              "alternateBusinessId": {
                "alternateBusinessId": {
                  "key": "value"
                }
              },
              "businessContactFirstName": "businessContactFirstName",
              "businessContactLastName": "businessContactLastName",
              "businessContactEmail": "businessContactEmail",
              "businessDba": "businessDba",
              "legalEntityType": "legalEntityType",
              "businessRegistrationType": "businessRegistrationType",
              "stockExchange": "stockExchange",
              "stockSymbol": "stockSymbol",
              "taxExemptStatus": "taxExemptStatus",
              "lastSyncedAt": "2024-01-15T09:30:00.000Z",
              "createdAt": "2024-01-15T09:30:00.000Z",
              "updatedAt": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Brands.CreateBrandAsync(
            new CreateBrandRequest
            {
                ReferenceId = null,
                Name = "name",
                LegalName = null,
                BrandType = CreateBrandRequestBrandType.TendlcPrivateCompany,
                Website = null,
                SupportEmail = null,
                SupportPhone = null,
                Vertical = null,
                TaxId = null,
                TaxIdIssuingCountry = null,
                CountryCode = null,
                Address = null,
                AlternateBusinessId = null,
                BusinessContactFirstName = null,
                BusinessContactLastName = null,
                BusinessContactEmail = null,
                BusinessDba = null,
                LegalEntityType = null,
                BusinessRegistrationType = null,
                TaxExemptStatus = null,
                StockExchange = null,
                StockSymbol = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "referenceId": "brand-example-corp-01",
              "name": "Example Corp",
              "legalName": "Example Corporation Inc.",
              "brandType": "TENDLC_PRIVATE_COMPANY",
              "website": "https://example.com",
              "supportEmail": "support@example.com",
              "supportPhone": "+14155550100",
              "vertical": "TECHNOLOGY",
              "taxId": "12-3456789",
              "taxIdIssuingCountry": "US",
              "countryCode": "US",
              "address": {
                "street": "100 Example Street",
                "city": "San Francisco",
                "state": "CA",
                "zipCode": "94105"
              },
              "businessContactFirstName": "Alex",
              "businessContactLastName": "Doe",
              "businessContactEmail": "alex.doe@example.com",
              "legalEntityType": "PRIVATE_COMPANY"
            }
            """;

        const string mockResponse = """
            {
              "id": "5f1c3a2e-7b4d-4e8f-9a0b-1c2d3e4f5a60",
              "accountId": "MA_XXXXXXXX",
              "name": "Example Corp",
              "legalName": "Example Corporation Inc.",
              "brandType": "TENDLC_PRIVATE_COMPANY",
              "stage": "DRAFT",
              "registrationStatus": "ACTIVE",
              "brandIdentityStatus": "VERIFIED",
              "rejectionReasons": [
                {
                  "registrar": "TCR",
                  "state": "REJECTED",
                  "rejectionReason": "Tax ID does not match the legal name on file."
                }
              ],
              "website": "https://example.com",
              "supportEmail": "support@example.com",
              "supportPhone": "+14155550100",
              "vertical": "TECHNOLOGY",
              "taxId": "12-3456789",
              "taxIdIssuingCountry": "US",
              "countryCode": "US",
              "address": {
                "street": "100 Example Street",
                "city": "San Francisco",
                "state": "CA",
                "zipCode": "94105"
              },
              "alternateBusinessId": {
                "key": "value"
              },
              "businessContactFirstName": "Alex",
              "businessContactLastName": "Doe",
              "businessContactEmail": "alex.doe@example.com",
              "businessDba": "businessDba",
              "legalEntityType": "PRIVATE_COMPANY",
              "businessRegistrationType": "businessRegistrationType",
              "stockExchange": "stockExchange",
              "stockSymbol": "stockSymbol",
              "taxExemptStatus": "taxExemptStatus",
              "lastSyncedAt": "2026-10-12T10:35:00.000Z",
              "createdAt": "2026-10-12T10:30:00.000Z",
              "updatedAt": "2026-10-12T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/sms/10dlc/brands")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Sms.Brands.CreateBrandAsync(
            new CreateBrandRequest
            {
                ReferenceId = "brand-example-corp-01",
                Name = "Example Corp",
                LegalName = "Example Corporation Inc.",
                BrandType = CreateBrandRequestBrandType.TendlcPrivateCompany,
                Website = "https://example.com",
                SupportEmail = "support@example.com",
                SupportPhone = "+14155550100",
                Vertical = "TECHNOLOGY",
                TaxId = "12-3456789",
                TaxIdIssuingCountry = "US",
                CountryCode = "US",
                Address = new BrandAddress
                {
                    Street = "100 Example Street",
                    City = "San Francisco",
                    State = "CA",
                    ZipCode = "94105",
                },
                BusinessContactFirstName = "Alex",
                BusinessContactLastName = "Doe",
                BusinessContactEmail = "alex.doe@example.com",
                LegalEntityType = "PRIVATE_COMPANY",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
