namespace Vobiz;

public partial interface IIpAccessControlListClient
{
    /// <summary>
    /// Add an IP access control rule to restrict SIP trunk access.
    /// </summary>
    WithRawResponseTask<CreateIpAclResponse> CreateIpAclAsync(
        CreateIpAclRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all IP access control rules on the account.
    /// </summary>
    WithRawResponseTask<ListIpAclsResponse> ListIpAclsAsync(
        ListIpAclsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing IP access control rule.
    /// </summary>
    WithRawResponseTask<UpdateIpAclResponse> UpdateIpAclAsync(
        UpdateIpAclRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an IP access control rule.
    /// </summary>
    WithRawResponseTask<string?> DeleteIpAclAsync(
        DeleteIpAclRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
