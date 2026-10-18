using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record UploadRecipientsJson
{
    /// <summary>
    /// The broadcast's `id` (UUID), as returned by `POST /broadcasts` or `GET /broadcasts`. An id that is not a UUID, or that belongs to another account, returns `404` with `broadcast not found`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// Phone numbers, one per recipient, up to 10,000. Numbers without a country code are normalised with `defaultCountry`. An empty array clears the list.
    /// </summary>
    [JsonPropertyName("numbers")]
    public IEnumerable<string> Numbers { get; set; } = new List<string>();

    /// <summary>
    /// ISO 3166-1 alpha-2 country code, matched case-insensitively, used to normalise numbers that have no country code. Defaults to `US`.
    /// </summary>
    [JsonPropertyName("defaultCountry")]
    public UploadRecipientsJsonDefaultCountry? DefaultCountry { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
