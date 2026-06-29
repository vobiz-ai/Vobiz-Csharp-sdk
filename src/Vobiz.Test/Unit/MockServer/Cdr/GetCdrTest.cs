using NUnit.Framework;
using Vobiz;
using Vobiz.Test.Unit.MockServer;
using Vobiz.Test.Utils;

namespace Vobiz.Test.Unit.MockServer.Cdr;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCdrTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": {
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
                "failure_code": {
                  "key": "value"
                },
                "failure_reason": {
                  "key": "value"
                },
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
                "packet_loss": 1,
                "progress_time": "progress_time",
                "region": "region",
                "ring_time": 1,
                "sip_call_id": "sip_call_id",
                "sip_user_agent": "sip_user_agent",
                "start_time": "start_time",
                "streaming_cost": 1,
                "terminated_to": {
                  "key": "value"
                },
                "total_cost": 1.1,
                "trunk_id": {
                  "key": "value"
                },
                "updated_at": "updated_at",
                "uuid": "uuid"
              },
              "success": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/auth_id/cdr/call_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cdr.GetCdrAsync(
            new GetCdrRequest { AuthId = "auth_id", CallId = "call_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": {
                "account_id": "MA_XXXXXXXX",
                "answer_time": "2026-03-25T10:00:01Z",
                "billsec": 42,
                "bridge_uuid": "11223344-5566-7788-99aa-bbccddeeff00",
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
                "id": 18000004,
                "jitter": 0,
                "mos": 4.5,
                "network_addr": "10.0.0.1",
                "origination_region": "mumbai",
                "packet_loss": 0,
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
              "success": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/Account/MA_XXXXXX/cdr/abc123-def456-ghi789")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cdr.GetCdrAsync(
            new GetCdrRequest { AuthId = "MA_XXXXXX", CallId = "abc123-def456-ghi789" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
