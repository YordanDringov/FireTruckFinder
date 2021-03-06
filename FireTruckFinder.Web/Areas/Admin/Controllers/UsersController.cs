﻿namespace FireTruckFinder.Web.Areas.Admin.Controllers
{
    using FireTruckFinder.Data.Models;
    using FireTruckFinder.Web.Areas.Admin.Models;
    using FireTruckFinder.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin;
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
        [HttpPost]
        public async Task<IActionResult> RemoveFromRole(AddUserToRoleFormModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.UserId);

            if (!await this.IdentityDetailsValid(user, model.Role))
            {
                ModelState.AddModelError(string.Empty, $"Invalid Identity Details for {user}");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool IsUserInRole = await this.userManager.IsInRoleAsync(user, model.Role);

            if (!IsUserInRole)
            {
                TempData.AddSuccessMessage($"User {user.UserName} is not in Role {model.Role}");
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.RemoveFromRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} is removed from role {model.Role}");
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> IdentityDetailsValid(User user, string role)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(role);
            var userExists = user != null;
            return roleExists && userExists;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(DeleteUserViewModel userModel)
        {
            var user = await userManager.FindByIdAsync(userModel.Id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new DeleteUserViewModel
            {
                Id = userModel.Id,
                UserName = user.UserName
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(DeleteUserViewModel deleteUser)
        {
           var user = await userManager.FindByIdAsync(deleteUser.Id);

            if (user == null)
            {
                return NotFound();
            }

            await userManager.DeleteAsync(user);

            TempData.AddSuccessMessage($"User {user.UserName} was succesfully deleted");
            return RedirectToAction(nameof(Index));
        }
    }
}
