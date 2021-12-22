using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Dinglo.Domain.Commands;
using Dinglo.Domain.Entities.Account;
using System;
using System.Linq;
using Flunt.Notifications;

namespace Dinglo.Api.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
           
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResult(GenericCommandResult result, [FromServices] Notifiable handler)
        {
            if (!result.Success || handler.Notifications.Any())
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResult(GenericCommandResult result)
        {
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return StatusCode(result.StatusCode, result);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ExceptionResult(string body, Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Guid GetUserLoggedId()
        {
            var userClaims = User.Claims.Select(c =>
                new
                {
                    Type = c.Type,
                    Value = c.Value
                }).ToList();

            var userId = userClaims.Where(wh => wh.Type.ToLower().Contains("nameidentifier")).FirstOrDefault().Value;

            return new Guid(userId.ToString());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetUserLoggedEmail()
        {
            var userClaims = User.Claims.Select(c =>
                new
                {
                    Type = c.Type,
                    Value = c.Value
                }).ToList();

            var userEmail = userClaims.Where(wh => wh.Type.ToLower().Contains("emailaddress")).FirstOrDefault().Value;

            return userEmail.ToString();
        }
    }
}
