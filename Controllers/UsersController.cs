using authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager) => _userManager = userManager;
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }
    }
}