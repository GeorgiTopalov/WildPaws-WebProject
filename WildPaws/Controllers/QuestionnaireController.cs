using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Controllers
{
    public class QuestionnaireController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
