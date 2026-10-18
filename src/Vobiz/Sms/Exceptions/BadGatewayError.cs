using Vobiz;

namespace Vobiz.Sms;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadGatewayError(object body, Vobiz.RawResponse? rawResponse = null)
    : VobizApiApiException("BadGatewayError", 502, body, rawResponse: rawResponse);
