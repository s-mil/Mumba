
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Data;
using SamMiller.Mumba.Models;
using Microsoft.EntityFrameworkCore;

namespace SamMiller.Mumba.Controllers
{
    /// <summary>
    /// Controller for managing boards
    /// </summary>
    [Authorize]
    public class BoardsController : Controller
    {
        private MumbaContext _context;

        private UserManager<AppUser> _userManager;

        public BoardsController(MumbaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets all technicians
        /// </summary>
        /// <returns>A list of all technicians</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Boards = await _context.Boards.ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
             var boards = _context.Boards;

            return View();
        }
    }
}