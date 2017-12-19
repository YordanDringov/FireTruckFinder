namespace FireTruckFinder.Web.Areas.Admin.Controllers
{
    using FireTruckFinder.Data.Models;
    using FireTruckFinder.Web.Areas.Admin.Models;
    using FireTruckFinder.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Admin")]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class UsersController : Controller
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(
            IAdminUserService users,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = this.users.All();
            var roles = this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            var model = new AdminUserListingViewModel
            {
                Users = users,
                Roles = roles,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            var userExist = user != null;
            var roleExist = await roleManager.RoleExistsAsync(model.Role);

            if (!roleExist || !userExist)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            TempData.AddSuccessMessage($"User {user} added to {model.Role} role.");
            await this.userManager.AddToRoleAsync(user, model.Role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(DeleteUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new DeleteUserViewModel
            {
                Id = model.Id,
                UserName = user.UserName
            });
        }

        [HttpPost]
        public async Task<IActionResult> Destroy (string id)
        {
           var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await userManager.DeleteAsync(user);

            TempData.AddSuccessMessage($"User {user.UserName} was succesfully deleted");
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public async Task<IActionResult> Details(DetailsUserViewModel model)
        //{
        //    var user = await userManager.FindByIdAsync();

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(new DetailsUserViewModel
        //    {
                 
        //    });
        //}
    }
}
