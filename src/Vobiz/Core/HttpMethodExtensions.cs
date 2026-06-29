using global::System.Net.Http;

namespace Vobiz.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
