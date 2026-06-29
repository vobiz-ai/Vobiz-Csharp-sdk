using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListEndpointsRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public int? Offset { get; set; }

    [JsonIgnore]
    public string? UsernameContains { get; set; }

    [JsonIgnore]
    public string? UsernameExact { get; set; }

    [JsonIgnore]
    public string? UsernameStartswith { get; set; }

    [JsonIgnore]
    public string? AliasContains { get; set; }

    [JsonIgnore]
    public string? AliasExact { get; set; }

    [JsonIgnore]
    public int? ApplicationIdExact { get; set; }

    [JsonIgnore]
    public bool? ApplicationIdIsnull { get; set; }

    [JsonIgnore]
    public string? SubAccount { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
