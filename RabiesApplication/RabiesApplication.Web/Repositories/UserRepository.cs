using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class UserRepository : ModelRepository<ApplicationUser>
    {
        public UserRepository() { }

        public string GetUserID(IPrincipal user)
        {
            // get claims identity to retrieve app user's id
            var identity = user.Identity as ClaimsIdentity;
            if (identity == null || !identity.HasClaim(c => c.Type == ClaimTypes.NameIdentifier)) return null;

            // user app user's id to fetch app user record with related employee and organization records
            return identity.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }

        public ApplicationUser GetAppUserForPrincipal(IPrincipal user)
        {
            var userId = GetUserID(user);
            return All().Where(u => u.Id == user).Include("Employee.Organization").Single();
        }
    }
}
