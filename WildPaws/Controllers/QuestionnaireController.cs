using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WildPaws.Core.Models;

namespace WildPaws.Controllers
{
    public class QuestionnaireController : BaseController
    {

        public QuestionnaireController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(QuestionnaireViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("index", model);
            }

            var questionnaireData = JsonConvert.SerializeObject(model);
            // Response.Cookies.Append("QuestionnaireData", questionnaireData);
            TempData["QuestionnaireData"] = questionnaireData;
            return RedirectToAction("Index", "ForYourPet", new { id = model.Id });

        }


    }
}
