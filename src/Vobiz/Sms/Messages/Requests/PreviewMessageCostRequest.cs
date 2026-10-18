using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record PreviewMessageCostRequest
{
    /// <summary>
    /// Required. The sender you plan to use: one of your numbers in E.164 format, or the `senderName` of your RCS sender when `channel` is `rcs`. It determines the route the message is priced on.
    /// </summary>
    [JsonIgnore]
    public required string From { get; set; }

    /// <summary>
    /// Required. One recipient number in E.164 format, for example `+14155550123`. Its destination country determines the price.
    /// </summary>
    [JsonIgnore]
    public required string To { get; set; }

    /// <summary>
    /// Channel to price: `sms`, `mms` or `rcs`. Defaults to `sms`.
    /// </summary>
    [JsonIgnore]
    public PreviewMessageCostRequestChannel? Channel { get; set; }

    /// <summary>
    /// The message body to segment and price, URL-encoded. Pass the exact text you plan to send: the segment count depends on its length and on whether it fits the GSM-7 character set. Defaults to an empty string.
    /// </summary>
    [JsonIgnore]
    public string? Text { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
