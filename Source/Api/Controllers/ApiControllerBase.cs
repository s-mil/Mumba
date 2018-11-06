using Microsoft.AspNetCore.Mvc;

namespace SamMiller.Mumba.Api.Controllers
{
    [ApiController]
    [Produces("application/jason")]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    { }
}