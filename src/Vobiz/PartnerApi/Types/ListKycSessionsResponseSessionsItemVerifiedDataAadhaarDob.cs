using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListKycSessionsResponseSessionsItemVerifiedDataAadhaarDob : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("pan_type")]
    public string? PanType { get; set; }

    [JsonPropertyName("pan_number")]
    public string? PanNumber { get; set; }

    [JsonPropertyName("pan_name_match")]
    public bool? PanNameMatch { get; set; }

    [JsonPropertyName("completed_steps")]
    public IEnumerable<string>? CompletedSteps { get; set; }

    [JsonPropertyName("pan_registered_name")]
    public string? PanRegisteredName { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("aadhaar_dob")]
    public string? AadhaarDob { get; set; }

    [JsonPropertyName("aadhaar_name")]
    public string? AadhaarName { get; set; }

    [JsonPropertyName("masked_aadhaar")]
    public string? MaskedAadhaar { get; set; }

    [JsonPropertyName("pan_name")]
    public string? PanName { get; set; }

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
