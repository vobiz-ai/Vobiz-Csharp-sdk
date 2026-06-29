using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateSubaccountRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    /// <summary>
    /// Human-readable name for the sub-account.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Required when `kyc_mode` is `customer_use`.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Login password for the sub-account.
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// `personal_use` inherits parent KYC. `customer_use` requires
    /// the sub-account to complete its own KYC and requires `email`.
    /// </summary>
    [JsonPropertyName("kyc_mode")]
    public CreateSubaccountRequestKycMode? KycMode { get; set; }

    /// <summary>
    /// Legal constitution of the customer. Drives which KYC documents are required.
    /// </summary>
    [JsonPropertyName("business_type")]
    public CreateSubaccountRequestBusinessType? BusinessType { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
