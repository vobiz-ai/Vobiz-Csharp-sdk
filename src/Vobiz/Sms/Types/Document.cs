using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A supporting document or MMS sample file uploaded for campaign registration.
/// </summary>
[Serializable]
public record Document : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Record ID (UUID) of the upload on your account. Downloads and campaign references use `documentId`, not this value.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Your Vobiz account ID (`MA_...`). Always the account whose credentials made the request.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    /// <summary>
    /// Internal routing identifier; do not rely on its value.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// The registry's document ID (UUID). Use it in `GET /10dlc/documents/{id}` and in a campaign's `supportingDocuments` or `mmsSampleFiles`.
    /// </summary>
    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    /// <summary>
    /// Original filename of the upload. Omitted when not recorded.
    /// </summary>
    [JsonPropertyName("documentName")]
    public string? DocumentName { get; set; }

    /// <summary>
    /// Media type of the file, for example `application/pdf` or `image/png`. Omitted when not recorded.
    /// </summary>
    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    /// <summary>
    /// Size of the file in bytes.
    /// </summary>
    [JsonPropertyName("contentLength")]
    public long? ContentLength { get; set; }

    /// <summary>
    /// When the record was created on your account, in ISO 8601 (RFC 3339) UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

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
