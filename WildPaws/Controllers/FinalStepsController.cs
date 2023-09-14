using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class FinalStepsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
