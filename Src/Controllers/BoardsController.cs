
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Data;
using SamMiller.Mumba.Models;
using Microsoft.EntityFrameworkCore;
using SamMiller.Mumba.Models.BoardViewModels;
using System;
using System.Linq;

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
        /// Gets all boards
        /// </summary>
        /// <returns>A list of all technicians</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            string uId =  _userManager.GetUserAsync(User).Id.ToString();
            var Boards = await _context.Boards.Where(Board => Board.UserId == uId ).ToListAsync();
            return View(Boards);
        }
        /// <summary>
        /// Opens a board
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            var tasks = await _context.Tasks.Where(task => task.BoardId == id.ToString()).ToListAsync();
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