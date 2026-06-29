using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record RetrieveApplicationResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("answer_method")]
    public required string AnswerMethod { get; set; }

    [JsonPropertyName("answer_url")]
    public required string AnswerUrl { get; set; }

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    [JsonPropertyName("app_id")]
    public required string AppId { get; set; }

    [JsonPropertyName("app_name")]
    public required string AppName { get; set; }

    [JsonPropertyName("application_type")]
    public required string ApplicationType { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("default_app")]
    public required bool DefaultApp { get; set; }

    [JsonPropertyName("default_endpoint_app")]
    public required bool DefaultEndpointApp { get; set; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("fallback_answer_url")]
    public object? FallbackAnswerUrl { get; set; }

    [JsonPropertyName("fallback_method")]
    public required string FallbackMethod { get; set; }

    [JsonPropertyName("hangup_method")]
    public required string HangupMethod { get; set; }

    [JsonPropertyName("hangup_url")]
    public required string HangupUrl { get; set; }

    [JsonPropertyName("log_incoming_message")]
    public required bool LogIncomingMessage { get; set; }

    [JsonPropertyName("message_method")]
    public required string MessageMethod { get; set; }

    [JsonPropertyName("message_url")]
    public object? MessageUrl { get; set; }

    [JsonPropertyName("public_uri")]
    public required bool PublicUri { get; set; }

    [JsonPropertyName("resource_uri")]
    public required string ResourceUri { get; set; }

    [JsonPropertyName("sip_transfer_method")]
    public required string SipTransferMethod { get; set; }

    [JsonPropertyName("sip_transfer_url")]
    public object? SipTransferUrl { get; set; }

    [JsonPropertyName("sip_uri")]
    public required string SipUri { get; set; }

    [JsonPropertyName("sub_account")]
    public object? SubAccount { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

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
