using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One page of broadcasts, newest first, with the total count for paging.
/// </summary>
[Serializable]
public record BroadcastList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The broadcasts on this page, newest first. Empty when `offset` is past the end.
    /// </summary>
    [JsonPropertyName("broadcasts")]
    public IEnumerable<Broadcast>? Broadcasts { get; set; }

    /// <summary>
    /// Number of broadcasts on your account across all pages. Page until `offset` reaches this value.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

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
