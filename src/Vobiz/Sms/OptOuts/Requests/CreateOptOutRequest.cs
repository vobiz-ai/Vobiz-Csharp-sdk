using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record CreateOptOutRequest
{
    /// <summary>
    /// Required. The phone number to block, in E.164 format, for example `+14155550123`.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Channel to block: `sms`, `mms` or `rcs`. Defaults to `sms`. An `sms` opt-out also blocks `mms`.
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>
    /// Free-text note stored on the record, for example `customer request`. Defaults to `manual`. Repeating the request for the same number and channel replaces it.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
