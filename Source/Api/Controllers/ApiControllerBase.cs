using Microsoft.AspNetCore.Mvc;

namespace SamMiller.Mumba.Api.Controllers
{
    /// <summary>
    /// Defines the controller for api endpoints
    /// </summary>
    [ApiController]
    [Produces("application/jason")]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    { }
}