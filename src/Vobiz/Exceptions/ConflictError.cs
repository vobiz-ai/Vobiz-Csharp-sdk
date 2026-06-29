namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("ConflictError", 409, body, rawResponse: rawResponse);
