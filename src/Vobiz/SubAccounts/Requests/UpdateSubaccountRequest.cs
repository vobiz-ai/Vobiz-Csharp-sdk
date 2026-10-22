using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record UpdateSubaccountRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string SubAuthId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Set to `false` to deactivate the sub-account. A deactivated sub-account no longer appears in list, retrieve, update or delete requests (`404`).
    /// </summary>
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Accepted but has no effect. Use `is_active` instead.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Change the verification mode. Promoting to `customer_use` requires the sub-account to have an `email`.
    /// </summary>
    [JsonPropertyName("kyc_mode")]
    public UpdateSubaccountRequestKycMode? KycMode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
