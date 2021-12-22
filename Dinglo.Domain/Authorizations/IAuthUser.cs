using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dinglo.Domain.Entities.Account;
using NetDevPack.Identity.Jwt.Model;

namespace Dinglo.Domain.Authorizations
{
    public interface IAuthUser
    {
        Task<bool> CreateDefaultUserAdmin(string userName, string email, string password);
        Task<UserResponse<string>> LoginAsync(LoginRequest loginUser);
        Task<UserResponse<string>> UserRepointAsync(Guid userIdentityId, string role ,Int32? Value);
        Task<UserResponse<string>> RefreshToken(string userIdentityId);
        Task<UserIdentity> CreateUser(string userName, string email, string password, List<string> roles);
        Task DeleteUser(string userId);
    }
}