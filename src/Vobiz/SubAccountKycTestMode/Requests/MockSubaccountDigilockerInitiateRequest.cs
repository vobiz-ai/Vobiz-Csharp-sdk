using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record MockSubaccountDigilockerInitiateRequest
{
    /// <summary>
    /// The sub-account's Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string SubAuthId { get; set; }

    [JsonPropertyName("redirect_url")]
    public required string RedirectUrl { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
