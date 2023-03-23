using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class RecipesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
