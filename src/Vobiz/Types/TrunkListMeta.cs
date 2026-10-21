using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

/// <summary>
/// Pagination metadata returned in the `meta` object of the trunk, credential, IP ACL and origination URI list endpoints.
/// </summary>
[Serializable]
public record TrunkListMeta : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Maximum number of items in `objects` for this response.
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    /// <summary>
    /// Zero-based position of the first item in `objects`.
    /// </summary>
    [JsonPropertyName("offset")]
    public required int Offset { get; set; }

    /// <summary>
    /// Total number of items on the account.
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

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
