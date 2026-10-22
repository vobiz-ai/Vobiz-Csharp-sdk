using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateOriginationUriRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// SIP URI of your inbound destination, for example `sip:sbc.example.com`.
    /// </summary>
    [JsonPropertyName("uri")]
    public required string Uri { get; set; }

    /// <summary>
    /// Label for the origination URI.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Routing priority. Lower values are tried first.
    /// </summary>
    [JsonPropertyName("priority")]
    public required int Priority { get; set; }

    /// <summary>
    /// Not read by the API. The API accepts the request but stores an empty `uri`. Send `uri` instead.
    /// </summary>
    [JsonPropertyName("sip_uri")]
    public string? SipUri { get; set; }

    /// <summary>
    /// Not read by the API. Send `description` instead.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
