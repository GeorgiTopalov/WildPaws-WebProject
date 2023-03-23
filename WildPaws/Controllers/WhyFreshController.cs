using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class WhyFreshController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
