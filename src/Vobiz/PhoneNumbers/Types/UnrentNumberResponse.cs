using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record UnrentNumberResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("cancel_url")]
    public required string CancelUrl { get; set; }

    [JsonPropertyName("cooldown_ends_at")]
    public required DateTime CooldownEndsAt { get; set; }

    [JsonPropertyName("message")]
    public required string Message { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("release_fee")]
    public required double ReleaseFee { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
