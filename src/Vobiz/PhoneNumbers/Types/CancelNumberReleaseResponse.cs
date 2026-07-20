using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CancelNumberReleaseResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("message")]
    public required string Message { get; set; }

    [JsonPropertyName("status")]
    public required CancelNumberReleaseResponseStatus Status { get; set; }

    [JsonPropertyName("refund_status")]
    public required CancelNumberReleaseResponseRefundStatus RefundStatus { get; set; }

    /// <summary>
    /// Present when the refund could not be processed.
    /// </summary>
    [JsonPropertyName("refund_error")]
    public string? RefundError { get; set; }

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
