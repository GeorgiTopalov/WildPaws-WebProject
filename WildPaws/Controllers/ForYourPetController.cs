using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class ForYourPetController : BaseController
    {
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
