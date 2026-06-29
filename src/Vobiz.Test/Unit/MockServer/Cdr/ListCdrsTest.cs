using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Cdr;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCdrsTest : BaseMockServerTest
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
                  "account_id": "account_id",
                  "answer_time": "answer_time",
                  "billsec": 1,
                  "bridge_uuid": "bridge_uuid",
                  "call_direction": "call_direction",
                  "caller_id_name": "caller_id_name",
                  "caller_id_number": "caller_id_number",
                  "campaign_id": {
                    "key": "value"
                  },
                  "carrier_ip": {
                    "key": "value"
                  },
                  "codec": "codec",
                  "context": "context",
                  "cost": 1.1,
                  "created_at": "created_at",
                  "currency": "currency",
                  "customer_endpoint": {
                    "key": "value"
                  },
                  "destination_number": "destination_number",
                  "duration": 1,
                  "end_time": "end_time",
                  "failure_code": "failure_code",
                  "failure_reason": "failure_reason",
                  "hangup_cause": "hangup_cause",
                  "hangup_cause_code": 1,
                  "hangup_cause_name": "hangup_cause_name",
                  "hangup_disposition": "hangup_disposition",
                  "hangup_source": "hangup_source",
                  "id": 1,
                  "jitter": 1.1,
                  "mos": 1.1,
                  "network_addr": "network_addr",
                  "origination_region": "origination_region",
                  "packet_loss": 1.1,
                  "progress_time": "progress_time",
                  "region": "region",
                  "ring_time": 1,
                  "sip_call_id": "sip_call_id",
                  "sip_user_agent": "sip_user_agent",
                  "start_time": "start_time",
                  "streaming_cost": 1.1,
                  "terminated_to": "terminated_to",
                  "total_cost": 1.1,
                  "trunk_id": "trunk_id",
                  "updated_at": "updated_at",
                  "uuid": "uuid"
                },
                {
                  "account_id": "account_id",
                  "answer_time": "answer_time",
                  "billsec": 1,
                  "bridge_uuid": "bridge_uuid",
                  "call_direction": "call_direction",
                  "caller_id_name": "caller_id_name",
                  "caller_id_number": "caller_id_number",
                  "campaign_id": {
                    "key": "value"
                  },
                  "carrier_ip": {
                    "key": "value"
                  },
                  "codec": "codec",
                  "context": "context",
                  "cost": 1.1,
                  "created_at": "created_at",
                  "currency": "currency",
                  "customer_endpoint": {
                    "key": "value"
                  },
                  "destination_number": "destination_number",
                  "duration": 1,
                  "end_time": "end_time",
                  "failure_code": "failure_code",
                  "failure_reason": "failure_reason",
                  "hangup_cause": "hangup_cause",
                  "hangup_cause_code": 1,
                  "hangup_cause_name": "hangup_cause_name",
                  "hangup_disposition": "hangup_disposition",
                  "hangup_source": "hangup_source",
                  "id": 1,
                  "jitter": 1.1,
                  "mos": 1.1,
                  "network_addr": "network_addr",
                  "origination_region": "origination_region",
                  "packet_loss": 1.1,
                  "progress_time": "progress_time",
                  "region": "region",
                  "ring_time": 1,
                  "sip_call_id": "sip_call_id",
                  "sip_user_agent": "sip_user_agent",
                  "start_time": "start_time",
                  "streaming_cost": 1.1,
                  "terminated_to": "terminated_to",
                  "total_cost": 1.1,
                  "trunk_id": "trunk_id",
                  "updated_at": "updated_at",
                  "uuid": "uuid"
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
                "answerRate": 1.1,
                "answeredCalls": 1,
                "avgCallDuration": "avgCallDuration",
                "last_call_at": "last_call_at",
                "totalCalls": 1,
                "total_billable_seconds": 1,
                "total_cost": 1.1,
                "total_duration_seconds": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/cdr")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cdr.ListCdrsAsync(new ListCdrsRequest { AuthId = "auth_id" });
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
                  "answer_time": "2026-03-25T10:00:01Z",
                  "billsec": 42,
                  "bridge_uuid": "aabbccdd-1234-5678-90ab-cdef12345678",
                  "call_direction": "outbound",
                  "caller_id_name": "John Doe",
                  "caller_id_number": "+919876543210",
                  "carrier_ip": "10.0.0.1",
                  "codec": "PCMU",
                  "context": "voice-api",
                  "cost": 0.45,
                  "created_at": "2026-03-25T10:00:42Z",
                  "currency": "INR",
                  "destination_number": "+918012345678",
                  "duration": 47,
                  "end_time": "2026-03-25T10:00:42Z",
                  "hangup_cause": "NORMAL_CLEARING",
                  "hangup_cause_code": 4000,
                  "hangup_cause_name": "Normal Hangup",
                  "hangup_disposition": "send_bye",
                  "hangup_source": "Caller",
                  "id": 18000000,
                  "jitter": 0.2,
                  "mos": 4.5,
                  "network_addr": "10.0.0.1",
                  "origination_region": "mumbai",
                  "packet_loss": 0.1,
                  "progress_time": "2026-03-25T10:00:00Z",
                  "region": "ap-south-1",
                  "ring_time": 5,
                  "sip_call_id": "11223344-5566-7788-99aa-bbccddeeff00",
                  "sip_user_agent": "Vobiz",
                  "start_time": "2026-03-25T10:00:00Z",
                  "streaming_cost": 0,
                  "total_cost": 0.45,
                  "updated_at": "2026-03-25T10:00:42Z",
                  "uuid": "aabbccdd-1234-5678-90ab-cdef12345678"
                },
                {
                  "account_id": "MA_XXXXXXXX",
                  "billsec": 0,
                  "call_direction": "inbound",
                  "caller_id_name": "",
                  "caller_id_number": "+919876543210",
                  "codec": "PCMU",
                  "context": "voice-api",
                  "cost": 0,
                  "created_at": "2026-03-25T09:30:12Z",
                  "currency": "INR",
                  "destination_number": "+918012345678",
                  "duration": 12,
                  "end_time": "2026-03-25T09:30:12Z",
                  "failure_code": "16",
                  "failure_reason": "NO_ANSWER",
                  "hangup_cause": "NO_ANSWER",
                  "hangup_cause_code": 4100,
                  "hangup_cause_name": "No Answer",
                  "hangup_disposition": "send_cancel",
                  "hangup_source": "Callee",
                  "id": 18000001,
                  "jitter": 0,
                  "mos": 0,
                  "network_addr": "10.0.0.1",
                  "origination_region": "mumbai",
                  "packet_loss": 0,
                  "progress_time": "2026-03-25T09:30:00Z",
                  "region": "ap-south-1",
                  "ring_time": 12,
                  "sip_call_id": "99887766-5544-3322-1100-aabbccddeeff",
                  "sip_user_agent": "Vobiz",
                  "start_time": "2026-03-25T09:30:00Z",
                  "streaming_cost": 0,
                  "total_cost": 0,
                  "updated_at": "2026-03-25T09:30:12Z",
                  "uuid": "11223344-5566-7788-99aa-bbccddeeff00"
                }
              ],
              "pagination": {
                "page": 1,
                "per_page": 20,
                "total": 4500,
                "pages": 225,
                "has_next": true,
                "has_prev": false
              },
              "success": true,
              "summary": {
                "answerRate": 48.2,
                "answeredCalls": 2171,
                "avgCallDuration": "28s",
                "last_call_at": "2026-03-25T10:00:00Z",
                "totalCalls": 4500,
                "total_billable_seconds": 61211,
                "total_cost": 1564.51,
                "total_duration_seconds": 118234
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/cdr")
                    .WithParam("from_number", "9876543210")
                    .WithParam("to_number", "1234567890")
                    .WithParam("start_date", "2026-03-01")
                    .WithParam("end_date", "2026-03-17")
                    .WithParam("min_duration", "10")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cdr.ListCdrsAsync(
            new ListCdrsRequest
            {
                AuthId = "MA_XXXXXX",
                FromNumber = "9876543210",
                ToNumber = "1234567890",
                StartDate = new DateOnly(2026, 3, 1),
                EndDate = new DateOnly(2026, 3, 17),
                MinDuration = 10,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
