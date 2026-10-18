using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Postal address of the business. Keys are passed to the US 10DLC registry as given, so you can add any address key the registry accepts.
/// </summary>
[Serializable]
public record BrandAddress : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Street address, including number and suite.
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// City or locality.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// State, province or region; for US addresses, the two-letter state code (for example `CA`).
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// ZIP or postal code, as a string (for example `94105`).
    /// </summary>
    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
