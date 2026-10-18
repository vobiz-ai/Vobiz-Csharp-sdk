using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record PurchaseNumberRequest
{
    /// <summary>
    /// The number to buy, in E.164 format, exactly as returned in `e164` by `GET /numbers/available`. Required.
    /// </summary>
    [JsonPropertyName("e164")]
    public required string E164 { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the number's country, for example `US`. Required, and must match the number; a mismatch returns `400`.
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; set; }

    /// <summary>
    /// The `numberKey` from `GET /numbers/available`. Required when the search result has a non-empty `numberKey`, as for `CA` and `GB` numbers; omit it for US numbers, which are bought by `e164` alone.
    /// </summary>
    [JsonPropertyName("numberKey")]
    public string? NumberKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
