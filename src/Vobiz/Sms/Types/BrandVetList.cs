using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One page of the brand's vetting records from the US 10DLC registry.
/// </summary>
[Serializable]
public record BrandVetList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Vetting records on this page, passed through from the registry as received. Empty when the brand has never been vetted.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<Dictionary<string, object?>>? Results { get; set; }

    /// <summary>
    /// Where this page sits in the full result set.
    /// </summary>
    [JsonPropertyName("paging")]
    public BrandVetPaging? Paging { get; set; }

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
