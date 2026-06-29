namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("NotFoundError", 404, body, rawResponse: rawResponse);
