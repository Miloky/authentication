using authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
            return View(nameof(Index));
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return PartialView("_Profile");
        }
    }
}