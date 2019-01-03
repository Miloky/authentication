using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace authentication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "simple")]
        public IActionResult Simple()
        {
            ViewBag.Title = "Simple";
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            ViewBag.Title = "Admin";
            return View();
        }
    }
}
