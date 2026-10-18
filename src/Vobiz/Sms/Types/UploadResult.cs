using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Summary of a recipient upload. The upload replaces the broadcast's previous recipient list.
/// </summary>
[Serializable]
public record UploadResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Rows read from the file or array, excluding the header line.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Rows with a valid, unique number that were stored as recipients, including opted-out numbers.
    /// </summary>
    [JsonPropertyName("valid")]
    public int? Valid { get; set; }

    /// <summary>
    /// Rejected rows with the reason for each, at most the first 100. Fix them in your file and upload again.
    /// </summary>
    [JsonPropertyName("invalid")]
    public IEnumerable<InvalidRecipient>? Invalid { get; set; }

    /// <summary>
    /// Total rejected rows, including any beyond the 100 listed in `invalid`.
    /// </summary>
    [JsonPropertyName("invalidCount")]
    public int? InvalidCount { get; set; }

    /// <summary>
    /// Rows dropped because the same number appeared earlier in the upload.
    /// </summary>
    [JsonPropertyName("duplicates")]
    public int? Duplicates { get; set; }

    /// <summary>
    /// Stored rows marked `opted_out` because the number opted out of SMS from you. They count towards `valid` and are never sent.
    /// </summary>
    [JsonPropertyName("optedOut")]
    public int? OptedOut { get; set; }

    /// <summary>
    /// Column names detected in the upload, as written in your header. The first is the phone column; the rest are template variables.
    /// </summary>
    [JsonPropertyName("columns")]
    public IEnumerable<string>? Columns { get; set; }

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
