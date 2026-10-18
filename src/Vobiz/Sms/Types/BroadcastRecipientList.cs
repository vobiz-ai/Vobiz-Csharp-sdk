using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One page of a broadcast's recipients, in upload order, with the count that matches your filter.
/// </summary>
[Serializable]
public record BroadcastRecipientList : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The recipients on this page, in upload order.
    /// </summary>
    [JsonPropertyName("recipients")]
    public IEnumerable<BroadcastRecipient>? Recipients { get; set; }

    /// <summary>
    /// Number of recipients that match the `status` filter across all pages, or all recipients when you pass no filter.
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
