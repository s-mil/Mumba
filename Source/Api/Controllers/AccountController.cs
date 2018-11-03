using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Api.Infrastructure.Data.Repositories;
using SamMiller.Mumba.Api.Models.Requests;

namespace SamMiller.Mumba.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest model, [FromServices] UserRepository userRepository)
        {
            try
            {
                await userRepository.CreateAsync(model.Username, model.Password);

                return Ok();
            }
            catch (CreateUserException exception)
            {
                return BadRequest(exception.Message);
            }
        }


    }
}