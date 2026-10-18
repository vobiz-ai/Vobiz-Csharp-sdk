using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Sender registration requirements for a destination country. The text fields are free-form and may prefix values with `LOCAL:` or `INTERNATIONAL:` when they differ by traffic type.
/// </summary>
[Serializable]
public record CoverageRegistration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether senders must be registered before sending, for local and international traffic.
    /// </summary>
    [JsonPropertyName("required")]
    public LocalIntl? Required { get; set; }

    /// <summary>
    /// Typical registration lead time as published for the country, for example `LOCAL: +20`. Free text; `null` when not published.
    /// </summary>
    [JsonPropertyName("durationDays")]
    public string? DurationDays { get; set; }

    /// <summary>
    /// Information you must supply to register a sender, for example sample messages. `null` when not published.
    /// </summary>
    [JsonPropertyName("informationRequired")]
    public string? InformationRequired { get; set; }

    /// <summary>
    /// Documents you must supply to register a sender, for example a letter of authorization. `null` when not published.
    /// </summary>
    [JsonPropertyName("documentsRequired")]
    public string? DocumentsRequired { get; set; }

    /// <summary>
    /// Additional steps that apply to alphanumeric sender IDs, such as DLT registration in India. `null` when none.
    /// </summary>
    [JsonPropertyName("alphanumericExtraSteps")]
    public string? AlphanumericExtraSteps { get; set; }

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
