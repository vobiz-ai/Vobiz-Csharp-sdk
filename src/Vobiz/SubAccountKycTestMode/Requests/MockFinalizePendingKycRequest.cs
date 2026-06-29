using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record MockFinalizePendingKycRequest
{
    /// <summary>
    /// The sub-account's Auth ID.
    /// </summary>
    [JsonIgnore]
    public required string SubAuthId { get; set; }

    [JsonPropertyName("verification_type")]
    public required MockFinalizePendingKycRequestVerificationType VerificationType { get; set; }

    [JsonPropertyName("outcome")]
    public required MockFinalizePendingKycRequestOutcome Outcome { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
