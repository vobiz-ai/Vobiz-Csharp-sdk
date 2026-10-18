using Vobiz;
using Vobiz.Core;

namespace Vobiz.Sms;

[Serializable]
public record UploadDocumentRequest
{
    public required FileParameter Document { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
