using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One rejection recorded by a registrar for the brand.
/// </summary>
[Serializable]
public record BrandRejectionReason : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Registrar that recorded the rejection.
    /// </summary>
    [JsonPropertyName("registrar")]
    public string? Registrar { get; set; }

    /// <summary>
    /// The brand's state at that registrar when the rejection was recorded. Omitted when not reported.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// The registrar's explanation of what to fix before you register again.
    /// </summary>
    [JsonPropertyName("rejectionReason")]
    public string? RejectionReason { get; set; }

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
