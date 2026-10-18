using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

/// <summary>
/// Broadcast fields you can change on a draft. Every field is optional; fields you leave out keep their value, and the same validation as create applies.
/// </summary>
[Serializable]
public record BroadcastUpdateInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A label for the broadcast in the console and in listings, 1 to 255 characters. Required on create; on update it cannot be set to an empty string.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The sender every message goes out from: an SMS number on your account in E.164 format, a short code of up to 8 digits, or an alphanumeric sender ID of 1 to 11 letters, digits and spaces that starts with a letter or digit. Spaces, hyphens and brackets in phone numbers are removed before storing. Launch checks that a phone-number sender is an SMS number on your account. Required on create.
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>
    /// The channel the broadcast sends on. Broadcasts send SMS, so the only value is `sms` (matched case-insensitively), which is also the default.
    /// </summary>
    [JsonPropertyName("channel")]
    public BroadcastUpdateInputChannel? Channel { get; set; }

    /// <summary>
    /// Message body, up to 5,000 characters, with `{{variable}}` placeholders filled per recipient from the columns of your upload. Placeholder names are matched case-insensitively and trimmed, so `{{ Name }}` matches a `name` column. Launch requires a non-empty template.
    /// </summary>
    [JsonPropertyName("template")]
    public string? Template { get; set; }

    /// <summary>
    /// RFC 3339 timestamp at which sending starts after you launch, for example `2026-11-01T09:00:00Z`; offsets are converted to UTC. Omit it, or pass `null` or `""`, to send as soon as you launch. On update, `null` clears a previous value.
    /// </summary>
    [JsonPropertyName("scheduledAt")]
    public DateTime? ScheduledAt { get; set; }

    /// <summary>
    /// Maximum messages sent per second while the broadcast runs, an integer from 1 to 50. Defaults to 5, and `0` also selects the default. Lower it to spread load on your own systems or replies.
    /// </summary>
    [JsonPropertyName("ratePerSecond")]
    public int? RatePerSecond { get; set; }

    /// <summary>
    /// Your own label of up to 255 characters, copied onto every message the broadcast sends so you can find them with the `tag` filter on `GET /messages`.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    /// <summary>
    /// India (TRAI DLT). The Principal Entity ID you registered on a TRAI DLT portal, up to 64 characters. Pass it when the list contains Indian numbers; it is copied onto every message.
    /// </summary>
    [JsonPropertyName("dltEntityId")]
    public string? DltEntityId { get; set; }

    /// <summary>
    /// India (TRAI DLT). The sender header ID you registered on a TRAI DLT portal, up to 64 characters. Copied onto every message.
    /// </summary>
    [JsonPropertyName("dltHeaderId")]
    public string? DltHeaderId { get; set; }

    /// <summary>
    /// India (TRAI DLT). The content template ID you registered on a TRAI DLT portal, up to 64 characters. Your template text must match the registered template with the variables filled.
    /// </summary>
    [JsonPropertyName("dltTemplateId")]
    public string? DltTemplateId { get; set; }

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
