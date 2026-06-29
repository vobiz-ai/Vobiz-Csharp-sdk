using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record SubaccountDigilockerInitiateRequest
{
    /// <summary>
    /// The sub-account's Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string SubAuthId { get; set; }

    [JsonPropertyName("redirect_url")]
    public required string RedirectUrl { get; set; }

    /// <summary>
    /// Opaque value echoed back on the redirect for CSRF protection.
    /// </summary>
    [JsonPropertyName("oauth_state")]
    public string? OauthState { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
