using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Constants;
using WildPaws.Core.Contracts;
using WildPaws.Infrastructure.Data.Identity;
using static WildPaws.Core.Constants.UserConstants;

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

            return Ok(users);
        }

        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            // {
            //     Name = "Administrator"
            // });

            return Ok();
        }
    }
}
