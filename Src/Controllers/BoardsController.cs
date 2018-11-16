
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
using System.Collections;

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
        
        /// <summary>
        /// Initializes the private value _context
        /// </summary>
        /// <param name="context">The context of the user</param>
        /// <param name="userManager">The authorization middleware</param>
        public BoardsController(MumbaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets all boards belonging to the currently logged in user
        /// </summary>
        /// <returns>The view of the users boards</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            string uId = _userManager.GetUserAsync(User).Id.ToString();
            var Boards = await _context.Boards.ToListAsync();
            return View(Boards);
        }

        /// <summary>
        /// Opens a board
        /// </summary>
        /// <returns>View of board</returns>
        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            var tasks = await _context.Tasks.Where(task => task.BoardId == id.ToString()).ToListAsync();
            var t1 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Union(tasks.Where(task => task.ListNum == 1)).ToListAsync();
            var t2 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Union(tasks.Where(task => task.ListNum == 2)).ToListAsync();
            var t3 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Union(tasks.Where(task => task.ListNum == 3)).ToListAsync();

            return View(model: new BoardView { Board = board, TaskL1 = t1, TaskL2 = t2, TaskL3 = t3 });
        }

        /// <summary>
        /// Serves the add board page
        /// </summary>
        /// <returns>The view of the add board page</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Board { UserId = _userManager.GetUserAsync(User).Id.ToString() });
        }

        /// <summary>
        /// Handles the creation of a new board
        /// </summary>
        /// <param name="board"> A board construct</param>
        /// <returns> A new board </returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Board board)
        {
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }



    }
}