using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using Vobiz.Core;

namespace Vobiz;

[Serializable]
public record ListSubaccountsResponseSubAccountsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public object? Phone { get; set; }

    [JsonPropertyName("description")]
    public object? Description { get; set; }

    [JsonPropertyName("permissions")]
    public required OneOf<
        object?,
        ListSubaccountsResponseSubAccountsItemPermissionsCalls
    > Permissions { get; set; }

    [JsonPropertyName("rate_limit")]
    public required int RateLimit { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("parent_account_id")]
    public required string ParentAccountId { get; set; }

    [JsonPropertyName("parent_auth_id")]
    public required string ParentAuthId { get; set; }

    [JsonPropertyName("auth_id")]
    public required string AuthId { get; set; }

    [JsonPropertyName("auth_token")]
    public required string AuthToken { get; set; }

    [JsonPropertyName("api_id")]
    public required string ApiId { get; set; }

    [JsonPropertyName("email_verified")]
    public required bool EmailVerified { get; set; }

    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("created")]
    public required string Created { get; set; }

    [JsonPropertyName("modified")]
    public required string Modified { get; set; }

    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("last_used")]
    public string? LastUsed { get; set; }

    [JsonPropertyName("account")]
    public required string Account { get; set; }

    [JsonPropertyName("resource_uri")]
    public required string ResourceUri { get; set; }

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
