namespace Vobiz;

public partial interface IIpAccessControlListClient
{
    /// <summary>
    /// Add an IP access control rule to restrict SIP trunk access.
    ///
    /// Use the public IP address or CIDR range of your own SBC or PBX. The API
    /// rejects documentation-only ranges such as `203.0.113.0/24` with `400`.
    /// Responses return the rule's label in `description`.
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
