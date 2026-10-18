using global::System.Text.Json.Serialization;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record GetDocumentRequest
{
    /// <summary>
    /// The `documentId` (UUID) returned by `POST /10dlc/documents`, not the record `id`. A value that is not a UUID, or a document that is not on your account, returns `404` with `{"error":"document not found"}`.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
