using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dinglo.Domain.Authorizations
{
    public static class AuthUserExtension
    {
        public static async Task<bool> UserExists<TUser>(this UserManager<TUser> userManager, string userName) 
            where TUser : IdentityUser
        {
            return await userManager.FindByNameAsync(userName) != null;
        }
    }
}