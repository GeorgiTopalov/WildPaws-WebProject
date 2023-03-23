using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class AboutController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
