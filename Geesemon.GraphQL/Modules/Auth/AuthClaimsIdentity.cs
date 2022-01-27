using System.Security.Claims;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthClaimsIdentity : ClaimsIdentity
    {
        public static string DefaultIdClaimType = "Id";
    }
}
