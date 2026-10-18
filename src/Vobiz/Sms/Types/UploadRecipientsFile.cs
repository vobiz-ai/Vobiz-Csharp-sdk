using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A recipient file upload. Every column other than the phone column becomes a template variable named after its header.
/// </summary>
[Serializable]
public record UploadRecipientsFile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A `.csv` or `.xlsx` file of at most 10 MB and 10,000 recipients. The phone column is detected from its header (`phone`, `mobile`, `msisdn`, `number`, `to`, `phonenumber` and similar), otherwise the first column is used. Files without a header get the columns `phone`, `column2`, `column3` and so on; CSV delimiters `,`, `;` and tab are detected, and for XLSX the first sheet is read.
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code, matched case-insensitively, used to normalise numbers that have no country code. Defaults to `US`.
    /// </summary>
    [JsonPropertyName("defaultCountry")]
    public UploadRecipientsFileDefaultCountry? DefaultCountry { get; set; }

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
