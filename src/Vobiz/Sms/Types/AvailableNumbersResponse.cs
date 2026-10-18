using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One page of inventory search results.
/// </summary>
[Serializable]
public record AvailableNumbersResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Numbers that match your filters, at most 10 per search. Empty array when nothing matches, and for `country=IN`.
    /// </summary>
    [JsonPropertyName("numbers")]
    public IEnumerable<AvailableNumber>? Numbers { get; set; }

    /// <summary>
    /// The zero-based page index you requested, echoed back.
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Page size applied to this search, at most `10`.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Reserved for pagination; `false` on every response. Run a new search with different filters to see other numbers.
    /// </summary>
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }

    /// <summary>
    /// Guidance returned only for `country=IN`, explaining that Indian traffic is sent from DLT-registered sender IDs rather than purchased numbers. Absent for every other country.
    /// </summary>
    [JsonPropertyName("hint")]
    public string? Hint { get; set; }

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
