using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record MockSubaccountDigilockerVerifyRequest
{
    /// <summary>
    /// The sub-account's Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string SubAuthId { get; set; }

    [JsonPropertyName("access_request_id")]
    public required MockSubaccountDigilockerVerifyRequestAccessRequestId AccessRequestId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
