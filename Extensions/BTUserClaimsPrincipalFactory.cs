using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BugTracker.Extensions
{
    public class BTUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<BTUser, IdentityRole>
    {
        // ClaimsFactory runs at login
        // private readonly not needed as only constructor needs access to variables
        // :base allows parent access so that this extension does not interfere with UserClaimsPrincipalFactory typical functionality
        public BTUserClaimsPrincipalFactory(UserManager<BTUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        // protected - only child and parent can see this method
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(BTUser user)
        {
            // original functionality
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);

            // additional functionality to capture user's companyId
            identity.AddClaim(new Claim("CompanyId",user.CompanyId.ToString()));
            return identity;
        }
    }
}
