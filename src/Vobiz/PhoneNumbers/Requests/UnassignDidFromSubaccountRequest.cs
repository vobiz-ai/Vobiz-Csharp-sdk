using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record UnassignDidFromSubaccountRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// The number in E.164, URL-encoded (use %2B instead of +).
    /// </summary>
    [JsonIgnore]
    public required string E164 { get; set; }

    /// <summary>
    /// Admin-only cool-off bypass. Requires an admin-role account
    /// (enforced at the gateway) and writes a `did_assignment_audit` row.
    /// </summary>
    [JsonIgnore]
    public bool? Force { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
