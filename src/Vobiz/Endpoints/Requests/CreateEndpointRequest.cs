using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record CreateEndpointRequest
{
    /// <summary>
    /// Your account Auth ID
    /// </summary>
    [JsonIgnore]
    public required string AuthId { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("password")]
    public required string Password { get; set; }

    [JsonPropertyName("alias")]
    public required string Alias { get; set; }

    /// <summary>
    /// ID of the application that handles calls from this endpoint. Application IDs are 17-digit strings; send them as JSON strings.
    /// </summary>
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>
    /// Not read by the API. Application IDs exceed the range of a JSON integer, and the endpoint is created without an application. Send `app_id` instead.
    /// </summary>
    [JsonPropertyName("application")]
    public int? Application { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
