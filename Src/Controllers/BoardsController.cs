
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Data;
using SamMiller.Mumba.Models;

namespace SamMiller.Mumba.Controllers
{
    public class BoardsController : Controller
    {
        private MumbaContext _context;

        private UserManager<AppUser> _userManager;

        public BoardsController(MumbaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery])
        {
            var boards = await _context.Boards;
                
        }
    }
}