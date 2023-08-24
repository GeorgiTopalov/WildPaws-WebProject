using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Contracts;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Controllers
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
    }
}
