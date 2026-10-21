using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Offset-based pagination metadata returned in the `meta` object of the Application, Endpoint and Recording list endpoints. To fetch the next page, add `limit` to `offset`, or request the `next` URL as-is.
/// </summary>
[Serializable]
public record PaginationMeta : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Maximum number of items in `objects` for this request, as set by the `limit` query parameter (default 20).
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    /// <summary>
    /// Zero-based position of the first item in `objects`, as set by the `offset` query parameter.
    /// </summary>
    [JsonPropertyName("offset")]
    public required int Offset { get; set; }

    /// <summary>
    /// Total number of items that match the request across all pages.
    /// </summary>
    [JsonPropertyName("total_count")]
    public required int TotalCount { get; set; }

    /// <summary>
    /// Relative URL of the next page with `limit` and `offset` already set, or `null` on the last page.
    /// </summary>
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    /// <summary>
    /// Relative URL of the previous page, or `null` on the first page.
    /// </summary>
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

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
