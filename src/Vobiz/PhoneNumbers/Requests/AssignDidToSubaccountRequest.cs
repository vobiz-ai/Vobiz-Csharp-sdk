using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record AssignDidToSubaccountRequest
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

    [JsonPropertyName("sub_account_id")]
    public required string SubAccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
