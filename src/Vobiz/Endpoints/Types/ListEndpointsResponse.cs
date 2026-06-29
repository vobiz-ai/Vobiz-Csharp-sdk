using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListEndpointsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    [JsonPropertyName("meta")]
    public required ListEndpointsResponseMeta Meta { get; set; }

    [JsonPropertyName("objects")]
    public IEnumerable<ListEndpointsResponseObjectsItem> Objects { get; set; } =
        new List<ListEndpointsResponseObjectsItem>();

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
