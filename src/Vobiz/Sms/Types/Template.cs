using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A message template registered on an RCS sender, with the approval status reported by the RCS platform.
/// </summary>
[Serializable]
public record Template : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the template on Vobiz (UUID). Template endpoints address templates by `templateName` instead.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The `id` of the RCS sender the template belongs to.
    /// </summary>
    [JsonPropertyName("senderId")]
    public string? SenderId { get; set; }

    /// <summary>
    /// Your Vobiz account ID (`MA_...`) that owns the template.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Internal routing identifier; do not rely on its value.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Unique name of the template on its sender. Used in the path of every template endpoint.
    /// </summary>
    [JsonPropertyName("templateName")]
    public string? TemplateName { get; set; }

    /// <summary>
    /// Template type as defined by the RCS platform.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Approval status reported by the RCS platform, stored on your account. `pending` until the platform reports otherwise. Call `GET /senders/{senderId}/templates/{templateName}/status` to refresh it.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The template content exactly as you submitted it.
    /// </summary>
    [JsonPropertyName("content")]
    public Dictionary<string, object?>? Content { get; set; }

    /// <summary>
    /// When the template was created on your account (ISO 8601, UTC).
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the template last changed, including status refreshes (ISO 8601, UTC).
    /// </summary>
    [JsonPropertyName("updatedAt")]
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
