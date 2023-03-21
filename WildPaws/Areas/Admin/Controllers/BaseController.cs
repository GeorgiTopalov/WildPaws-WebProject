using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Constants;

namespace WildPaws.Areas.Admin.Controllers
{
    [Authorize(Roles = UserConstants.Roles.Administrator)]
    [Area("Admin")]
    public class BaseController : Controller
    {
       
    }
}
