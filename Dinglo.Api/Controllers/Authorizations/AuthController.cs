using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dinglo.Domain.Authorizations;

namespace Dinglo.Api.Controllers.Authorizations
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthUser _authUser;

         public AuthController(IAuthUser authUser) : base()
        {
            _authUser = authUser;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginUser)
        {
            try
            {
                var result = await _authUser.LoginAsync(loginUser);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("Usuáio ou senha inválidos.");
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] LoginRequest loginUser)
        {
            try
            {
                var userId = GetUserLoggedId().ToString();
                var result = await _authUser.RefreshToken(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Usuáio ou senha inválidos.");
            }
        }
    }
}