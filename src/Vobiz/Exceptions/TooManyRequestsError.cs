namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooManyRequestsError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("TooManyRequestsError", 429, body, rawResponse: rawResponse);
