using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class ContactUsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
