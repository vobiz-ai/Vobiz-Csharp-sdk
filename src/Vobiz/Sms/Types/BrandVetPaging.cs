using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Paging details for a list of brand vets.
/// </summary>
[Serializable]
public record BrandVetPaging : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Zero-based index of this page, echoing the `page` you requested.
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Page size applied to the request; `20` when you omit `size` or send `0`.
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    /// <summary>
    /// Total number of pages at this `size`.
    /// </summary>
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// Total number of vetting records for the brand.
    /// </summary>
    [JsonPropertyName("totalResults")]
    public int? TotalResults { get; set; }

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
