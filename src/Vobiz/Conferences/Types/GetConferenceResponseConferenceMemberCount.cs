using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record GetConferenceResponseConferenceMemberCount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("conference_name")]
    public required string ConferenceName { get; set; }

    /// <summary>
    /// Conference runtime in seconds
    /// </summary>
    [JsonPropertyName("conference_run_time")]
    public required string ConferenceRunTime { get; set; }

    [JsonPropertyName("conference_member_count")]
    public required string ConferenceMemberCount { get; set; }

    [JsonPropertyName("members")]
    public IEnumerable<GetConferenceResponseConferenceMemberCountMembersItem> Members { get; set; } =
        new List<GetConferenceResponseConferenceMemberCountMembersItem>();

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

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
