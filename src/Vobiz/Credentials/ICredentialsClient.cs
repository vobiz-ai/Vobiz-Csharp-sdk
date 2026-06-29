namespace Vobiz;

public partial interface ICredentialsClient
{
    /// <summary>
    /// Create SIP credentials for trunk authentication.
    /// </summary>
    WithRawResponseTask<CreateCredentialResponse> CreateCredentialAsync(
        CreateCredentialRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all SIP credentials on the account.
    /// </summary>
    WithRawResponseTask<ListCredentialsResponse> ListCredentialsAsync(
        ListCredentialsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the password for an existing SIP credential.
    /// </summary>
    WithRawResponseTask<UpdateCredentialResponse> UpdateCredentialAsync(
        UpdateCredentialRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an existing SIP credential.
    /// </summary>
    WithRawResponseTask<string?> DeleteCredentialAsync(
        DeleteCredentialRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
