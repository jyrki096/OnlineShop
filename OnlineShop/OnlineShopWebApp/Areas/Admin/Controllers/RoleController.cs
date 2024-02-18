using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rolesManager;

        public RoleController(RoleManager<IdentityRole> rolesManager)
        {
            this.rolesManager = rolesManager;
        }

        public async Task<ActionResult> GetRolesAsync()
        {
            return View(await rolesManager.Roles.ToListAsync());
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddRoleAsync(Role role)
        {
            if (ModelState.IsValid)
            {
                var result = await rolesManager.CreateAsync(new IdentityRole(role.Name));

                if (result.Succeeded)
                    return RedirectToAction("GetRoles");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(role);
        }

        public async Task<ActionResult> RemoveRoleAsync(string roleId)
        {
            var role = await rolesManager.FindByIdAsync(roleId);
            
            if (role is not null)
                await rolesManager.DeleteAsync(role);  
                
            return RedirectToAction("GetRoles");
        }
    }
}
