using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Data;
using SamMiller.Mumba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Routing;
using SamMiller.Mumba.Models.TaskViewModels;

namespace SamMiller.Mumba.Controllers
{
    public class TasksController : Controller
    {
        private MumbaContext _context;

        private UserManager<AppUser> _userManager;

        /// <summary>
        /// Initializes the private value _context
        /// </summary>
        /// <param name="context">The context of the user</param>
        /// <param name="userManager">The authorization middleware</param>
        public TasksController(MumbaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Open([FromRoute]Guid id)
        {   
            
            var task = await _context.Tasks.FindAsync(id);
            var boadId = Guid.Parse(task.BoardId);
            var board = await _context.Boards.FindAsync(boadId);
            return View(model: new TaskDetails { Task = task, Board=board});
        }

        /// <summary>
        /// Serves the add task page
        /// </summary>
        /// <returns>The view of the add task page</returns>
        [HttpGet]
        public IActionResult Add([FromRoute]Guid id)
        {
            return View(new Models.Task { BoardId = id.ToString() });
        }

        /// <summary>
        /// Handles the creation of a new board
        /// </summary>
        /// <param name="board"> A board construct</param>
        /// <returns> A new board </returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Models.Task task)
        {
           var routeValues = new RouteValueDictionary {
               {"id", task.BoardId}
           };
            _context.Tasks.Add(new Models.Task { Title = task.Title, Description=task.Description, BoardId=task.BoardId.ToString(), ListNum=task.ListNum});
            await _context.SaveChangesAsync();
            return RedirectToAction("Open","Boards", routeValues );
        }


        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Models.Task taskUpdate)
        {
            var task = await _context.Tasks.FindAsync(taskUpdate.Id);

            task.Title=taskUpdate.Title;
            task.Description= taskUpdate.Description;
            task.DueDate = taskUpdate.DueDate;
            task.ListNum=taskUpdate.ListNum;


            var routeValues = new RouteValueDictionary {
               {"id", task.Id.ToString()}
           };
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Open),"Tasks", routeValues);
        }

    }
}