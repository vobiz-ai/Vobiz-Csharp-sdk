using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// One recipient of a broadcast: the normalised number, the variables from its upload row and the state of its message.
/// </summary>
[Serializable]
public record BroadcastRecipient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Numeric identifier of the recipient within Vobiz. Used in the broadcast's per-recipient idempotency key.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Where the recipient came from in the upload. For a file it is the line number in the file, so with a header line the first data row is `2`; for a JSON `numbers` array it is the 1-based position.
    /// </summary>
    [JsonPropertyName("row")]
    public int? Row { get; set; }

    /// <summary>
    /// The recipient's number, normalised to E.164.
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>
    /// Every column value from the recipient's upload row, keyed by the column name as written in your header, including the phone column. Used to fill the template. Only the phone column is present for JSON uploads.
    /// </summary>
    [JsonPropertyName("variables")]
    public Dictionary<string, string>? Variables { get; set; }

    /// <summary>
    /// The recipient's send state: `pending`, `sending`, `sent`, `delivered`, `failed`, `opted_out` (excluded because the number opted out of SMS from you) or `skipped` (still pending when the broadcast was cancelled).
    /// </summary>
    [JsonPropertyName("status")]
    public BroadcastRecipientStatus? Status { get; set; }

    /// <summary>
    /// The `id` of the message sent to this recipient; look it up with `GET /messages/{id}`. Empty string until the message is sent.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    /// <summary>
    /// Why the send failed: the message's `errorCode`, or `send_failed` / `routing_failed`. Empty string unless `status` is `failed`.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Human-readable detail for a failed send. Empty string unless `status` is `failed`.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// When the message to this recipient was sent (ISO 8601, UTC). `null` until then.
    /// </summary>
    [JsonPropertyName("sentAt")]
    public DateTime? SentAt { get; set; }

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
