using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListKycSessionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "sessions": [
                {
                  "id": "id",
                  "account_auth_id": "account_auth_id",
                  "customer_email": "customer_email",
                  "kyc_type": "kyc_type",
                  "status": "status",
                  "expires_at": "expires_at",
                  "first_opened_at": "first_opened_at",
                  "completed_at": "completed_at",
                  "webhook_url": "webhook_url",
                  "redirect_url": "redirect_url",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    },
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "metadata": {
                    "key": "value"
                  },
                  "verified_data": {
                    "key": "value"
                  },
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                },
                {
                  "id": "id",
                  "account_auth_id": "account_auth_id",
                  "customer_email": "customer_email",
                  "kyc_type": "kyc_type",
                  "status": "status",
                  "expires_at": "expires_at",
                  "first_opened_at": "first_opened_at",
                  "completed_at": "completed_at",
                  "webhook_url": "webhook_url",
                  "redirect_url": "redirect_url",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    },
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "metadata": {
                    "key": "value"
                  },
                  "verified_data": {
                    "key": "value"
                  },
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                }
              ],
              "total": 1,
              "page": 1,
              "size": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/kyc-sessions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListKycSessionsAsync(new ListKycSessionsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "sessions": [
                {
                  "id": "kycs_aabbccdd1234",
                  "account_auth_id": "MA_XXXXXXXX",
                  "status": "opened",
                  "expires_at": "2026-04-08T08:32:48Z",
                  "first_opened_at": "2026-03-25T08:33:01Z",
                  "redirect_url": "https://console.vobiz.ai/kyc-complete",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "created_at": "2026-03-25T08:32:48Z",
                  "updated_at": "2026-03-25T08:33:01Z"
                },
                {
                  "id": "kycs_11223344abcd",
                  "account_auth_id": "MA_XXXXXXXX",
                  "customer_email": "admin@example.com",
                  "status": "revoked",
                  "expires_at": "2026-04-24T07:12:48Z",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "created_at": "2026-03-25T07:12:48Z",
                  "updated_at": "2026-03-25T08:32:48Z"
                },
                {
                  "id": "kycs_55667788ef01",
                  "account_auth_id": "MA_YYYYYYYY",
                  "customer_email": "sarah@acme-corp.com",
                  "status": "opened",
                  "expires_at": "2026-04-24T07:07:38Z",
                  "first_opened_at": "2026-03-25T07:07:59Z",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "created_at": "2026-03-25T07:07:38Z",
                  "updated_at": "2026-03-25T07:07:59Z"
                },
                {
                  "id": "kycs_99887766abcd",
                  "account_auth_id": "MA_YYYYYYYY",
                  "customer_email": "sarah@acme-corp.com",
                  "kyc_type": "individual",
                  "status": "revoked",
                  "expires_at": "2026-04-23T06:00:52Z",
                  "first_opened_at": "2026-03-24T06:02:17Z",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "verified_data": {
                    "pan_type": "individual",
                    "pan_number": "GTBPDXXXXX",
                    "pan_name_match": true,
                    "completed_steps": [
                      "pan"
                    ],
                    "pan_registered_name": "Sarah Smith"
                  },
                  "created_at": "2026-03-24T06:00:52Z",
                  "updated_at": "2026-03-25T07:07:38Z"
                },
                {
                  "id": "kycs_aabbcc998877",
                  "account_auth_id": "MA_ZZZZZZZZ",
                  "customer_email": "john@example.com",
                  "kyc_type": "individual",
                  "status": "kyc_completed",
                  "expires_at": "2026-04-23T05:45:48Z",
                  "first_opened_at": "2026-03-24T05:46:23Z",
                  "completed_at": "2026-03-24T06:19:52Z",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "verified_data": {
                    "gender": "MALE",
                    "address": "221B Baker Street, Mumbai, Maharashtra, 400001, India",
                    "aadhaar_dob": "2001-02-05",
                    "aadhaar_name": "John Doe",
                    "masked_aadhaar": "9942"
                  },
                  "created_at": "2026-03-24T05:45:48Z",
                  "updated_at": "2026-03-24T06:19:52Z"
                },
                {
                  "id": "kycs_5566778899aa",
                  "account_auth_id": "MA_WWWWWWWW",
                  "customer_email": "demo@example.com",
                  "status": "email_sent",
                  "expires_at": "2026-04-22T04:11:19Z",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "created_at": "2026-03-23T04:11:19Z",
                  "updated_at": "2026-03-23T04:11:19Z"
                },
                {
                  "id": "kycs_99aabbccdd11",
                  "account_auth_id": "MA_VVVVVVVV",
                  "customer_email": "demo@example.com",
                  "kyc_type": "individual",
                  "status": "in_progress",
                  "expires_at": "2026-04-19T12:12:58Z",
                  "first_opened_at": "2026-03-20T12:13:18Z",
                  "reminder_schedule": [
                    {
                      "value": 1,
                      "trigger": "trigger"
                    }
                  ],
                  "verified_data": {
                    "pan_type": "individual",
                    "pan_number": "IMBPKXXXXX",
                    "pan_name_match": true,
                    "completed_steps": [
                      "pan"
                    ],
                    "pan_registered_name": "John Doe"
                  },
                  "created_at": "2026-03-20T12:12:58Z",
                  "updated_at": "2026-03-20T12:52:21Z"
                }
              ],
              "total": 7,
              "page": 1,
              "size": 20
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/kyc-sessions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListKycSessionsAsync(new ListKycSessionsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
