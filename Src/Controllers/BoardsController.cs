
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Data;
using SamMiller.Mumba.Models;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Models.BoardViewModels;

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
            var tasks = await _context.Tasks.ToListAsync();
            return View(model: new BoardView{Tasks = tasks});
        }

        /// <summary>
        /// Serves the add board page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Board {UserId = _userManager.GetUserAsync(User).Id.ToString()});
        }
        /// <summary>
        /// Handles the creation of a new board
        /// </summary>
        /// <param name="board"> A board construct</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Board board)
        {
                        
             _context.Boards.Add(board);
             await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));

        }
    }
}