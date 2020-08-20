using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Example.Core.DTOs;
using Example.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILoggerAdapter<UsersController> _logger;

        public UsersController(
            IUserService service,
            ILoggerAdapter<UsersController> logger
        )
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/Users/?emailAddress=bill@gates.com
        /// <summary>
        /// Get a user by their email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(UserResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get([EmailAddress][Required] string? emailAddress)
        {
            try
            {
                var result = await _service.Get(emailAddress);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return BadRequest("Unable to return User");
        }
    }
}
