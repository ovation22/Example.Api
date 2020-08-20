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

        public UsersController(
            IUserService service
        )
        {
            _service = service;
        }

        // GET: api/Users/?emailAddress=bill@gates.com
        /// <summary>
        /// Get a user by their email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(UserResult), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get([EmailAddress] string emailAddress)
        {
            var result = await _service.Get(emailAddress);

            return Ok(result);
        }
    }
}
