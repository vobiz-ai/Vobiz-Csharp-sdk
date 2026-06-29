using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record Application : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    [JsonPropertyName("app_name")]
    public string? AppName { get; set; }

    [JsonPropertyName("application_type")]
    public string? ApplicationType { get; set; }

    [JsonPropertyName("answer_url")]
    public string? AnswerUrl { get; set; }

    [JsonPropertyName("answer_method")]
    public ApplicationAnswerMethod? AnswerMethod { get; set; }

    [JsonPropertyName("hangup_url")]
    public string? HangupUrl { get; set; }

    [JsonPropertyName("hangup_method")]
    public ApplicationHangupMethod? HangupMethod { get; set; }

    [JsonPropertyName("fallback_answer_url")]
    public string? FallbackAnswerUrl { get; set; }

    [JsonPropertyName("fallback_method")]
    public ApplicationFallbackMethod? FallbackMethod { get; set; }

    [JsonPropertyName("message_url")]
    public string? MessageUrl { get; set; }

    [JsonPropertyName("message_method")]
    public ApplicationMessageMethod? MessageMethod { get; set; }

    [JsonPropertyName("default_number_app")]
    public bool? DefaultNumberApp { get; set; }

    [JsonPropertyName("default_endpoint_app")]
    public bool? DefaultEndpointApp { get; set; }

    [JsonPropertyName("default_app")]
    public bool? DefaultApp { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("log_incoming_message")]
    public bool? LogIncomingMessage { get; set; }

    [JsonPropertyName("public_uri")]
    public bool? PublicUri { get; set; }

    [JsonPropertyName("sip_transfer_url")]
    public string? SipTransferUrl { get; set; }

    [JsonPropertyName("sip_transfer_method")]
    public ApplicationSipTransferMethod? SipTransferMethod { get; set; }

    [JsonPropertyName("sip_uri")]
    public string? SipUri { get; set; }

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
