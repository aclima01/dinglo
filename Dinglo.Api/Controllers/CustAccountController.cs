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
    public class CustAccountController : BaseController
    {
        public CustAccountController() : base()
        {
        }

        [HttpPost, Route("create")]
        // POST api/create
        public IActionResult Create([FromBody] CreateCustAccountCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpPut, Route("update")]
        // POST api/create
        public IActionResult Update([FromBody] UpdateCustAccountCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpDelete, Route("delete")]
        // POST api/create
        public IActionResult Delete([FromBody] DeleteCustAccountCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpGet, Route("getby")]
        // GET api/getall
        public IActionResult GetById([FromQuery] Guid id, [FromServices] ICustAccountRepository repository)
        {
            try
            {
                var result = repository.GetById(id);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return ExceptionResult(null, exception);
            }
        }

        [HttpGet, Route("getall")]
        // GET api/getall
        public IActionResult GetAll([FromServices] ICustAccountRepository repository)
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

        [HttpGet, Route("contact")]
        // GET api/getall
        public IActionResult GetContactsByCustId([FromQuery] Guid custId, [FromServices] ICustAccountRepository repository)
        {
            try
            {
                var result = repository.GetCustContacts(custId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return ExceptionResult(null, exception);
            }
        }

        [HttpPost, Route("contact/create")]
        // POST api/create
        public IActionResult CreateContact([FromBody] CreateCustContactCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpPut, Route("contact/update")]
        // POST api/create
        public IActionResult UpdateContact([FromBody] UpdateCustContactCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpDelete, Route("contact/delete")]
        // POST api/create
        public IActionResult DeleteContact([FromBody] DeleteCustContactCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpGet, Route("addresses")]
        // GET api/getall
        public IActionResult GetAddressesByCustId([FromQuery] Guid custId, [FromServices] ICustAccountRepository repository)
        {
            try
            {
                var result = repository.GetCustAddresses(custId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return ExceptionResult(null, exception);
            }
        }

        [HttpPost, Route("address/create")]
        // POST api/create
        public IActionResult CreateAddress([FromBody] CreateCustAddressCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpPut, Route("address/update")]
        // POST api/create
        public IActionResult UpdateAddress([FromBody] UpdateCustAddressCommand command, [FromServices] CustAccountHandler handler)
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

        [HttpDelete, Route("address/delete")]
        // POST api/create
        public IActionResult DeleteAddress([FromBody] DeleteCustAddressCommand command, [FromServices] CustAccountHandler handler)
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
    }
}