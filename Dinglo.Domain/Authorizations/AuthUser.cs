using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Repositories;
using Dinglo.Domain.Authorizations;
using Dinglo.Domain.Extensions;

namespace Dinglo.Domain.Authorizations
{
    public class AuthUser : IAuthUser
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly AppJwtSettings _appJwtSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;
        public AuthUser(UserManager<UserIdentity> userManager,
                        SignInManager<UserIdentity> signInManager,
                        IOptions<AppJwtSettings> appJwtSettings,
                        RoleManager<IdentityRole> roleManager,
                        IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appJwtSettings = appJwtSettings.Value;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateDefaultUserAdmin(string userName, string email, string password)
        {
            var userExists = await _userManager.UserExists<UserIdentity>(userName);

            if (!userExists) {
                return await SaveDefaultUserAsync(userName, email, password);
            }

            return false;
        }

        public async Task<UserIdentity> CreateUser(string userName, string email, string password, List<string> roles)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
                return user;

            user = new UserIdentity
            {
                UserName = userName,
                Email = email.IsValidEmail() ? email : string.Empty,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user, password);

            foreach (var r in roles)
            {
                var role = await _roleManager.FindByNameAsync(r);

                await _userManager.AddToRoleAsync(user, role.Name);
            }

            return user;
        }

        public async Task DeleteUser(string userId)
        {
            var userIdentity = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(userIdentity);
        }

        public async Task<UserResponse<string>> LoginAsync(LoginRequest loginUser)
        {
            return await UserLoginAsync(loginUser.Username, loginUser.Password);
        }

        private async Task<UserResponse<string>> UserLoginAsync(string userName, string password, string email = "")
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);

                var userRoles = _userManager.GetRolesAsync(user).Result;

                var claimDefault = new Claim("null","");

                if (userRoles.Count == 1)
                    claimDefault = GetClaim(userRoles.FirstOrDefault(), user.Id);
                else
                    claimDefault = GetClaim(_userRepository.GetUsuarioByIdentity(user.Id).RoleDefault, user.Id);
               

                var claimsLocal = await _userManager.GetClaimsAsync(user);

                if (claimDefault.Type == "null")
                {
                    await _userManager.RemoveClaimAsync(user, claimDefault);
                    await _userManager.RemoveClaimAsync(user, claimsLocal.FirstOrDefault());
                }
                else if (claimsLocal.Count > 0)
                    await _userManager.ReplaceClaimAsync(user, claimsLocal.FirstOrDefault(), claimDefault);
                else
                    await _userManager.AddClaimAsync(user, claimDefault);

                return new JwtBuilder<UserIdentity>()
                    .WithUserManager(_userManager)
                    .WithJwtSettings(_appJwtSettings)
                    .WithEmail(string.IsNullOrWhiteSpace(email) ? userName : email)
                    .WithJwtClaims()
                    .WithUserClaims()
                    .WithUserRoles()
                    .BuildUserResponse();
            }

            throw new InvalidCredentialException("Usuário ou senha incorretos");
        }

        public Claim GetClaim(string role, string userIdentityId)
        {
            var claimDefault = new Claim("null", "");

            if (role == "SUPER")
            {
                var usuario = _userRepository.GetUsuarioByIdentity(userIdentityId);
                var userDefault = new Claim("Role", "SUPER");
                claimDefault = userDefault;
            }
            else
            {
                var usuario = _userRepository.GetUsuarioByIdentity(userIdentityId);
                var userDefault = new Claim("Role", role);
                claimDefault = userDefault;
            }

            return claimDefault;
        }

        public Task<UserResponse<string>> UserRepointAsync(Guid userIdentityId, string role, int? Value)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SaveDefaultUserAsync(string userName, string email, string password)
        {
            var defaultUser = new UserIdentity
            {
                UserName = userName,
                Email = email.IsValidEmail() ? email : string.Empty,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(defaultUser, password);

            if (result.Succeeded)
            {
                var userIdentity = await _userManager.FindByEmailAsync(userName);

                var appUser = new AppUser
                {
                    FullName = "sysadmin",
                    IdentityDocumentNr = "00100100111",
                    RoleDefault = "SUPER",
                    AspNetUserIdentity = userIdentity
                };

                _userRepository.Create(appUser);

                return await LinkRoleToUserAsync(defaultUser, "SUPER");
            }

            return result.Succeeded;
        }

        private async Task<bool> LinkRoleToUserAsync(UserIdentity user, string role)
        {
            var resultRole = await _userManager.AddToRoleAsync(user, role);

            return resultRole.Succeeded;
        }

        public async Task<UserResponse<string>> RefreshToken(string userIdentityId)
        {
            var user = await _userManager.FindByIdAsync(userIdentityId);

            var userRoles = _userManager.GetRolesAsync(user).Result;

            var claimDefault = new Claim("null", "");

            if (userRoles.Count == 1)
                claimDefault = GetClaim(userRoles.FirstOrDefault(), user.Id);
            else
                claimDefault = GetClaim(_userRepository.GetUsuarioByIdentity(user.Id).RoleDefault, user.Id);


            var claimsLocal = await _userManager.GetClaimsAsync(user);

            if (claimDefault.Type == "null")
            {
                await _userManager.RemoveClaimAsync(user, claimDefault);
                await _userManager.RemoveClaimAsync(user, claimsLocal.FirstOrDefault());
            }
            else if (claimsLocal.Count > 0)
                await _userManager.ReplaceClaimAsync(user, claimsLocal.FirstOrDefault(), claimDefault);
            else
                await _userManager.AddClaimAsync(user, claimDefault);

            return new JwtBuilder<UserIdentity>()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .WithEmail(user.Email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildUserResponse();
            

            throw new InvalidCredentialException("Não foi possível atualizar o token de autorização.");
        }
    }
}