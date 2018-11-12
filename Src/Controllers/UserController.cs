using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamMiller.Mumba.Data;
using SamMiller.Mumba.Models;
using SamMiller.Mumba.Models.AccountViewModels;

namespace SamMiller.Mumba.Controllers
{
    public class UserController : Controller
    {
        private MumbaContext _context;

        private UserManager<AppUser> _userManager;

        public UserController(MumbaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets the view for adding a user
        /// </summary>
        /// <returns>The add user view</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds a technician
        /// </summary>
        /// <returns>The technician list</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] NewAppUser newAppUser)
        {
            var AppUser = new AppUser
            {
                UserName = newAppUser.UserName,
                Email = newAppUser.Email,
            };
            await _userManager.CreateAsync(AppUser, newAppUser.Password);
          
            return RedirectToAction(BoardsController.All);
        }
    }
}