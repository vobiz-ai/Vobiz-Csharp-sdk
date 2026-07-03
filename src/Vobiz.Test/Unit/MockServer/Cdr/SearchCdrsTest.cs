using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Cdr;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchCdrsTest : BaseMockServerTest
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
              "filters": {
                "call_direction": "call_direction",
                "from_number": "from_number",
                "hangup_cause": "hangup_cause",
                "to_number": "to_number"
              },
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
                    .WithPath("/api/v1/Account/auth_id/cdr/search")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cdr.SearchCdrsAsync(
            new SearchCdrsRequest { AuthId = "auth_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "account_id": "MA_XXXXXXXX",
              "count": 1,
              "data": [
                {
                  "account_id": "MA_XXXXXXXX",
                  "answer_time": "2026-03-25T10:00:01Z",
                  "billsec": 42,
                  "bridge_uuid": "55667788-1122-3344-5566-77889900aabb",
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
                  "id": 18000002,
                  "jitter": 0.2,
                  "mos": 4.5,
                  "network_addr": "10.0.0.1",
                  "origination_region": "mumbai",
                  "packet_loss": 0.1,
                  "progress_time": "2026-03-25T10:00:00Z",
                  "region": "ap-south-1",
                  "ring_time": 5,
                  "sip_call_id": "55667788-1122-3344-5566-77889900aabb",
                  "sip_user_agent": "Vobiz",
                  "start_time": "2026-03-25T10:00:00Z",
                  "streaming_cost": 0,
                  "total_cost": 0.45,
                  "updated_at": "2026-03-25T10:00:42Z",
                  "uuid": "55667788-1122-3344-5566-77889900aabb"
                }
              ],
              "filters": {
                "call_direction": "outbound",
                "from_number": "+919876543210",
                "hangup_cause": "",
                "to_number": ""
              },
              "pagination": {
                "page": 1,
                "per_page": 20,
                "total": 1,
                "pages": 1,
                "has_next": false,
                "has_prev": false
              },
              "success": true,
              "summary": {
                "answerRate": 100,
                "answeredCalls": 1,
                "avgCallDuration": "47s",
                "last_call_at": "2026-03-25T10:00:00Z",
                "totalCalls": 1,
                "total_billable_seconds": 42,
                "total_cost": 0.45,
                "total_duration_seconds": 47
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/cdr/search")
                    .WithParam("from_number", "9876543210")
                    .WithParam("to_number", "1234567890")
                    .WithParam("start_date", "2026-03-01")
                    .WithParam("end_date", "2026-03-17")
                    .WithParam("min_duration", "10")
                    .WithParam("sip_call_id", "dD1qwu5VZ5iK3ed5u3uspjY5RKL")
                    .WithParam("bridge_uuid", "4b7ae653-f40d-42f1-b582-6b05dfcd0c0a")
                    .WithParam("hangup_cause", "NORMAL_CLEARING")
                    .WithParam("hangup_disposition", "send_refuse")
                    .WithParam("context", "sip-trunking")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cdr.SearchCdrsAsync(
            new SearchCdrsRequest
            {
                AuthId = "MA_XXXXXX",
                FromNumber = "9876543210",
                ToNumber = "1234567890",
                StartDate = new DateOnly(2026, 3, 1),
                EndDate = new DateOnly(2026, 3, 17),
                MinDuration = 10,
                SipCallId = "dD1qwu5VZ5iK3ed5u3uspjY5RKL",
                BridgeUuid = "4b7ae653-f40d-42f1-b582-6b05dfcd0c0a",
                HangupCause = "NORMAL_CLEARING",
                HangupDisposition = "send_refuse",
                Context = "sip-trunking",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
