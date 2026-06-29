namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("BadRequestError", 400, body, rawResponse: rawResponse);
