using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record Endpoint : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("endpoint_id")]
    public string? EndpointId { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("sip_uri")]
    public string? SipUri { get; set; }

    [JsonPropertyName("sip_registered")]
    public EndpointSipRegistered? SipRegistered { get; set; }

    [JsonPropertyName("sip_contact")]
    public string? SipContact { get; set; }

    [JsonPropertyName("sip_expires")]
    public DateTime? SipExpires { get; set; }

    [JsonPropertyName("sip_user_agent")]
    public string? SipUserAgent { get; set; }

    [JsonPropertyName("application")]
    public EndpointApplication? Application { get; set; }

    [JsonPropertyName("allow_voice")]
    public bool? AllowVoice { get; set; }

    [JsonPropertyName("allow_message")]
    public bool? AllowMessage { get; set; }

    [JsonPropertyName("allow_video")]
    public bool? AllowVideo { get; set; }

    [JsonPropertyName("allow_same_domain")]
    public bool? AllowSameDomain { get; set; }

    [JsonPropertyName("allow_other_domains")]
    public bool? AllowOtherDomains { get; set; }

    [JsonPropertyName("allow_phones")]
    public bool? AllowPhones { get; set; }

    [JsonPropertyName("allow_apps")]
    public bool? AllowApps { get; set; }

    [JsonPropertyName("sub_account")]
    public string? SubAccount { get; set; }

    [JsonPropertyName("resource_uri")]
    public string? ResourceUri { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
