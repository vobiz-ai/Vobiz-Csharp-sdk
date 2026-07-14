using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetConferenceResponseConferenceMemberCountMembersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("muted")]
    public bool? Muted { get; set; }

    [JsonPropertyName("member_id")]
    public string? MemberId { get; set; }

    [JsonPropertyName("deaf")]
    public bool? Deaf { get; set; }

    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("to")]
    public string? To { get; set; }

    [JsonPropertyName("caller_name")]
    public string? CallerName { get; set; }

    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    [JsonPropertyName("call_uuid")]
    public string? CallUuid { get; set; }

    [JsonPropertyName("join_time")]
    public string? JoinTime { get; set; }

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
