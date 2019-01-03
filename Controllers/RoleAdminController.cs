using System.Collections.Generic;
using authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authentication.Controllers
{
    public class RoleAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleAdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole(name);
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                    return RedirectToAction("Index");

                foreach (IdentityError error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            EditModel model = new EditModel(role.Name);

            foreach (AppUser user in _userManager.Users.ToList())
            {
                model.Users.Add(new EditRoleUser
                {
                    InRole = await _userManager.IsInRoleAsync(user,role.Name),
                    Name = user.UserName,
                    Id = user.Id
                });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IEnumerable<EditRoleUser> users)
        {

            return View();
        }
    }
}