namespace Vobiz;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("UnprocessableEntityError", 422, body, rawResponse: rawResponse);
