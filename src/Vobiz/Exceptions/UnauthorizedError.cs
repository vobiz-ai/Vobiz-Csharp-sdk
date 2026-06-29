namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("UnauthorizedError", 401, body, rawResponse: rawResponse);
