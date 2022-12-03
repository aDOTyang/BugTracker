using System.Security.Claims;
using System.Security.Principal;

namespace BugTracker.Extensions
{
    public static class IdentityExtensions
    {
        // "this" attaches the method to whatever follows - IIdentity in this case
        public static int GetCompanyId(this IIdentity identity)
        {
            // only implemented in User
            // cast the incoming identity as type ClaimsIdentity
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyId")!;
            return int.Parse(claim.Value);
        }
    }
}
