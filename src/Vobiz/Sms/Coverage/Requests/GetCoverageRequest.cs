using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record GetCoverageRequest
{
    /// <summary>
    /// ISO 3166-1 alpha-2 code of the destination country, for example `US`, `GB` or `IN`. Case-insensitive. Three-letter codes and dial codes return `404`.
    /// </summary>
    [JsonIgnore]
    public required string Country { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
