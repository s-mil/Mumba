using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Api.Infrastructure.Data.Repositories;
using SamMiller.Mumba.Api.Models.Requests;

namespace SamMiller.Mumba.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ApiControllerBase
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="registerUserRequest"></param>
        /// <param name="userRepository"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest registerUserRequest, [FromServices] UserRepository userRepository)
        {
            try
            {
                await userRepository.CreateAsync(registerUserRequest.Username, registerUserRequest.Password);

                return Ok();
            }
            catch (CreateUserException exception)
            {
                return BadRequest(exception.Message);
            }
        }


    }
}