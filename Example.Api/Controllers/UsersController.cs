using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Example.Core.DTOs;
using Example.Core.Exceptions;
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
        public async Task<IActionResult> Get([EmailAddress][Required(AllowEmptyStrings = false)] string emailAddress)
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

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(NewUser user)
        {
            try
            {
                await _service.Create(user);

                return Accepted();
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);

                return BadRequest(ex.Message);
            }
            catch (UserEmailAlreadyCreatedException ex)
            {
                _logger.LogError(ex, ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return BadRequest("Unable to create User");
        }
    }
}
