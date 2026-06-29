namespace Vobiz;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class VobizApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
