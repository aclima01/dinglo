using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dinglo.Domain.Commands;
using Dinglo.Domain.Handlers;
using Dinglo.Domain.Repositories;
using Dinglo.Api.Controllers;

namespace Uniodonto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        public UserController() : base()
        {
        }

        [HttpPost, Route("create")]
        // POST api/create
        public IActionResult Create([FromBody] CreateAppUserCommand command, [FromServices] AppUserHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)handler.Handle(command);

                return GetResult(result, handler);
            }
            catch (Exception exception)
            {
                return ExceptionResult(JsonConvert.SerializeObject(command), exception);
            }
        }

        [HttpGet, Route("getall")]
        // GET api/getall
        public IActionResult GetAll([FromServices] IUserRepository repository)
        {
            try
            {
                var result = repository.GetAll();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return ExceptionResult(null, exception);
            }
        }

        [HttpGet, Route("getby")]
        // GET api/getby?custId=X
        public IActionResult GetByCustomerId([FromQuery] string custId,[FromServices] IUserRepository repository)
        {
            try
            {
                var result = repository.GetByCustomer(custId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return ExceptionResult(null, exception);
            }
        }

        [HttpGet, Route("me")]
        // GET api/getby?custId=X
        public IActionResult GetMe([FromServices] IUserRepository repository)
        {
            try
            {
                var id = GetUserLoggedId().ToString();

                var user = new
                {
                    user = repository.Me(id)
                };

                return Ok(user);
            }
            catch (Exception exception)
            {
                return ExceptionResult(null, exception);
            }
        }
    }
}