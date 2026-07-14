using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetConferenceResponseError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("error")]
    public required GetConferenceResponseErrorError Error { get; set; }

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

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
