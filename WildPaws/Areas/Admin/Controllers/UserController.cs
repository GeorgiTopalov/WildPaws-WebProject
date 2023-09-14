using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WildPaws.Core.Constants;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<WildPawsUser> userManager;
        private readonly IUserService service;
        public UserController(
            RoleManager<IdentityRole> roleManager,
            UserManager<WildPawsUser> userManager,
            IUserService service)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await service.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            // {
            //     Name = "Administrator"
            // });

            return Ok();
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await service.GetUserForEdit(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await service.UpdateUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Successfully changed User data!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occured!";
            }
            return View(model);
        }
        public async Task<IActionResult> Roles(string id)
        {
            var user = await service.GetUserById(id);
            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                Name = $"{user.FirstName} {user.LastName}"
            };

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Id,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result
                });

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            var user = await service.GetUserById(model.UserId);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);

            if (model.RoleNames?.Length > 0)
            {
                await userManager.AddToRolesAsync(user, model.RoleNames);
            }

            return RedirectToAction(nameof(ManageUsers));
        }
        public async Task<IActionResult> Remove(string id)
        {
            return Ok(id);
        }
    }
}
