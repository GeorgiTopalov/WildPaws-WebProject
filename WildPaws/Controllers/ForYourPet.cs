using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class ForYourPet : BaseController
    {
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
