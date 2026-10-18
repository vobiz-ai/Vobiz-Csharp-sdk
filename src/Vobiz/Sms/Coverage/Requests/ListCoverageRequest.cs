using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record ListCoverageRequest
{
    /// <summary>
    /// Search text, case-insensitive. Matches a substring of the country name (`united`), an exact ISO 3166-1 alpha-2 code (`GB`) or the start of the dial code (`44` or `+44`); spaces and a leading `+` are ignored.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Exact region name, case-insensitive, for example `Northern America`, `Western Europe` or `South-central Asia`. Partial names match nothing; read the `region` values from an unfiltered list to see the full set.
    /// </summary>
    [JsonIgnore]
    public string? Region { get; set; }

    /// <summary>
    /// `true` returns only countries where recipients can reply; `false` returns the rest, including countries where two-way support is unknown. Also accepts `1`/`0` and `t`/`f`; any other value returns `400` with `twoWay must be true or false`.
    /// </summary>
    [JsonIgnore]
    public bool? TwoWay { get; set; }

    /// <summary>
    /// `true` returns countries that require sender registration for local or international traffic; `false` returns countries that require neither. Accepts the same values as `twoWay`; anything else returns `400` with `registrationRequired must be true or false`.
    /// </summary>
    [JsonIgnore]
    public bool? RegistrationRequired { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
