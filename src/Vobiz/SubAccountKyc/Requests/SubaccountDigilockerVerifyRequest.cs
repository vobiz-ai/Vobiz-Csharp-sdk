using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record SubaccountDigilockerVerifyRequest
{
    /// <summary>
    /// The sub-account's Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string SubAuthId { get; set; }

    [JsonPropertyName("access_request_id")]
    public required string AccessRequestId { get; set; }

    /// <summary>
    /// Optional. Binds the Aadhaar to a specific number (92-series).
    /// </summary>
    [JsonPropertyName("linked_number")]
    public string? LinkedNumber { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
