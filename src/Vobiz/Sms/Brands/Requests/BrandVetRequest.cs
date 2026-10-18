using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record BrandVetRequest
{
    /// <summary>
    /// Brand ID (UUID) returned by `POST /10dlc/brands`. An unknown ID, an ID from another account, or a value that is not a UUID returns `404` with `{"error":"brand not found"}`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// Kind of vet to request: `STANDARD` (the default), `ENHANCED` (a deeper review) or `POLITICAL` (for political organisations). Case-insensitive; any other value returns `400` with `invalid request: type must be one of STANDARD, ENHANCED, POLITICAL`.
    /// </summary>
    [JsonPropertyName("type")]
    public BrandVetRequestType? Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
