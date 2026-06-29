using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.PartnerApi;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCustomerCdrsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "account_id": "account_id",
              "count": 1,
              "data": [
                {
                  "key": "value"
                },
                {
                  "key": "value"
                }
              ],
              "pagination": {
                "page": 1,
                "per_page": 1,
                "total": 1,
                "pages": 1,
                "has_next": true,
                "has_prev": true
              },
              "success": true,
              "summary": {
                "answerRate": 1,
                "answeredCalls": 1,
                "avgCallDuration": "avgCallDuration",
                "last_call_at": "last_call_at",
                "totalCalls": 1,
                "total_billable_seconds": 1,
                "total_cost": 1,
                "total_duration_seconds": 1
              },
              "account_auth_id": "account_auth_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/cdrs")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerCdrsAsync(
            new ListCustomerCdrsRequest { CustomerAuthId = "customer_auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "account_id": "MA_XXXXXXXX",
              "count": 2,
              "data": [
                {
                  "account_id": "MA_XXXXXXXX",
                  "answer_time": "2026-03-25T06:59:31Z",
                  "billsec": 1,
                  "bridge_uuid": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "call_direction": "outbound",
                  "caller_id_name": "Acme Corp",
                  "caller_id_number": "+918012345678",
                  "codec": "PCMU",
                  "context": "voice-api",
                  "cost": 0.3,
                  "created_at": "2026-03-25T06:59:32Z",
                  "currency": "INR",
                  "destination_number": "+919876543210",
                  "duration": 6,
                  "end_time": "2026-03-25T06:59:32Z",
                  "hangup_cause": "NORMAL_CLEARING",
                  "hangup_cause_code": 4000,
                  "hangup_cause_name": "Normal Hangup",
                  "hangup_disposition": "send_bye",
                  "hangup_source": "Caller",
                  "id": 18600001,
                  "jitter": 0,
                  "mos": 4.5,
                  "network_addr": "3.110.99.6",
                  "origination_region": "mumbai",
                  "packet_loss": 0,
                  "progress_time": "2026-03-25T06:59:26Z",
                  "region": "ap-south-1",
                  "ring_time": 5,
                  "sip_call_id": "11223344-1234-5678-90ab-cdef12345678",
                  "sip_user_agent": "Vobiz",
                  "start_time": "2026-03-25T06:59:26Z",
                  "streaming_cost": 0,
                  "total_cost": 0.3,
                  "updated_at": "2026-03-25T06:59:32Z",
                  "uuid": "55667788-1234-5678-90ab-cdef12345678"
                },
                {
                  "account_id": "MA_XXXXXXXX",
                  "answer_time": "2026-03-25T07:10:11Z",
                  "billsec": 4,
                  "bridge_uuid": "99887766-1234-5678-90ab-cdef12345678",
                  "call_direction": "inbound",
                  "caller_id_name": "+919876543210",
                  "caller_id_number": "+919876543210",
                  "codec": "PCMU",
                  "context": "voice-api",
                  "cost": 0.45,
                  "created_at": "2026-03-25T07:10:15Z",
                  "currency": "INR",
                  "destination_number": "+918012345678",
                  "duration": 9,
                  "end_time": "2026-03-25T07:10:15Z",
                  "hangup_cause": "NORMAL_CLEARING",
                  "hangup_cause_code": 4010,
                  "hangup_cause_name": "End Of XML Instructions",
                  "hangup_disposition": "send_bye",
                  "hangup_source": "Vobiz",
                  "id": 18600002,
                  "jitter": 0,
                  "mos": 4.5,
                  "network_addr": "13.203.7.132",
                  "origination_region": "mumbai",
                  "packet_loss": 0,
                  "progress_time": "2026-03-25T07:10:06Z",
                  "region": "ap-south-1",
                  "ring_time": 5,
                  "sip_call_id": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "sip_user_agent": "Vobiz",
                  "start_time": "2026-03-25T07:10:06Z",
                  "streaming_cost": 0,
                  "total_cost": 0.45,
                  "updated_at": "2026-03-25T07:10:15Z",
                  "uuid": "aabbccdd-9999-5678-90ab-cdef12345678"
                }
              ],
              "pagination": {
                "page": 1,
                "per_page": 20,
                "total": 2,
                "pages": 1,
                "has_next": false,
                "has_prev": false
              },
              "success": true,
              "summary": {
                "answerRate": 100,
                "answeredCalls": 2,
                "avgCallDuration": "7s",
                "last_call_at": "2026-03-25T07:10:15Z",
                "totalCalls": 2,
                "total_billable_seconds": 15,
                "total_cost": 1,
                "total_duration_seconds": 15
              },
              "account_auth_id": "MA_XXXXXXXX"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/partner/accounts/customer_auth_id/cdrs")
                    .WithParam("hangup_cause", "NO_ANSWER")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PartnerApi.ListCustomerCdrsAsync(
            new ListCustomerCdrsRequest
            {
                CustomerAuthId = "customer_auth_id",
                HangupCause = "NO_ANSWER",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
