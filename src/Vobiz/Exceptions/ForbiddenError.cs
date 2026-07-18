namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("ForbiddenError", 403, body, rawResponse: rawResponse);
