using Vobiz;

namespace Vobiz.Sms;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("ServiceUnavailableError", 503, body, rawResponse: rawResponse);
