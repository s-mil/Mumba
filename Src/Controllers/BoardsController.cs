
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
            return View(Boards);
        }
        /// <summary>
        /// Opens a board
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Open()
        {
            var boards = await _context.Boards.ToListAsync();
            var tasks = _context.Tasks.ToListAsync();
            return View();
        }

        /// <summary>
        /// Serves the add board page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// Handles the creation of a new board
        /// </summary>
        /// <param name="board"> A board construct</param>
        /// <param name="signInManager">The currently active user</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Board board, [FromServices] SignInManager<AppUser> signInManager)
        {
            Board newBoard = new Board(((await _userManager.GetUserAsync(User)).Id), board.Title);

            await _context.AddAsync(newBoard);
            return View("All");


        }
    }
}