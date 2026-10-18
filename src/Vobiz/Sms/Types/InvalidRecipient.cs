using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// A row that was rejected during a recipient upload and not stored.
/// </summary>
[Serializable]
public record InvalidRecipient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Where the row came from: the line number in the file (the header is line 1), or the 1-based position in a JSON `numbers` array.
    /// </summary>
    [JsonPropertyName("row")]
    public int? Row { get; set; }

    /// <summary>
    /// The phone value exactly as it appeared in the row. Empty when the phone cell was blank.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// Why the number was rejected: `missing phone number` (blank cell), `contains letters or symbols`, `too short`, `too long`, `not a valid US/Canada number`, `not a valid Indian mobile number` or `unsupported defaultCountry`.
    /// </summary>
    [JsonPropertyName("reason")]
    public InvalidRecipientReason? Reason { get; set; }

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
