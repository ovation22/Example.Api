using System;
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

        // GET: api/Users/5
        /// <summary>
        /// Get a user by their UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResult), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);

            return Ok(result);
        }
    }
}
