namespace Vobiz;

public partial interface IDtmfClient
{
    /// <summary>
    /// Send DTMF (keypad) tones on an active call. Use `w` for 0.5s pause, `W` for 1s pause.
    /// </summary>
    WithRawResponseTask SendDtmfAsync(
        SendDtmfRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
