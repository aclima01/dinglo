using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Repositories;

namespace Dinglo.Domain.Authorizations
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _usuarioRepository;

        public UserContext(IHttpContextAccessor httpContextAccessor, IUserRepository usuarioRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _usuarioRepository = usuarioRepository;
        }
        
        public AppUser GetUserLoggedin()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var usuario = _usuarioRepository.GetUsuarioByIdentity(id);
            
            return usuario;
        }
    }
}