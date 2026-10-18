using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record GetWebhookRequest
{
    /// <summary>
    /// The subscription `id` (UUID) returned when you created it or by `GET /webhooks`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
