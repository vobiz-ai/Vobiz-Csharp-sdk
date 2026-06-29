using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record PlayAudioCallRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonIgnore]
    public required string CallUuid { get; set; }

    [JsonPropertyName("urls")]
    public required string Urls { get; set; }

    [JsonPropertyName("legs")]
    public PlayAudioCallRequestLegs? Legs { get; set; }

    [JsonPropertyName("loop")]
    public bool? Loop { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
