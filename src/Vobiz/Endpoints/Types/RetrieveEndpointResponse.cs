using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record RetrieveEndpointResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("alias")]
    public required string Alias { get; set; }

    [JsonPropertyName("application")]
    public required string Application { get; set; }

    [JsonPropertyName("endpoint_id")]
    public required string EndpointId { get; set; }

    [JsonPropertyName("resource_uri")]
    public required string ResourceUri { get; set; }

    [JsonPropertyName("sip_registered")]
    public required string SipRegistered { get; set; }

    [JsonPropertyName("sip_uri")]
    public required string SipUri { get; set; }

    [JsonPropertyName("sub_account")]
    public object? SubAccount { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }

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
