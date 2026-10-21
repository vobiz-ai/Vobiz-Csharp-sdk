using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Page-based pagination returned in the `pagination` object of the CDR list and search endpoints and the partner customer CDR endpoint. Loop while `has_next` is `true`, incrementing `page`.
/// </summary>
[Serializable]
public record CdrPagination : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Current page number, starting at 1.
    /// </summary>
    [JsonPropertyName("page")]
    public required int Page { get; set; }

    /// <summary>
    /// Number of records per page, as set by the `per_page` query parameter.
    /// </summary>
    [JsonPropertyName("per_page")]
    public required int PerPage { get; set; }

    /// <summary>
    /// Total number of records that match the filters across all pages.
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

    /// <summary>
    /// Total number of pages, `ceil(total / per_page)`.
    /// </summary>
    [JsonPropertyName("pages")]
    public required int Pages { get; set; }

    /// <summary>
    /// `true` when a page after this one exists.
    /// </summary>
    [JsonPropertyName("has_next")]
    public required bool HasNext { get; set; }

    /// <summary>
    /// `true` when a page before this one exists.
    /// </summary>
    [JsonPropertyName("has_prev")]
    public required bool HasPrev { get; set; }

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
