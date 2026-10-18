using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record SearchAvailableNumbersRequest
{
    /// <summary>
    /// Country to search, as an ISO 3166-1 alpha-2 code such as `US`, `CA` or `GB`. Case-insensitive. A value that is not two letters returns `400` with `country must be an ISO 3166-1 alpha-2 code`.
    /// </summary>
    [JsonIgnore]
    public required string Country { get; set; }

    /// <summary>
    /// Comma-separated capabilities the number must have: `SMS`, `MMS`, or `SMS,MMS`. Case-insensitive, defaults to `SMS`. Any other value returns `400` with `capabilities must be SMS and/or MMS`.
    /// </summary>
    [JsonIgnore]
    public string? Capabilities { get; set; }

    /// <summary>
    /// Three-digit area code to search in, for example `415`. Accepted only when `country` is `US` or `CA`; other countries return `400` with `areaCode is only supported for US and CA`.
    /// </summary>
    [JsonIgnore]
    public string? AreaCode { get; set; }

    /// <summary>
    /// Maximum number of results, from `1` to `100`. Defaults to `10`, and each search returns at most 10 numbers whatever you pass. A value outside the range returns `400` with `limit must be between 1 and 100`.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
